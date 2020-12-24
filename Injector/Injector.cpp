// Injector.cpp : Diese Datei enthält die Funktion "main". Hier beginnt und endet die Ausführung des Programms.
//
#include <iostream>
#include <string>
#include <ctype.h>
#include <Windows.h>
#include <tlhelp32.h>
#include <Shlwapi.h>
#include <spdlog/spdlog.h>
#include <spdlog/sinks/basic_file_sink.h>
#include "Tools.h"

//Library needed by Linker to check file existance
#pragma comment(lib, "Shlwapi.lib")

#define EXIT_MEMORY_WRITE_FAILED		1000
#define EXIT_MEMORY_ALLOCATION_FAILED	1001
#define EXIT_REMOTE_THREAD_FAILED		1002
#define EXIT_CREATE_LOG_FAILED			1003
#define EXIT_ARGS_MISSING				1004
#define EXIT_DLL_NOT_FOUND				1005
#define EXIT_PROCESS_NOT_FOUND			1006
using ExitCode = int;

using namespace std;

int getProcID(const string& p_name);
ExitCode InjectDLL(const int& pid, const string& DLL_Path);

static std::shared_ptr<spdlog::logger> Log = NULL;

int main(int argc, char** argv)
{
	try {
		Log = spdlog::basic_logger_mt("Injector", "..\\..\\FoxGame\\Logs\\Injector.log");
		Log->set_level(spdlog::level::debug);
	}
	catch (const spdlog::spdlog_ex& ex) {
		return EXIT_CREATE_LOG_FAILED;
	}

	if (argc != 3)
	{
		Log->critical("Missing arguments ({0} should be {1})", argc, 3);
		return EXIT_ARGS_MISSING;
	}
	if (PathFileExistsA(argv[2]) == FALSE)
	{
		Log->critical("Dll ({0}) was not found!", argv[2]);
		return EXIT_DLL_NOT_FOUND;
	}

	if (isdigit(argv[1][0]))
	{
		ExitCode result = InjectDLL(atoi(argv[1]), argv[2]);
		if (result != 0)
			return result;

	}
	else {
		ExitCode result = InjectDLL(getProcID(argv[1]), argv[2]);
		if (result != 0)
			return result;
	}


	return EXIT_SUCCESS;
}

//-----------------------------------------------------------
// Get Process ID by its name
//-----------------------------------------------------------
int getProcID(const string& p_name)
{
	HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
	PROCESSENTRY32 structprocsnapshot = { 0 };

	structprocsnapshot.dwSize = sizeof(PROCESSENTRY32);

	if (snapshot == INVALID_HANDLE_VALUE)return 0;
	if (Process32First(snapshot, &structprocsnapshot) == FALSE)return 0;

	while (Process32Next(snapshot, &structprocsnapshot))
	{
		if (!strcmp(structprocsnapshot.szExeFile, p_name.c_str()))
		{
			CloseHandle(snapshot);
			Log->debug("PID ({0}) found for {1}", structprocsnapshot.th32ProcessID, p_name);
			return structprocsnapshot.th32ProcessID;
		}
	}
	CloseHandle(snapshot);
	Log->error("Process for {0} not found!", p_name);
	return 0;

}

//-----------------------------------------------------------
// Inject DLL to target process
//-----------------------------------------------------------
ExitCode InjectDLL(const int& pid, const string& DLL_Path)
{
	long dll_size = DLL_Path.length() + 1;
	HANDLE hProc = OpenProcess(PROCESS_ALL_ACCESS, FALSE, pid);

	if (hProc == NULL)
	{
		Log->error("Failed to open process (PID: {0})", pid);
		return EXIT_PROCESS_NOT_FOUND;
	}
	Log->debug("opening process {0}", pid);

	LPVOID MyAlloc = VirtualAllocEx(hProc, NULL, dll_size, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
	if (MyAlloc == NULL)
	{
		Log->error("Failed to allocate memory");
		return EXIT_MEMORY_ALLOCATION_FAILED;
	}

	Log->debug("Allocating memory");
	int IsWriteOK = WriteProcessMemory(hProc, MyAlloc, DLL_Path.c_str(), dll_size, 0);
	if (IsWriteOK == 0)
	{
		Log->error("Failed to write memory");
		return EXIT_MEMORY_WRITE_FAILED;
	}
	Log->debug("Creating Remote Thread in Target Process");

	DWORD dWord;
	LPTHREAD_START_ROUTINE addrLoadLibrary = (LPTHREAD_START_ROUTINE)GetProcAddress(LoadLibrary("kernel32"), "LoadLibraryA");
	HANDLE ThreadReturn = CreateRemoteThread(hProc, NULL, 0, addrLoadLibrary, MyAlloc, 0, &dWord);
	if (ThreadReturn == NULL)
	{
		Log->error("Failed to create remote thread");
		return EXIT_REMOTE_THREAD_FAILED;
	}

	if ((hProc != NULL) && (MyAlloc != NULL) && (IsWriteOK != ERROR_INVALID_HANDLE) && (ThreadReturn != NULL))
	{
		Log->info("DLL ({0}) succesfully injected into {1}.", DLL_Path, pid);
		return 0;
	}

	return EXIT_FAILURE;
}
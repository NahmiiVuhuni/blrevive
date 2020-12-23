#include "pch.h"
#include "Logger.h"
#include <winternl.h>


std::shared_ptr<spdlog::logger> BLRevive::Logger::pInstance = NULL;
std::string BLRevive::Logger::LogFileName = "BLRevive";


typedef NTSTATUS(__stdcall* NTQIPWrap) (HANDLE ProcessHandle, PROCESSINFOCLASS ProcessInformationClass, PVOID ProcessInformation, ULONG ProcessInformationLength, PULONG ReturnLength);
static NTSTATUS NTQIPWrapper(HANDLE ProcessHandle, PROCESSINFOCLASS ProcessInformationClass, PVOID ProcessInformation, ULONG ProcessInformationLength, PULONG ReturnLength)
{
    HINSTANCE hinstLib;
    NTQIPWrap ProcAdd = NULL;
    BOOL fFreeResult, fRunTimeLinkSuccess = FALSE;

    // Get a handle to the DLL module.

    hinstLib = LoadLibrary(TEXT("Ntdll.dll"));

    // If the handle is valid, try to get the function address.

    if (hinstLib != NULL)
    {
        ProcAdd = (NTQIPWrap)GetProcAddress(hinstLib, "NtQueryInformationProcess");

        // If the function address is valid, call the function.

        if (NULL != ProcAdd)
        {
            fRunTimeLinkSuccess = TRUE;
            (ProcAdd)(ProcessHandle, ProcessInformationClass, ProcessInformation, ProcessInformationLength, ReturnLength);
        }
        // Free the DLL module.

        fFreeResult = FreeLibrary(hinstLib);
    }

    // If unable to call the DLL function, use an alternative.
    if (!fRunTimeLinkSuccess)
        printf("Message printed from executable\n");

    return 0;
}

std::shared_ptr<spdlog::logger> BLRevive::Logger::Get()
{
    if (!pInstance) {
        TCHAR szExeFileName[MAX_PATH];
        GetModuleFileName(NULL, szExeFileName, MAX_PATH);
        std::wstring fileName(szExeFileName);

        std::string logFileName("../../FoxGame/Logs/");
        logFileName.append(LogFileName);

        if (fileName.find(L"Server") != std::wstring::npos) {
            logFileName.append("-Server");
        }
        logFileName.append(".log");

        MessageBoxA(NULL, logFileName.c_str(), "", MB_OK);

        pInstance = spdlog::basic_logger_mt("BLR", logFileName.c_str());
        pInstance->set_level(spdlog::level::debug);
    }

    return pInstance;
}

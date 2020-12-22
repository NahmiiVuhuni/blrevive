#include "Tools.h"
#include <tchar.h>
#include <stdio.h>
#include <psapi.h>

bool Injector::Tools::CheckForModule(HANDLE hProcess, std::string ModuleName)
{
    HMODULE hMods[1024];
    DWORD cbNeeded;
    unsigned int i;

    // Print the process identifier.

    //printf("\nProcess ID: %u\n", PID);

    // Get a handle to the process.

    /*hProcess = OpenProcess(PROCESS_QUERY_INFORMATION |
        PROCESS_VM_READ,
        FALSE, PID);
    if (NULL == hProcess)
        return 1;*/

    // Get a list of all the modules in this process.

    if (EnumProcessModules(hProcess, hMods, sizeof(hMods), &cbNeeded))
    {
        for (i = 0; i < (cbNeeded / sizeof(HMODULE)); i++)
        {
            TCHAR szModName[MAX_PATH];

            // Get the full path to the module's file.

            if (GetModuleFileNameEx(hProcess, hMods[i], szModName,
                sizeof(szModName) / sizeof(TCHAR)))
            {
                // Print the module name and handle value.
                if (szModName == ModuleName)
                    return true;
            }
        }
    }

    // Release the handle to the process.

    CloseHandle(hProcess);

    return false;
}

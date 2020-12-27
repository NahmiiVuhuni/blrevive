// dllmain.cpp : Definiert den Einstiegspunkt für die DLL-Anwendung.
#include "pch.h"
#include "Tools.h"
//#include "Proxy.h"
//#include "SetEmblemPatch.h"
#include "Config.h"

void OnAttach()
{
    LInfo("Dll Injection succeeded.");
    LFlush;

    /*BLRevive::Proxy::LogProcessEventCalls = Config::LogProcessEventCalls();
    BLRevive::Patch::ApplyAll();
    BLRevive::Proxy::GetInstance()->Initialize();*/
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)OnAttach, NULL, NULL, NULL);
        break;
    case DLL_THREAD_ATTACH:
        break;
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

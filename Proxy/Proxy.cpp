#include "pch.h"
#include "Proxy.h"
#include "Offsets.h"
#include "../SDK/SdkHeaders.h"
#include "Config.h"
#include <detours/detours.h>

#pragma comment (lib, "detours.lib")

using namespace BLRevive;
using namespace std;

#pragma region Constructors

Proxy* Proxy::pInstance = NULL;

Proxy* BLRevive::Proxy::GetInstance()
{
	if (!pInstance)
		pInstance = new Proxy();

	return pInstance;
}

BLRevive::Proxy::Proxy()
{
}

#pragma endregion

#pragma region ProcessEventDetour
typedef bool(*tProcessEventWrapper)(const class UObject* pCaller, const class UFunction* pFunction, const void* pParams);
tProcessEventWrapper pProcessEventWrapper;
typedef void(__thiscall* tProcessEvent)(class UObject*, class UFunction*, void*);
tProcessEvent ProcessEvent = (tProcessEvent)pProcessEvent;
void hkProcessEvent();

DWORD FunctionXorg = NULL;
DWORD ParamsXorg = NULL;



static DWORD dwProcessEventReturn = (DWORD)pProcessEventMidHookReturn;
static DWORD dwProcessEventSkip = (DWORD)pProcessEventMidHookEndReturn;
static DWORD dwPEReturn = (DWORD)(pProcessEventMidHookReturn + 0xA);


DWORD pCaller = NULL;
DWORD pFunction = NULL;
DWORD pParams = NULL;
void __declspec(naked) hkProcessEvent()
{
	__asm
	{
		MOV			pFunction, EDI;
		MOV			pParams, EBX;
		MOV			pCaller, ESI;

		PUSHAD;
		PUSHFD;
	}

	pProcessEventWrapper((UObject*)pCaller, (UFunction*)pFunction, (void*)pParams);

	__asm
	{									// restore all registers
		POPFD;
		POPAD;

		TEST		DWORD PTR[EDI + 0x84], 0x402;
		JMP			[dwPEReturn];
	}
}
#pragma endregion

static AFoxPC* pAPC = NULL;
static UFoxUI* pUI = NULL;
static UConsole* pConsole = NULL;
static UEngine* pEngine = NULL;
static ULocalPlayer* pLocalPlayer = NULL;
static bool bSetInventory = false;
bool ProcessEventWrapper(UObject* pCaller, UFunction* pFunction, void* pParams)
{
	if (!pCaller) {
		LError("ProcessEvent: Caller is null!");
		LFlush;
		return false;
	}
	if (!pFunction) {
		LError("ProcessEvent: Function is null!");
		LFlush;
		return false;
	}


	try {
		std::string callerName(pCaller->GetName());
		std::string functionName(pFunction->GetName());

		if (functionName == "BeginState")
		{
			UObject_eventBeginState_Parms* parms = reinterpret_cast<UObject_eventBeginState_Parms*>(pParams);
			LDebug("{0}->{1}(PreviousState: {2})", callerName, functionName, parms->PreviousStateName.GetName());
			LFlush;
			return true;
		}
		else if (functionName == "EndState") {
			UObject_eventEndState_Parms* parms = reinterpret_cast<UObject_eventEndState_Parms*>(pParams);
			LDebug("{0}->{1}(NextState: {2})", callerName, functionName, parms->NextStateName.GetName());
			return true;
		}
		else if (functionName == "ClientGotoState") {
			APlayerController_execClientGotoState_Parms* parms = reinterpret_cast<APlayerController_execClientGotoState_Parms*>(pParams);
			std::string newStateName(parms->NewState.GetName());
			if ( newStateName == "PlayerWalking")
			{
				//LDebug("ChangePreset: {0}", ret.ToChar());
			}

			LDebug("{0}->{1}(NewState: {2} | NewLabel: {3})", callerName, functionName, parms->NewState.GetName(), parms->NewLabel.GetName());
			return true;
		}


		if (BLRevive::Proxy::LogProcessEventCalls)
		{
			LDebug("{0}->{1}({2:x})", callerName, functionName, (DWORD)pParams);
			LFlush;
		}
	}
	catch (const int ex) {
		LError("Error {0}", ex);
		LFlush;
	}
	
	return true;
}

void BLRevive::Proxy::Initialize()
{
	LDebug("Initializing Proxy.");

	BLRevive::Proxy::LogProcessEventCalls = Config::LogProcessEventCalls();

	MakeJMP((BYTE*)pProcessEventMidHookReturn, (DWORD)hkProcessEvent, 0xA);
	pProcessEventWrapper = (tProcessEventWrapper)ProcessEventWrapper;
	LDebug("Proxy initialized");
}

void BLRevive::Proxy::MakeJMP(BYTE* pAddress, DWORD dwJumpTo, DWORD dwLen)
{
	DWORD dwOldProtect, dwBkup, dwRelAddr;
	VirtualProtect(pAddress, dwLen, PAGE_EXECUTE_READWRITE, &dwOldProtect);
	dwRelAddr = (DWORD)(dwJumpTo - (DWORD)pAddress) - 5;
	*pAddress = 0xE9;
	*((DWORD*)(pAddress + 0x1)) = dwRelAddr;
	for (DWORD x = 0x5; x < dwLen; x++) *(pAddress + x) = 0x90;
	VirtualProtect(pAddress, dwLen, dwOldProtect, &dwBkup);
	return;
}
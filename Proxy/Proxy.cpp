#include "pch.h"
#include "Proxy.h"
#include "Offsets.h"
#include "../SDK/SdkHeaders.h"
#include "Config.h"

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
void hkProcessEvent();

DWORD FunctionXorg = NULL;
DWORD ParamsXorg = NULL;

DWORD pCaller = NULL;
DWORD pFunction = NULL;
DWORD pParams = NULL;

static DWORD dwProcessEventReturn = BLInfo.ProcessEventMidHookReturn;
static DWORD dwProcessEventSkip = BLInfo.ProcessEventMidHookEndReturn;

void __declspec(naked) hkProcessEvent()
{
	__asm
	{
		XOR		EBX, [ECX + EAX * 4]			// overwritten instruction
		PUSH	EAX								// save eax
		/*MOV		EAX, DWORD PTR[EBP + 0x8]		// get decrypted function pointer
		MOV		pDecryptedFunction, EAX
		MOV		EAX, DWORD PTR[EBP + 0xC]		// get decrypted params pointer
		MOV		pDecryptedParams, EAX*/
		MOV		pFunction, EDI					// get encrypted function pointer
		MOV		pParams, EBX					// get encrypted params pointer
		MOV		EAX, DWORD PTR[EBP - 0x20]
		MOV		pCaller, EAX
		POP		EAX								// restore eax
		PUSHAD									// save all registers
	}

	if (pFunction)
		if (pProcessEventWrapper((const UObject*)pCaller, (const UFunction*)pFunction, (const void*)pParams))
		{
			__asm
			{
				POPAD									// restore all registers
				JMP[dwProcessEventReturn]
			}
		}
		else {
			__asm
			{
				POPAD
				JMP[dwProcessEventSkip]
			}
		}
}
#pragma endregion

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


	if (BLRevive::Proxy::LogProcessEventCalls)
	{
		std::string callerName(pCaller->GetName());
		std::string functionName(pFunction->GetName());
		LDebug("{0}->{1}({2:x})", callerName, functionName, (DWORD)pParams);
	}

	return true;
}

void BLRevive::Proxy::Initialize()
{
	LDebug("Initializing Proxy.");
	MakeJMP((BYTE*)BLInfo.ProcessEventMidHook, (DWORD)hkProcessEvent, 0x5);
	pProcessEventWrapper = (tProcessEventWrapper)ProcessEventWrapper;
	LDebug("Proxy initialized");
}

bool BLRevive::Proxy::IsServer()
{
	AWorldInfo* wi = UObject::GetInstanceOf<AWorldInfo>();
	if (!wi) {
		MessageBoxA(NULL, "WorldInfo not found!", "Error", MB_OK);
		return false;
	}


	return wi->IsServer();
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


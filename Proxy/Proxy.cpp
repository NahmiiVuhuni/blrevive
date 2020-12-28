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

static DWORD dwProcessEventReturn = (DWORD)pProcessEventMidHookReturn;
static DWORD dwProcessEventSkip = (DWORD)pProcessEventMidHookEndReturn;

void __declspec(naked) hkProcessEvent()
{
	__asm
	{
		XOR		EBX, [ECX + EAX * 4]			// overwritten instruction
		PUSH	EAX								// save eax
		//MOV		EAX, DWORD PTR[EBP + 0x8]		// get decrypted function pointer
		//MOV		pDecryptedFunction, EAX
		//MOV		EAX, DWORD PTR[EBP + 0xC]		// get decrypted params pointer
		//MOV		pDecryptedParams, EAX
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

static AFoxPC* pAPC = NULL;
static UFoxUI* pUI = NULL;
static UConsole* pConsole = NULL;
static UEngine* pEngine = NULL;
static ULocalPlayer* pLocalPlayer = NULL;
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
		/*if (callerName == "FoxGameViewportClient" && functionName == "PostRender")
		{
			UGameViewportClient_eventPostRender_Parms* parms = reinterpret_cast<UGameViewportClient_eventPostRender_Parms*>(pParams);
			SHORT addKeyState = GetAsyncKeyState(VK_ADD);

			if (addKeyState & 0x8000 && addKeyState & 1 == 1)
			{

				 // Working console command!

				if (!pAPC)
					pAPC = UObject::GetInstanceOf<AFoxPC>();

				if (!pAPC) {
					LError("AFoxPC not found");
					LFlush;
				}
				else {
					FString result = pAPC->ConsoleCommand("/help", false);
					LDebug("Result: {0}", result.ToChar());
					LFlush;
				}

			}
		}*/
		if (callerName == "FoxChatUI" && functionName == "SubmitChat")
		{
			UFoxChatUI_execSubmitChat_Parms* parms = reinterpret_cast<UFoxChatUI_execSubmitChat_Parms*>(pParams);
			std::string messageText(parms->MessageText.ToChar());

			if (messageText[0] == '!')
			{
				auto command = messageText.substr(1, messageText.length());

				if (!pAPC)
					pAPC = UObject::GetInstanceOf<AFoxPC>();

				FString result = pAPC->ConsoleCommand(FString(command.c_str()), false);
				LDebug("{0}: {1}", command, result.ToChar());
				LFlush;
				UFoxChatUI* chat = reinterpret_cast<UFoxChatUI*>(pCaller);
				chat->AddNewChatMessage(result);
				return true;
			}
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

#pragma region ProcessInternal/CallFunction
typedef bool(*tProcessInternalWrapper)();




#pragma endregion



void BLRevive::Proxy::Initialize()
{
	LDebug("Initializing Proxy.");
	MakeJMP((BYTE*)pProcessEventMidHook, (DWORD)hkProcessEvent, 0x5);
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
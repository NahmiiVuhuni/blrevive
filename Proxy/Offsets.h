#pragma once
#include <Windows.h>
#include "Tools.h"

typedef struct _ENCRYPTIONBASE
{
	PDWORD pPParamsBase;
	unsigned char	unknkownData[0x400];
	PDWORD pUFunctionBase;

} ENCRYPTIONBASE, * LPENCRYPTIONBASE;

typedef struct _ENCRYPTIONINDEX
{
	DWORD PParamsIndex;
	unsigned char unknownData[0x80];
	DWORD UFunctionIndex;

} ENCRYPTIONINDEX, * LPENCRYPTIONINDEX;

struct MPtr
{
private:
	DWORD mptr;
public:
	MPtr(DWORD ptr)
	{
		this->mptr = (DWORD)GetModuleHandleA(BLRevive::Tools::GetExecFileName().c_str()) + ptr;
	}

	operator DWORD() const { return this->mptr; }
};

struct BLRInfo
{
public:
	DWORD ProcessEvent = MPtr(0x61530);
	DWORD ProcessEventMidHook = MPtr(0x61586);
	DWORD ProcessEventMidHookReturn = MPtr(0x6158D);
	DWORD ProcessEventMidHookEndReturn = MPtr(0x6180B);
	int	ProcessEventIndex = 67;

	DWORD PEEncryptionBase = MPtr(0x1508D6C);
	DWORD PEEncryptionIndex = MPtr(0x142E93C);

	DWORD GObjects = MPtr(0x01523220);
	DWORD GNames = MPtr(0x015231F0);
};

BLRInfo BLInfo;
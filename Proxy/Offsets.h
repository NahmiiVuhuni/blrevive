#pragma once
#include <Windows.h>
#include "Tools.h"

/// <summary>
/// Contains data for ProcessEvent's XOR base.
/// </summary>
typedef struct _ENCRYPTIONBASE
{
	PDWORD pPParamsBase;
	unsigned char	unknkownData[0x400];
	PDWORD pUFunctionBase;

} ENCRYPTIONBASE, * LPENCRYPTIONBASE;

/// <summary>
/// Contains data for ProcessEvent's XOR index.
/// </summary>
typedef struct _ENCRYPTIONINDEX
{
	DWORD PParamsIndex;
	unsigned char unknownData[0x80];
	DWORD UFunctionIndex;

} ENCRYPTIONINDEX, * LPENCRYPTIONINDEX;

#define pBase							0x400000
#define pProcessEvent					0x461530
#define pProcessEventMidHook			0x461586
#define pProcessEventMidHookReturn		0x46158D
#define pProcessEventMidHookEndReturn	0x46180B
int	ProcessEventIndex = 67;

#define pPEEncryptionBase				0x1908D6C
#define pPEEncryptionIndex				0x182E93C

#define GObjects						0x1923220
#define GNames							0x19231F0
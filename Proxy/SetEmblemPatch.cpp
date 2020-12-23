#include "pch.h"
#include "SetEmblemPatch.h"
#include "Tools.h"


int BLRevive::Patches::SetEmblemPatch::PatchOffset = 0xB397A6;

bool BLRevive::Patches::SetEmblemPatch::Apply()
{
	std::string baseName = BLRevive::Tools::GetExecFileName();
	int Base = (int)GetModuleHandleA(baseName.c_str());
	int PatchAddress = Base + PatchOffset;
	LDebug("Patching at: {0:x} (FileName: {1}; BaseModule: {2:x})", PatchAddress, baseName, Base);

	MEMORY_BASIC_INFORMATION mem;
	VirtualQuery((void*)PatchAddress, &mem, sizeof(MEMORY_BASIC_INFORMATION));
	DWORD oldProtect = mem.Protect;
	if (!VirtualProtect(mem.BaseAddress, mem.RegionSize, PAGE_EXECUTE_READWRITE, &oldProtect)) {
		LError("SetEmblemPatch: Setting page protection failed!");
		return false;
	}
    std::memcpy((void*)PatchAddress, &PatchBytes, 0x4);

	if (!VirtualProtect(mem.BaseAddress, mem.RegionSize, oldProtect, &oldProtect)) {
		LError("SetEmblemPatch: Restoring page protection failed!");
	}

	LDebug("Succesfully applied SetEmblemPatch!");
	LFlush;
    return true;
}

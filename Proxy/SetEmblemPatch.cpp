#include "pch.h"
#include "SetEmblemPatch.h"

int BLRevive::Patches::SetEmblemPatch::PatchOffset = 0xB397A6;

bool BLRevive::Patches::SetEmblemPatch::Apply()
{
	int Base = (int)GetModuleHandleA("FoxGame-win32-Shipping-O2.exe");
	int PatchAddress = Base + PatchOffset;
	LDebug("Patching at: {0:x} (BaseModule: {1:x})", PatchAddress, Base);

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
    return true;
}

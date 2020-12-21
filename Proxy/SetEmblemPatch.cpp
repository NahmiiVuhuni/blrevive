#include "pch.h"
#include "SetEmblemPatch.h"

struct MPtr
{
private:
	DWORD mptr;
public:
	MPtr(DWORD ptr)
	{
		this->mptr = (DWORD)GetModuleHandleA("FoxGame-win32-Shipping.exe") + ptr;
	}

	operator DWORD() const { return this->mptr; }
};

const char* BLRevive::Patches::SetEmblemPatch::PatchBytes = new char[] {90, 90, 90, 90};
const int BLRevive::Patches::SetEmblemPatch::PatchAddress = MPtr(0x96187B);

bool BLRevive::Patches::SetEmblemPatch::Apply()
{
	LDebug("Patching at: {0:x}", PatchAddress);

	MEMORY_BASIC_INFORMATION mem;
	VirtualQuery((void*)PatchAddress, &mem, sizeof(MEMORY_BASIC_INFORMATION));
	if (!VirtualProtect(mem.BaseAddress, mem.RegionSize, PAGE_EXECUTE_READWRITE, &mem.Protect)) {
		LError("SetEmblemPatch: Setting page protection failed!");
		return false;
	}
    std::memcpy((void*)PatchAddress, (void*)PatchBytes, 0x4);

	DWORD oldProtect = mem.Protect;
	if (!VirtualProtect(mem.BaseAddress, mem.RegionSize, mem.Protect, &oldProtect)) {
		LError("SetEmblemPatch: Restoring page protection failed!");
	}

	LDebug("Succesfully applied SetEmblemPatch!");
    return true;
}

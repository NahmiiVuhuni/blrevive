#include "pch.h"
#include "Patcher.h"
#include "SetEmblemPatch.h"

using namespace BLRevive;

std::list<Patch*> Patch::Patches = std::list<Patch*>();

void BLRevive::Patch::Initialize()
{
	Patches.push_back(new BLRevive::Patches::SetEmblemPatch());
}

bool BLRevive::Patch::ApplyAll()
{
	Initialize();

	for (auto const pPatch : Patches)
	{
		if (!pPatch->Apply())
			return false;
	}

	return true;
}

void BLRevive::Patch::Register(Patch* pPatch)
{
	Patches.push_back(pPatch);
}

bool BLRevive::Patch::Apply()
{
	bApplied = true;
	return true;
}

bool BLRevive::Patch::IsApplied()
{
	return bApplied;
}

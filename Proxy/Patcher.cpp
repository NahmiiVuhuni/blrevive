#include "pch.h"
#include "Patcher.h"

using namespace BLRevive;

std::list<Patch*> Patch::Patches = std::list<Patch*>();

void BLRevive::Patch::Initialize()
{

}

bool BLRevive::Patch::ApplyAll()
{
	for (auto const pPatch : Patches)
	{
		if (!pPatch->Apply())
			return false;
	}
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

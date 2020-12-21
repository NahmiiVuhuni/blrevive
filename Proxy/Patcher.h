#pragma once


namespace BLRevive
{
	class Patch
	{
	public:
		static void Initialize();
		static bool ApplyAll();
		static void Register(Patch* pPatch);

	protected:
		static std::list<Patch*> Patches;

	public:
		virtual bool Apply();
		bool IsApplied();

	protected:
		bool bApplied = false;
	};
}
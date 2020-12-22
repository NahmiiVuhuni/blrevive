#pragma once
#include "Patcher.h"

namespace BLRevive::Patches
{
    class SetEmblemPatch :
        public BLRevive::Patch
    {
    public:
        bool Apply() override;

    private:
        static int PatchOffset;
        inline constexpr static BYTE PatchBytes[] = "\x90\x90\x90\x90";
    };

}

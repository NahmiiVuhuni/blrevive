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
        static const int PatchAddress;
        static const char* PatchBytes;
    };

}

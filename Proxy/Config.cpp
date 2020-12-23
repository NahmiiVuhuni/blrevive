#include "pch.h"
#include "Config.h"
#include <filesystem>

namespace fs = std::filesystem;

bool Config::LogProcessEventCalls()
{
    auto config = GetConfig();
    if (config == NULL) {
        MessageBoxA(NULL, "Config was null", "Error", MB_OK);
        return false;
    }

    bool value = false;
    try {
        value = config["LogProcessEventCalls"].get<int>();
    }
    catch (json::exception ex) {
        MessageBoxA(NULL, ex.what(), "JSON Parse Error", MB_OK);
    }
    return value;
}

json Config::GetConfig()
{
    if (_ConfigJson == NULL)
    {
        TCHAR buff[255];
        GetModuleFileName(NULL, buff, sizeof(buff));
        std::wstring exeFilePath(buff);

        std::wstring exePath(exeFilePath.substr(0, exeFilePath.find_last_of(L"\\") + 1));
        std::wstring configPath(exePath);
        configPath.append(L"BLRevive.json");

        try {
            std::ifstream configStream(configPath, std::ifstream::binary);
            try {
                _ConfigJson = json::parse(configStream);
            }
            catch (json::exception ex) {
                MessageBoxA(NULL, ex.what(), "JSON Error", MB_OK);
                exit(1);
            }
        }
        catch (std::exception ex) {
            MessageBoxA(NULL, ex.what(), "FileError", MB_OK);
        }
    }

    return _ConfigJson;
}

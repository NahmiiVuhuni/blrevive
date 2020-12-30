#include "pch.h"
#include "Config.h"
#include <filesystem>

namespace fs = std::filesystem;

bool Config::LogProcessEventCalls()
{
    try {
        return GetConfig()["LogProcessEventCalls"].get<int>();
    }
    catch (json::exception ex) {
        MessageBoxA(NULL, ex.what(), "JSON Parse Error", MB_OK);
        return false;
    }
}

std::string Config::Command()
{
    try {
        return GetConfig()["Command"].get<std::string>();
    }
    catch (json::exception ex) {
        MessageBoxA(NULL, ex.what(), "JSON Parse Error", MB_OK);
        return "";
    }
}

std::string Config::CommandKey()
{
    try {
        return GetConfig()["CommandKey"].get<std::string>();
    }
    catch (json::exception ex) {
        MessageBoxA(NULL, ex.what(), "JSON Parse Error", MB_OK);
        return "";
    }
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

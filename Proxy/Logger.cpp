#include "pch.h"
#include "Logger.h"
#include <winternl.h>


std::shared_ptr<spdlog::logger> BLRevive::Logger::pInstance = NULL;
std::string BLRevive::Logger::LogFileName = "BLRevive";


std::shared_ptr<spdlog::logger> BLRevive::Logger::Get()
{
    if (!pInstance) {
        TCHAR szExeFileName[MAX_PATH];
        GetModuleFileName(NULL, szExeFileName, MAX_PATH);
        std::wstring fileName(szExeFileName);

        std::string logFileName("../../FoxGame/Logs/");
        logFileName.append(LogFileName);

        if (fileName.find(L"Server") != std::wstring::npos) {
            logFileName.append("-Server");
        }
        logFileName.append(".log");

        pInstance = spdlog::basic_logger_mt("BLR", logFileName.c_str());
        pInstance->set_level(spdlog::level::debug);
    }

    return pInstance;
}

#include "pch.h"
#include "Logger.h"

std::shared_ptr<spdlog::logger> BLRevive::Logger::pInstance = NULL;

std::shared_ptr<spdlog::logger> BLRevive::Logger::Get()
{
    if (!pInstance) {
        pInstance = spdlog::basic_logger_mt("BLR", "../../FoxGame/Logs/BLRevive.txt");
    }

    return pInstance;
}

#pragma once

#include <spdlog/spdlog.h>
#include <spdlog/sinks/stdout_color_sinks.h>
#include <spdlog/sinks/basic_file_sink.h>

#define LInfo(...) BLRevive::Logger::Get()->info(__VA_ARGS__)
#define LWarn(...) BLRevive::Logger::Get()->warn(__VA_ARGS__)
#define LError(...) BLRevive::Logger::Get()->error(__VA_ARGS__)
#define LCritical(...) BLRevive::Logger::Get()->critical(__VA_ARGS__)
#define LDebug(...) BLRevive::Logger::Get()->debug(__VA_ARGS__)
#define LFlush BLRevive::Logger::Get()->flush();

namespace BLRevive
{
	class Logger
	{
	public:
		static std::shared_ptr<spdlog::logger> Get();

	private:
		static std::shared_ptr<spdlog::logger> pInstance;
		static std::string LogFileName;
	};
}


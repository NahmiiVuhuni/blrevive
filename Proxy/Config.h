#pragma once
#include <nlohmann/json.hpp>
#include <string>
#include <fstream>
#include <streambuf>

using json = nlohmann::json;

class Config
{
public:
	static bool LogProcessEventCalls();

protected:
	inline static std::string ConfigFile = std::string("BLRevive.json");
	inline static json _ConfigJson = NULL;

	static json GetConfig();
};


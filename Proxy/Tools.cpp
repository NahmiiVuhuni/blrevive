#include "pch.h"
#include "Tools.h"

std::string BLRevive::Tools::GetExecFileName()
{
	char szExeFileName[MAX_PATH];
	GetModuleFileNameA(NULL, szExeFileName, MAX_PATH);
	std::string efn(szExeFileName);
	std::string fileName = efn.substr(efn.find_last_of("\\/") + 1, efn.length());
	return fileName;
}

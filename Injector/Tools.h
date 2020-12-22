#pragma once

#include <string>
#include <windows.h>

namespace Injector
{
	class Tools
	{
	public:
		static bool CheckForModule(HANDLE hProcess, std::string ModuleName);
	};
}

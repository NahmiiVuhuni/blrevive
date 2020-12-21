#include "pch.h"
#include "Proxy.h"

using namespace BLRevive;
using namespace std;

#pragma region Constructors

Proxy* Proxy::pInstance = NULL;

Proxy* BLRevive::Proxy::GetInstance()
{
	if (!pInstance)
		pInstance = new Proxy();

	return pInstance;
}

BLRevive::Proxy::Proxy()
{
}

#pragma endregion

void BLRevive::Proxy::Initialize()
{
	LDebug("Initializing Proxy.");
}
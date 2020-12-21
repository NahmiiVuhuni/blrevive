#include "pch.h"
#include "Proxy.h"
#include "../SDK/SdkHeaders.h"

using namespace BLRevive;

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

BLRevive::Proxy::~Proxy()
{
}

#pragma endregion

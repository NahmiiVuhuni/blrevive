#pragma once

namespace BLRevive
{
	/// <summary>
	/// Proxy handler class. Entry point of the application.
	/// </summary>
	class Proxy
	{
	public:
		static Proxy* GetInstance();
		inline constexpr static bool LogProcessEventCalls = false;

		void Initialize();

		static bool IsServer();

	protected:
		Proxy();

		static void MakeJMP(BYTE* pAddress, DWORD dwJumpTo, DWORD dwLen);

	private:
		static Proxy* pInstance;
	};
}


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

		void Initialize();

	protected:
		Proxy();

	private:
		static Proxy* pInstance;
	};
}


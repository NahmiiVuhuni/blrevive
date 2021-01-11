using System;

namespace BLRevive.Launcher
{
    /// <summary>
    /// Provides common user util functions
    /// </summary>
    class UserUtil
    {
        /// <summary>
        /// Validates player name 
        /// </summary>
        /// <param name="playerName"></param>
        /// <returns>True if user name is not null, empty or white spaces, False otherwise</returns>
        public static bool IsValidPlayerName(string playerName)
        {
            return !String.IsNullOrWhiteSpace(playerName);
        }

        /// <summary>
        /// Saves current player name to JSON config
        /// </summary>
        /// <param name="currentPlayerName"></param>
        /// <returns>True if the player name was successfully saved, False otherwise</returns>
        public static bool SavePlayerName(string currentPlayerName)
        {
            Config.Get().Username = currentPlayerName;
            return Config.Save();
        }
    }
}


using System;
using Serilog;
using Avalonia;

namespace Launcher.Utils
{
    public class UserInputException : Exception
    {
        public UserInputException() : base() {}
        public UserInputException(string message) : base (message) {}
        public UserInputException(string message, Exception inner) : base(message, inner) {}
    }
}
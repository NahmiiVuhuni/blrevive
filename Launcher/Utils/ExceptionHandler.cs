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
    
    class ExceptionHandler
    {
        public static bool IsGui = true;

        public struct HandleConfig
        {
            public string ErrorMessage  { get; set; }
            public string UserMessage { get; set; }

            public int ErrorCode { get; set; }
            public bool Exit { get; set; }
        }
        
        public static void Handle(Exception ex, HandleConfig config)
        {
            // as soon as we have a logger available use it to log the exception nonetheless
            if(Log.Logger != null)
            {
                if(String.IsNullOrEmpty(config.ErrorMessage))
                    config.ErrorMessage = $"{config.UserMessage}: {{@Exception}}";

                if(config.Exit)
                    Log.Fatal(ex, config.ErrorMessage);
                else 
                    Log.Error(ex, config.ErrorMessage);
            }

            // if UserMessage is given and app is running in GUI mode, print an error messagebox 
            if(!String.IsNullOrEmpty(config.UserMessage) && IsGui)
            {
                MessageBox.Avalonia.MessageBoxManager
                    .GetMessageBoxStandardWindow(config.Exit ? "Fatal" : "Error", config.UserMessage, 
                        MessageBox.Avalonia.Enums.ButtonEnum.Ok, MessageBox.Avalonia.Enums.Icon.Error);
            }

            // if Exit is specified, exit from application with error code
            if(config.Exit)
                Environment.Exit(config.ErrorCode);
        }
    }
}
using System;
//using Microsoft.Extensions.Configuration;

namespace DesignPatterns.CreationalPatterns.Singleton
{
    // #region Approach One (without Lazy operator)
    // // Singleton ConfigurationManager class implementing the IConfigurationProvider interface
    // public class ConfigurationManager : IConfigurationProvider
    // {
    //     // Private static instance variable
    //     private static ConfigurationManager _instance;

    //     // Private object for locking during instance creation
    //     private static readonly object LockObject = new object();

    //     private IConfiguration _configuration;

    //     private ConfigurationManager()
    //     {
    //         // Load application configuration settings using .NET Core's IConfiguration
    //         var builder = new ConfigurationBuilder()
    //             .SetBasePath(AppContext.BaseDirectory)
    //             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    //         _configuration = builder.Build();
    //     }

    //     // Public static method to access the Singleton instance
    //     public static ConfigurationManager Instance
    //     {
    //         get
    //         {
    //             if (_instance == null)
    //             {
    //                 lock (LockObject)
    //                 {
    //                     if (_instance == null)
    //                     {
    //                         _instance = new ConfigurationManager();
    //                     }
    //                 }
    //             }
    //             return _instance;
    //         }
    //     }

    //     public string GetSetting(string key)
    //     {
    //         return _configuration[key];
    //     }
    // }
    // #endregion

    #region Approach Two (with Lazy operator)
    // Define the ILogger interface
    public interface ILogger
    {
        void Log(string message);
    }

    // Singleton Logger class implementing the ILogger interface
    public class LazyLogger : ILogger
    {
        // This simplifies the code and ensures lazy instantiation without the need for explicit double-check locking
        private static readonly Lazy<LazyLogger> LazyInstance = new Lazy<LazyLogger>(() => new LazyLogger());

        public static LazyLogger Instance => LazyInstance.Value;

        // Private constructor to prevent external instantiation
        private LazyLogger() { }

        // Log method to log a message
        public void Log(string message)
        {
            // Replace this line with actual logging code
            Console.WriteLine($"Logged message: {message}");
        }
    }
    #endregion
}

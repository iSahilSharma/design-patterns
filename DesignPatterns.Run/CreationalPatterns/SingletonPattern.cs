using System;

namespace DesignPatterns.CreationalPatterns.SingletonPattern
{
       // Define the ILogger interface
       public interface ILogger
       {
              void Log(string message);
       }

       #region Approach One (without Lazy operator)
       // Singleton Logger class implementing the ILogger interface
       public class Logger : ILogger
       {
              // Private static instance variable
              private static Logger _instance = null;

              // Private object for locking during instance creation
              private static readonly object lockObject = new object();

              // Private constructor to prevent external instantiation
              private Logger() { }

              // Public static method to access the Singleton instance
              public static Logger GetInstance()
              {
                     if (_instance == null)
                     {
                            lock (lockObject)
                            {
                                   // Double-check locking to ensure thread safety
                                   if (_instance == null)
                                   {
                                          _instance = new Logger();
                                   }
                            }
                     }

                     return _instance;
              }

              // Log method to log a message
              public void Log(string message)
              {
                     // Replace this line with actual logging code
                     Console.WriteLine($"Logged message: {message}");
              }
       }
       #endregion

       #region Approach Two (with Lazy operator)
       // Singleton Logger class implementing the ILogger interface
       public class LazyLogger : ILogger
       {
              //This simplifies the code and ensures lazy instantiation without the need for explicit double-check locking
              private static readonly Lazy<LazyLogger> lazyInstance = new Lazy<LazyLogger>(() => new LazyLogger());

              public static LazyLogger Instance => lazyInstance.Value;

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

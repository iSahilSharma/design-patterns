using System;

namespace DesignPatterns.StructuralPatterns.DecoratorPattern
{
    // Step 1: Define the base interface for logging
    public interface ILogger
    {
        void Log(string message);
    }

    // Step 2: Create a concrete component implementing the base interface
    public class DefaultLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Default logger - log message.");
        }
    }

    // Step 3: Define the abstract decorator class implementing the base interface
    public abstract class LoggerDecorator : ILogger
    {
        protected ILogger _logger;

        public LoggerDecorator(ILogger logger)
        {
            _logger = logger;
        }

        // This method forwards the log operation to the wrapped logger
        public virtual void Log(string message)
        {
            _logger.Log(message);
        }
    }

    // Step 4: Create concrete decorators for specific logging purposes
    public class AuthenticationLogger : LoggerDecorator
    {
        public AuthenticationLogger(ILogger logger) : base(logger) { }

        // Override the Log method to add authentication-related log information
        public override void Log(string message)
        {
            base.Log($"[AUTH] {message}");
        }
    }

    public class DataProcessingLogger : LoggerDecorator
    {
        public DataProcessingLogger(ILogger logger) : base(logger) { }

        // Override the Log method to add data processing-related log information
        public override void Log(string message)
        {
            base.Log($"[DATA] {message}");
        }
    }

    // Step 5: Demonstrate the usage of the decorator pattern
    public class TestLogger
    {
        public void EntryPoint()
        {
            // Create a basic logger
            ILogger logger = new DefaultLogger();

            // Log authentication-related messages with an AuthenticationLogger decorator
            logger = new AuthenticationLogger(logger);

            // Log data processing-related messages with a DataProcessingLogger decorator
            logger = new DataProcessingLogger(logger);

            // Log messages (the decorators add [AUTH] and [DATA] prefixes)
            logger.Log("User authenticated successfully.");
            logger.Log("Data processing completed.");
        }
    }
}

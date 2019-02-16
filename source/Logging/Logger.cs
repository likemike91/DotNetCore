using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace DotNetCore.Logging
{
    public class Logger : ILogger
    {
        public Logger(IConfiguration configuration)
        {
            Log = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }

        private Serilog.ILogger Log { get; }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Debug(string message, object data)
        {
            Log.ForContext("@d", data, true).Debug(message);
        }

        public void Error(Exception exception)
        {
            Log.Error(exception, exception.Message);
        }

        public void Error(Exception exception, object data)
        {
            Log.ForContext("@d", data, true).Error(exception, exception.Message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Error(string message, object data)
        {
            Log.ForContext("@d", data, true).Error(message);
        }

        public void Fatal(Exception exception)
        {
            Log.Fatal(exception, exception.Message);
        }

        public void Fatal(Exception exception, object data)
        {
            Log.ForContext("@d", data, true).Fatal(exception, exception.Message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Information(string message, object data)
        {
            Log.ForContext("@d", data, true).Information(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Warning(string message, object data)
        {
            Log.ForContext("@d", data, true).Warning(message);
        }
    }
}

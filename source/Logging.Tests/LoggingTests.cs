using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetCore.Logging.Tests
{
    [TestClass]
    public class LoggingTests
    {
        public LoggingTests()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();

            services.AddSingleton<IConfiguration>(configuration);

            services.AddSingleton<ILogger, Logger>();

            Logger = services.BuildServiceProvider().GetService<ILogger>();
        }

        private object Data { get; } = new { Id = 1, Name = "Name" };

        private ILogger Logger { get; }

        [TestMethod]
        public void Debug()
        {
            Logger.Debug(nameof(Debug));
        }

        [TestMethod]
        public void DebugData()
        {
            Logger.Debug(nameof(DebugData), Data);
        }

        [TestMethod]
        public void ErrorException()
        {
            Logger.Error(new ArgumentNullException());
        }

        [TestMethod]
        public void ErrorExceptionData()
        {
            Logger.Error(new ArgumentNullException(), Data);
        }

        [TestMethod]
        public void ErrorMessage()
        {
            Logger.Error(nameof(ErrorMessage));
        }

        [TestMethod]
        public void ErrorMessageData()
        {
            Logger.Error(nameof(ErrorMessageData), Data);
        }

        [TestMethod]
        public void Fatal()
        {
            Logger.Fatal(new Exception(nameof(Fatal)));
        }

        [TestMethod]
        public void FatalData()
        {
            Logger.Fatal(new Exception(nameof(FatalData)), Data);
        }

        [TestMethod]
        public void Information()
        {
            Logger.Information(nameof(Information));
        }

        [TestMethod]
        public void InformationData()
        {
            Logger.Information(nameof(InformationData), Data);
        }

        [TestMethod]
        public void Warning()
        {
            Logger.Warning(nameof(Warning));
        }

        [TestMethod]
        public void WarningData()
        {
            Logger.Warning(nameof(WarningData), Data);
        }
    }
}

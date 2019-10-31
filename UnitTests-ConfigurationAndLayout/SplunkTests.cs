﻿using System;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;

namespace UnitTests_ConfigurationAndLayout
{
    [TestFixture]
    public class SplunkTests
    {
        [OneTimeSetUp]
        public void TestSetUp()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        [OneTimeTearDown]
        public void TestShutdown()
        {
            LogManager.Flush();
            LogManager.Shutdown();
        }

        private ILogger _logger;

        [Test]
        public void LoadTest()
        {
            Parallel.For(0, 1000, i => {
                _logger.Info($"{i} at {DateTime.Now}");
            });
        }

        [Test]
        public void LogTests()
        {
            for (var i = 0; i < 5; i++) _logger.Warn($"{i} !!! {DateTime.Now} - Confirm visually ");
        }
    }
}
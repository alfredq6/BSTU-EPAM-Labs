using System;
using System.IO;
using Framework.Driver;
using Framework.Logging;
using Framework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Framework.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }
        protected MainPage mainPage;

        [SetUp]
        public void Setter()
        {
            Logger.InitLogger();
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://www.vy.no/en");
            mainPage = new MainPage(Driver);

            Logger.Log.Debug("Navigated to https://www.vy.no/en");
            Logger.Log.Debug("Start test: " + TestContext.CurrentContext.Test.Name + "...");
        }

        [TearDown]
        public void TearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome!=ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = ((ITakesScreenshot)Driver).GetScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Error("Error: " + TestContext.CurrentContext.Result.Message);
            }
            Logger.Log.Info("Test completed");
            DriverSingleton.CloseDriver();
            Logger.Log.Info("Driver closed");
        }
    }
}

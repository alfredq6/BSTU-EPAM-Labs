using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Framework.Driver
{
    class DriverSingleton
    {
        static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                }
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}

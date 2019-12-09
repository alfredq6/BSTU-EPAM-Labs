using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using PageObjectLab.PageModels;

namespace PageObjectLab.Tests
{
    public class Tests
    {
        private IWebDriver _webDriver;

        [SetUp]
        public void Setup()
        {
            _webDriver = new EdgeDriver()
            {
                Url = "https://www.vy.no/en"
            };
        }

        [Test]
        public void CheckMaxDateToChoose()
        {
            var homePage = new HomePage(_webDriver);
            homePage.OpenCalendar();
            homePage.SwitchToLastMonthToChoose();
            var nextDayAfterFourMonth = homePage.GetNextDayInFuture();
            Assert.IsFalse(isEnable(nextDayAfterFourMonth));
        }

        [Test]
        public void CheckPastTimeToChoose()
        {
            var homePage = new HomePage(_webDriver);
            var departuriesViewPage = new DeparturiesViewPage(_webDriver);
            homePage.OpenTimePicker();
            homePage.MidnightTimePicker.Click();
            homePage.ViewDepartureButton.Click();
            //System.Threading.Thread.Sleep(3000);
            departuriesViewPage.EarlierDeparture.Click();
            Assert.IsTrue(departuriesViewPage.DeparturePassedMessage.Displayed && departuriesViewPage.DeparturePassedMessage.Text.Contains("Departure time passed"));
        }

        private bool isEnable(IWebElement element)
        {
            return element.GetAttribute("class").Contains("_42bb7915");
        }

        [TearDown]
        public void QuitDriver()
        {
            _webDriver.Quit();
        }
    }
}
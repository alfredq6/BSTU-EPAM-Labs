using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Pages
{
    class DeparturiesViewPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class='elm-mount-wrapper'][2]/div[1]/div[1]/div[1]/h2[1]")]
        public IWebElement RouteMessage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='itinerary-list-item-button'][1]")]
        public IWebElement FirstDeparture { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='price-list-item price-list-item--local'][1]/button")]
        public IWebElement BuyTicketButton { get; set; }

        public DeparturiesViewPage(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class='itinerary-list-item-button'][1]")));
        }

        public void ChooseFirstDeparture()
        {
            FirstDeparture.Click();
            BuyTicketButton.Click();
        }
    }
}

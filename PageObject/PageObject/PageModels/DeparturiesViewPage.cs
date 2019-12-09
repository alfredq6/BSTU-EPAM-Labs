using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectLab.PageModels
{
    public class DeparturiesViewPage : Page
    {
        public DeparturiesViewPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = ".//*[@class='itinerary-list-item'][1]/button")]
        public IWebElement EarlierDeparture;

        [FindsBy(How = How.XPath, Using = ".//*[@class='itinerary-list-item itinerary-list-item--open']/div[1]/div[2]/p[1]")]
        public IWebElement DeparturePassedMessage;
        
    }
}

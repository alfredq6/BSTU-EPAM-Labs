using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class SearchResultPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class='elm-mount-wrapper']/div[1]/div[1]/div[2]/h3[1]")]
        public IWebElement ErorMessage { get; set; }

        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class='elm-mount-wrapper']/div[1]/div[1]/div[2]/h3[1]")));
        }
    }
}

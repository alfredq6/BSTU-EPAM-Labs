using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Pages
{
    class RedirectLoginPage : AbstractPage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@class='elm-mount-wrapper']/div[1]/div[1]/h2[1]")]
        public IWebElement LoginLabel { get; set; }

        public RedirectLoginPage(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath(".//*[@class='elm-mount-wrapper']/div[1]/div[1]/h2[1]")));
        }
    }
}

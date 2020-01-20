using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework.Pages
{
    class LoginPage : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "missing-password-error-message")]
        public IWebElement RememberPasswordMessage { get; set; }

        [FindsBy(How = How.Id, Using = "missing-email-error-message")]
        public IWebElement RememberEmailMessage { get; set; }

        [FindsBy(How = How.Id, Using = "kc-login")]
        public IWebElement LoginButton { get; set; }

        public LoginPage(IWebDriver driver) : base(driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.ClassName("login-pf-header")));
        }
    }
}

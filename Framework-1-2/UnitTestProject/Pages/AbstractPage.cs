using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;

        [FindsBy(How = How.TagName, Using = "body")]
        public IWebElement Body { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='headroom-wrapper']/div[1]/header[1]/div[1]/aside[1]/button[1]")]
        public IWebElement SearchNavButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='app-mount-point-for-header']/div[5]/form[1]/div[1]/button[1]")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='headroom-wrapper']/div[1]/header[1]/div[1]/aside[1]/span[1]/button[1]")]
        public IWebElement LoginNavButton { get; set; }

        public AbstractPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public IWebElement GetWebElement(string xPath)
        {
            return driver.FindElement(By.XPath(xPath));
        }
    }
}

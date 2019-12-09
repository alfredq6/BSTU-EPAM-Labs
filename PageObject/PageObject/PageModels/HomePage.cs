using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace PageObjectLab.PageModels
{
    public class HomePage : Page
    {
        [FindsBy(How = How.Id, Using = "TP-departureStation")]
        public IWebElement WhereFromInput;

        [FindsBy(How = How.Id, Using = "TP-arrivalStation")]
        public IWebElement WhereToInput;

        [FindsBy(How = How.Id, Using = "TP-departureDatePickerIDStage1")]
        public IWebElement CalendarInput;

        [FindsBy(How = How.Id, Using = "TP-outboundTime")]
        public IWebElement TimePicker;

        [FindsBy(How = How.XPath, Using = ".//*[@class='row travel-planner-container']/div[1]/form[1]/div[1]/div[3]/div[4]/button")]
        public IWebElement ViewDepartureButton;

        [FindsBy(How = How.XPath, Using = ".//*[@class='row travel-planner-container']/div[1]/form[1]/div[1]/div[3]/div[2]/span[1]/span[1]/span[1]/div[2]/div[1]/div[3]/button")]
        public IWebElement NextMonthButton;


        [FindsBy(How = How.Id, Using = ".//*[@id='TP-outboundTime']/option")]
        public IWebElement MidnightTimePicker;

        public HomePage(IWebDriver driver) : base(driver) { }

        public void OpenCalendar()
        {
            WhereFromInput.Click();
            CalendarInput.Click();
        }

        public void OpenTimePicker()
        {
            WhereFromInput.SendKeys("Oslo S");
            WhereToInput.SendKeys("Ski");
            Body.Click();
            Body.Click();
            TimePicker.Click();
        }

        public IWebElement GetNextDayInFuture()
        {
            return GetWebElement($".//*[@class='allDays']//button[text()='{DateTime.Now.AddDays(1).Day}']");
        }

        public void SwitchToLastMonthToChoose()
        {
            for (int i = 0; i < 4; i++)
                NextMonthButton.Click();
        }
    }
}

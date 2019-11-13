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

        public IWebElement GetMidnightTime()
        {
            return GetWebElement(".//*[@id='TP-outboundTime']/option");
        }

        public IWebElement GetSubmitButton()
        {
            return GetWebElement(".//*[@class='_bcaf5336 _d49aa3d6']");
        }

        public void SwitchToLastMonthToChoose()
        {
            var nexMonthButton = GetWebElement(".//*[@class='_65dc714d']");
            for (int i = 0; i < 4; i++)
                nexMonthButton.Click();
        }
    }
}

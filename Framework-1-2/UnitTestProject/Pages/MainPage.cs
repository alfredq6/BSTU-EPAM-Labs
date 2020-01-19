using Framework.Models;
using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using UnitTestProject.Extensions;

namespace Framework.Pages
{
    public class MainPage : AbstractPage
    {
        [FindsBy(How = How.Id, Using = "TP-departureStation")]
        public IWebElement DepartureCity { get; set; }

        [FindsBy(How = How.Id, Using = "TP-arrivalStation")]
        public IWebElement ArrivalCity { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='submitTravelPlanner']/h2")]
        public IWebElement DepartureErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='center']/div[1]/div[2]/div[1]/form[1]/div[1]/div[3]/div[3]/ul[1]/li[1]/span[1]/button[2]")]
        public IWebElement AdultIncrementButton { get; set; }

        [FindsBy(How = How.Id, Using = "TP-errorAdult")]
        public IWebElement ErrorAdultMessage { get; set; }

        [FindsBy(How = How.Id, Using = ".//*[@id='TP-outboundTime']/option[1]")]
        public IWebElement MidnightTimePicker { get; set; }

        [FindsBy(How = How.Id, Using = "TP-departureDatePickerIDStage1")]
        public IWebElement CalendarInput { get; set; }

        [FindsBy(How = How.Id, Using = "TP-outboundTime")]
        public IWebElement TimePicker { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='row travel-planner-container']/div[1]/form[1]/div[1]/div[3]/div[4]/button")]
        public IWebElement ViewDepartureButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@class='row travel-planner-container']/div[1]/form[1]/div[1]/div[3]/div[2]/span[1]/span[1]/div[1]/div[2]/div[1]/div[2]/button")]
        public IWebElement NextMonthButton { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='center']/div[1]/div[2]/div[1]/form[1]/div[1]/div[3]/div[3]/ul[1]/li[1]/span[1]/button[2]")]
        public IWebElement IncrementPassangersNumberButton { get; set; }

        [FindsBy(How = How.Id, Using = "TP-errorAdult")]
        public IWebElement IncrementPassangersErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "addCustomerCardButton")]
        public IWebElement AddCustomerCardButton { get; set; }

        [FindsBy(How = How.Id, Using = "customerCardField1")]
        public IWebElement CustomerCardInput { get; set; }

        [FindsBy(How = How.Id, Using = "customerCardField1ErrorMessage")]
        public IWebElement CustomerCardField1ErrorMessage { get; set; }

        [FindsBy(How = How.Id, Using = "submitTravelPlanner")]
        public IWebElement SubmitTravelPlannerMessages { get; set; }

        public Route route { get; set; }
        public MainPage(IWebDriver driver) : base(driver)
        {
        }
        
        public void OpenTimePicker()
        {
            FillRouteWithoutDate();
            Body.Click(2);
            TimePicker.Click();
        }

        public void FillRouteWithoutDate()
        {
            route = RouteCreator.WithoutDate();
            DepartureCity.SendKeys(route.DepartureCity);
            ArrivalCity.SendKeys(route.ArrivalCity);
        }

        public void FillRoute()
        {
            route = RouteCreator.WithAllProperties();
            DepartureCity.SendKeys(route.DepartureCity);
            ArrivalCity.SendKeys(route.ArrivalCity);
            Body.Click(2);
            CalendarInput.Click();
            GetTomorrow().Click();
        }

        public void FillRouteWithSameCities()
        {
            route = RouteCreator.WithSameCities();
            DepartureCity.SendKeys(route.DepartureCity);
            ArrivalCity.SendKeys(route.ArrivalCity);
            Body.Click(2);
        }

        public void FindRoute()
        {
            FillRouteWithoutDate();
            Body.Click(2);
            ViewDepartureButton.Click();
        }

        public void SearchEmpty()
        {
            SearchNavButton.Click();
            SearchButton.Click();
        }

        public void IncrementToNinePassanger()
        {
            Body.Click(2);
            IncrementPassangersNumberButton.Click(9);
        }

        public void OpenCalendar()
        {
            ArrivalCity.Click();
            CalendarInput.Click();
        }

        public void ChoosePassedDeparture()
        {
            MidnightTimePicker.Click();
            ViewDepartureButton.Click();
        }

        public void EnterCustomerCardNumber(string number)
        {
            DepartureCity.Click();
            Body.Click();
            AddCustomerCardButton.Click();
            CustomerCardInput.SendKeys(number);
        }

        public void TriggerForm()
        {
            ArrivalCity.SendKeys("some text");
            ArrivalCity.Clear();
        }

        public IWebElement GetFourthMonthInFuture()
        {
            NextMonthButton.Click(4);
            return GetWebElement($".//*[@class='row travel-planner-container']/div[1]/form[1]/div[1]/div[3]/div[2]/span[1]/span[1]/div[1]/div[2]/div[2]");
        }

        public IWebElement GetYesterday()
        {
            return GetWebElement($".//*[@class='allDays']//button[text()='{DateTime.Now.AddDays(-1).Day}']");
        }

        public IWebElement GetTomorrow()
        {
            return GetWebElement($".//*[@class='allDays']//button[text()='{DateTime.Now.AddDays(1).Day}']");
        }
    }
}

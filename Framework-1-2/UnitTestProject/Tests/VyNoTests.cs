using System;
using System.IO;
using Framework.Driver;
using Framework.Pages;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using UnitTestProject.Extensions;

namespace Framework.Tests
{
    class VyNoTests : TestConfig
    {
        [Test]
        [Category("DateTest")]
        public void CheckMaxDateToChoose()
        {
            mainPage.OpenCalendar();
            var nextFourMonth = mainPage.GetFourthMonthInFuture();

            Assert.IsTrue(nextFourMonth.Text.Contains("Travel suggestions are available 120 days prior to departure. Tickets are available 90 days prior to departure."));
        }

        [Test]
        [Category("SearchTest")]
        public void CheckFindingRoutesWithEmptyFields()
        {
            mainPage.TriggerForm();

            Assert.IsTrue(mainPage.ViewDepartureButton.IsButtonDisabled());
        }

        [Test]
        [Category("DateTest")]
        public void CheckPastDayToChoose()
        {
            mainPage.OpenCalendar();

            Assert.IsTrue(mainPage.GetYesterday().IsDayDisabled());

        }

        [Test]
        [Category("DepartureSettingTest")]
        public void CheckPassangerMaxNumber()
        {
            mainPage.FillRouteWithoutDate();
            mainPage.IncrementToNinePassanger();

            Assert.IsTrue(mainPage.IncrementPassangersNumberButton.IsButtonDisabled()
                && mainPage.IncrementPassangersErrorMessage.Displayed
                && mainPage.IncrementPassangersErrorMessage.Text.Contains("It is only possible to book for up to 9 passengers online. For group travel, please contact customer service at"));
        }

        [Test]
        [Category("SearchTest")]
        public void CheckEmptySearch()
        {
            mainPage.SearchEmpty();
            var searchPage = new SearchResultPage(Driver);

            Assert.IsTrue(searchPage.ErorMessage.Text.Contains("Ooops"));
        }

        [Test]
        [Category("UserTest")]
        public void CheckLoginEmpty()
        {
            mainPage.LoginNavButton.Click();
            var loginPage = new LoginPage(Driver);
            loginPage.LoginButton.Click();
            Assert.IsTrue(loginPage.RememberEmailMessage.Displayed
                && loginPage.RememberPasswordMessage.Displayed);
        }

        [Test]
        [Category("RouteTest")]
        public void CheckRouteCorrectable()
        {
            mainPage.FindRoute();
            var departureViewPage = new DeparturiesViewPage(Driver);
            Assert.IsTrue(departureViewPage.RouteMessage.Text.Contains(mainPage.route.ArrivalCity)
                && departureViewPage.RouteMessage.Text.Contains(mainPage.route.DepartureCity));
        }

        [Test]
        [Category("DepartureSettingTest")]
        public void CheckCustomerCardNumberLength()
        {
            mainPage.EnterCustomerCardNumber("123213bhsjfdsa");

            Assert.IsTrue(mainPage.CustomerCardField1ErrorMessage.Displayed
                && mainPage.SubmitTravelPlannerMessages.Text.Contains("A customer card number is wrong."));
        }

        [Test]
        [Category("UserTest")]
        public void CheckBuyingTickectByUnloggedUser()
        {
            mainPage.FillRoute();
            mainPage.ViewDepartureButton.Click();
            var departureViewPage = new DeparturiesViewPage(Driver);
            departureViewPage.ChooseFirstDeparture();
            var redirectLoginPage = new RedirectLoginPage(Driver);

            Assert.IsTrue(redirectLoginPage.LoginLabel.Displayed);
        }

        [Test]
        [Category("RouteTest")]
        public void CheckSameDepartureAndArrivalCities()
        {
            mainPage.FillRouteWithSameCities();

            Assert.IsTrue(mainPage.SubmitTravelPlannerMessages.Displayed
                && mainPage.ViewDepartureButton.IsButtonDisabled()
                && mainPage.SubmitTravelPlannerMessages.Text.Contains("The departure and arrival station cannot be the same."));
        }
    }
}

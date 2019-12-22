using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Extensions
{
    public static class WebElementExtension
    {
        public static bool IsDayDisabled(this IWebElement btn)
        {
            return btn.GetCssValue("color").Contains("#D2D4D2") || btn.GetCssValue("color").Contains("rgba(210, 212, 210, 1)") || btn.GetCssValue("color").Contains("rgb(210, 212, 210)");
        }

        public static bool IsButtonDisabled(this IWebElement btn)
        {
            return btn.GetCssValue("background-color").Contains("#EFEFEF") || btn.GetCssValue("background-color").Contains("rgba(239, 239, 239, 1)") || btn.GetCssValue("background-color").Contains("rgb(239, 239, 239)");
        }

        public static void Click(this IWebElement btn, int number)
        {
            for (int i = 0; i < number; i++)
                btn.Click();
        }
    }
}

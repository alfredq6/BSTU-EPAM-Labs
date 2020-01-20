using OpenQA.Selenium;

namespace TestFramework.Extensions
{
    public static class WebElementExtension
    {
        public static bool IsDayDisabled(this IWebElement btn)
        {
            return btn.GetCssValue("color").Contains("#888B8E") || btn.GetCssValue("color").Contains("rgba(136, 139, 142, 1)") || btn.GetCssValue("color").Contains("rgb(136, 139, 142)");
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

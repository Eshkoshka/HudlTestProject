using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HudlLoginTest.PageObject
{
    public class WaitForElement
    {
        public static IWebElement WaitUntil(IWebDriver _driver, By locator, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                return wait.Until(driver => _driver.FindElement(locator));
            }

            return _driver.FindElement(locator);
        }
    }
}

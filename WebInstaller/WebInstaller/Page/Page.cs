using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebInstaller.Driver;

namespace WebInstaller.Page
{
    public class Page
    {
        public Page()
        {
        }

        private const int WAIT_TIME = 60;
        public static bool IsWebElementEnabled(By locator)
        {
            try
            {

                WebDriverWait wait = new WebDriverWait(Driver.Driver.GetwebDriver(), TimeSpan.FromSeconds(WAIT_TIME));
                IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
                return element.Displayed & element.Enabled;
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Exception occurred:" + e.GetBaseException());
            }

            return false;
        }
        public static void SelectWebElement(By locator)
        {
            if (Page.IsWebElementEnabled(locator))
            {
                Driver.Driver.GetwebDriver().FindElement(locator).Click();
            }
            else
            {
                Console.WriteLine("Element is not enabled", locator.ToString());
                throw new ElementNotSelectableException("Not able to click on element");
            }
        }

        public static void NavigateToPage(Uri url) => Driver.Driver.GetwebDriver().Navigate().GoToUrl(url);

    }
}


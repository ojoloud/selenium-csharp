
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace WebInstaller.Driver
{
    public class Driver
    {
        public static IWebDriver GetwebDriver()
        {
            return driver;
        }
        private static IWebDriver driver;
        public Driver()
        {

        }

        public static IWebDriver initDriver()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddUserProfilePreference("download.default_directory", @"C:\temp\");
                //System.Configuration.ConfigurationManager.AppSettings.Get("fileDownloadPath"));
                options.AddArgument("headless");
                driver = new ChromeDriver(options);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred:" + e.Message);
            }
            return driver;
        }

        public static void maximizeWindows()
        {
            Driver.driver.Manage().Window.Maximize();

        }

        public static void closeDriver()
        {
            Driver.driver.Close();
        }
        public static void QuitDriver()
        {
            Driver.driver.Quit();
        }

    }
}


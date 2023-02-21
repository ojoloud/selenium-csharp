using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WebInstaller.Driver;

namespace WebInstaller.Pages
{
    public class AlternativeInstallationOptions : Page.Page
    {
        private static By AlternativeOptionsLink = By.XPath("//*[contains(text(), \"Alternative installation options\")]");
        private static By WebInstallerLink = By.XPath("//*[contains(text(), \"Web installer\")]");
        private static String WEB_URL = "http://emsisoft.com/en/anti-malware-home";
        private static string? fileFullPath = @"c:\tmp\" + WEB_URL;
        private static readonly String WEB_INSTALLER_EXEC = "EmsisoftAntiMalwareWebSetup.exe";


        public AlternativeInstallationOptions()
        {
        }

        public static void GoToAlternativeOptions()
        {
            Page.Page.SelectWebElement(AlternativeOptionsLink);

        }
        public static void DownloadWebInstaller()
        { 
            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }
            Page.Page.NavigateToPage(new Uri(WEB_URL));
            Page.Page.SelectWebElement(AlternativeOptionsLink);
            Page.Page.SelectWebElement(WebInstallerLink);
            System.Threading.Thread.Sleep(30);

            Assert.IsTrue(File.Exists(fileFullPath));
        }


        static void Main(string[] args)
        {
            IWebDriver _driver = Driver.Driver.initDriver();
            AlternativeInstallationOptions.DownloadWebInstaller();
        }
    }

}
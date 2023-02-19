using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace WebInstaller
{
    class Program
    {
        static void Main(string[] args)
        {
            string DOWNLOAD_URL = "http://emsisoft.com/en/anti-malware-home";
            String downloadFolder = @"c:\temp\";
            String fileFullPath = downloadFolder + "EmsisoftAntiMalwareWebSetup.exe";
            if (File.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }

            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", downloadFolder);
            options.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(DOWNLOAD_URL);
            driver.FindElement(By.XPath("//*[contains(text(), \"Alternative installation options\")]")).Click();
            driver.FindElement(By.XPath("//*[contains(text(), \"Web installer\")]")).Click();
            System.Threading.Thread.Sleep(30);

            Assert.IsTrue(File.Exists(fileFullPath));

        }
    }


}

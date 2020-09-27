using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Configuration;
using OpenQA.Selenium.Firefox;
using Protractor;

namespace ProtractorFramework.Base
{
    public class DriverProvider : IDisposable
    {
        private static DriverProvider driverProvider;
        private IWebDriver driver;
        public static BrowserType browserType;
        private NgWebDriver ngdriver;

        private DriverProvider(BrowserType browser)
        {
            if (browser == BrowserType.IE)
            {
                InternetExplorerOptions ieoptions = new InternetExplorerOptions();
                ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                ieoptions.RequireWindowFocus = true;
                ieoptions.IgnoreZoomLevel = true;
                //ieoptions.BrowserCommandLineArguments = "-private";
                // ieoptions.ForceCreateProcessApi = true;
                ieoptions.EnableNativeEvents = true;
                ieoptions.EnsureCleanSession = true;
                driver = new InternetExplorerDriver(@"D:\Selenium", ieoptions);
                driver.Manage().Window.Maximize();
            }
            else
            if (browser == BrowserType.Firefox)
            {
                driver = new FirefoxDriver();
            }

            ngdriver = new NgWebDriver(driver);
        }
        public static IWebDriver getDriver()
        {
            BrowserType browserType = (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationSettings.AppSettings["BrowserType"], true);

            if (driverProvider == null)
            {
                driverProvider = new DriverProvider(browserType);

            }
            return driverProvider.driver;
        }






        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                driver.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

using System;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProtractorFramework.Base;
using ProtractorFramework.Page;
using Protractor;

namespace ProtractorFramework
{
    [TestClass]
    public class UnitTest1
    {
        private static IWebDriver driver;
        private HomePage homepage = new HomePage();
        [ClassInitialize]
        public static void initializeBrowser(TestContext e)
        {
            driver = DriverProvider.getDriver();
        }

        [TestMethod]
        public void Search()
        {
            NgWebDriver ngdriver = new NgWebDriver(driver);
            driver.Navigate().GoToUrl("https://weather.com/");
            ngdriver.Url = driver.Url;
            homepage.SearchText();
        }

        [ClassCleanup]
        public static void Destroy()
        {
            driver.Dispose();
        }
    }
}

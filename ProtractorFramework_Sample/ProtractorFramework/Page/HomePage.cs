using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using ProtractorFramework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protractor;

namespace ProtractorFramework.Page
{
    class HomePage
    {
        private IWebDriver driver;
        private NgWebDriver ngdriver;
        public HomePage()
        {
            driver = DriverProvider.getDriver();
            ngdriver = new NgWebDriver(driver);
        }

        public void SearchText()
        {
            IWebElement searchbox = ngdriver.FindElement(By.ClassName("input--search"));
            searchbox.Click();
            searchbox.SendKeys("New York, NY");
            searchbox.SendKeys(Keys.Tab);
            searchbox.SendKeys(Keys.Enter);

            Thread.Sleep(10000);

            NgWebElement ng_account_number_element = ngdriver.FindElement(NgBy.Binding("location.label"));
            Assert.Equals("New York, NY", ng_account_number_element.Text.ToString());

        }
    }


}


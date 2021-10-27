﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {

       
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL): base(driver)
        {
            this.baseURL = baseURL;
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenHomePage()
        {

            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void InintGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }


    }
}

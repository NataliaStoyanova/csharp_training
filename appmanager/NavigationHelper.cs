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

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public NavigationHelper GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
            return this;
        }
        public NavigationHelper GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public NavigationHelper GoToContactsPage()
        {
            return GoToHomePage();
        }

        public NavigationHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}

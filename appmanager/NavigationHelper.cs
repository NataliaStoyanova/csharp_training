using System;
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
            //driver.FindElement(By.LinkText("add new")).Click();
            //return this;
            return GoToHomePage();
        }

        public NavigationHelper GoToHomePageContactsTable()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[2]")).Click();
            return this;
        }

        public NavigationHelper InitContactModification(int i)
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/edit.php?id="+ i );
            return this;
        }
    }
}

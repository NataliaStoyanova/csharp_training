using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {
    
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {

            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");       
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/addressbook/group.php" && IsElementPresent(By.Name("new")))
                    
                    {
                        return;
                    }

            driver.FindElement(By.LinkText("groups")).Click();
            
        }

        public void GoToContactsPage()
        {
            if (driver.Url == baseURL + "/addressbook/" && IsElementPresent(By.Id("maintable")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public NavigationHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

    }
}

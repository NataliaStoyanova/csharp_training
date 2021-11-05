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
    public class LoginHelper : HelperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Login(AccountData account)
        {
            if (isLoggedIn())
            {
                if (isLoggedIn(account))
                    {
                        return;
                    }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"Submit\"]")).Click(); 
           
        }
        public void Logout()
        {
            if (isLoggedIn()) 
            {
                driver.FindElement(By.LinkText("logout")).Click();
            }
       
        }

        public bool isLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }
        public bool isLoggedIn(AccountData account)
        {
            return isLoggedIn() && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text == "(" + account.Username + ")";
        }
    }
}

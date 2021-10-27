using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

//Application namager is responsible for the Interface 
//responsible for interaction with the test application

namespace WebAddressbookTests
{
    public class ApplicationManager

    {
        protected IWebDriver driver;
        protected string baseURL;

        private LoginHelper loginHelper;
        private NavigationHelper navigator;
        private GroupHelper groupHelper;

        public LoginHelper LoginHelper { get => loginHelper; set => loginHelper = value; }
        public NavigationHelper Navigator { get => navigator; set => navigator = value; }
        public GroupHelper GroupHelper { get => groupHelper; set => groupHelper = value; }

        public ApplicationManager()
        {
            LoginHelper = new LoginHelper(driver);
            Navigator = new NavigationHelper(driver, baseURL);
            GroupHelper = new GroupHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }



    }
}

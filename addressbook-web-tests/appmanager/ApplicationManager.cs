using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;


        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;


        //This is the unique instance of ApplicationManager class and to ensure is's uniqueness AppManager constructor is set private
        //private static ApplicationManager instance;

        //ThreadLocal<ApplicationManager> is a special objects that defines the mapping between the current thread and the instance of ApplicationManager 
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        public LoginHelper Auth { get => loginHelper; }
        public NavigationHelper Navigator { get => navigator; }
        public GroupHelper GroupHelper { get => groupHelper; }
        public ContactHelper ContactHelper { get => contactHelper; }

        public IWebDriver Driver { get => driver; }


        //no one outside ApplicatinManager class must not create other instances 
        private ApplicationManager()
        {

            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigator = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        //method Stop moved in destructor 
        ~ApplicationManager()
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

        //Singletone
        //this is statis method => it is global and can be called ApplicationManager.GetInstance
        //should return an instance of ApplicationManager object, which instance?
        //we construct AppManger in GetInstance() only if it hasn't been created yet
        /* public static ApplicationManager GetInstance()
         {
             if (instance == null)
             {
                 instance = new ApplicationManager();
             }
             return instance;
         }*/

        //GetInstance returns different instances for different threads 
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();               
                newInstance.Navigator.GoToHomePage();
                app.Value = newInstance;
            }
            return app.Value;
        }

    }
}

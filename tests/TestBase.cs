using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
//TestBase is responsible for intialisation and for stopping the brawser 

namespace WebAddressbookTests
{
    public class TestBase
    {
   
        //protected bool acceptNextAlert = true;
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();

            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            //driver = new FirefoxDriver();
            //baseURL = "http://localhost";
            //verificationErrors = new StringBuilder();          
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

    }
}

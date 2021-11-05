using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        //public static ApplicationManager app;
        //this way we cannot run our tests in parallel, we cannot work with the same brawser in several parallel threads

        [SetUp]
        public void InitApplicationManger()
        {
            //Singletone
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}

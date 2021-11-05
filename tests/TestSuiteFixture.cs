using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

//This Global Fixture will not be used futher.
//will leave it here for info

/*
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
           
        }

    }
}
*/
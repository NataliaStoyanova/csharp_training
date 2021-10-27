using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
//The type of browser and test application communication interface (Selenium) is hidden
//In tests we only store the test logic

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {

            app = new ApplicationManager();

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

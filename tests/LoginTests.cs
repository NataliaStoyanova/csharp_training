using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests :TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //steps
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.isLoggedIn(account));

        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            //prepare
            app.Auth.Logout();

            //steps
            AccountData account = new AccountData("admin", "secrrret");
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.isLoggedIn(account));

        }

    }
}

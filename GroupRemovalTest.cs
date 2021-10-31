using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


//Responsibility is shared. Tests do only testing. In future if the app changes we do not need to change the test, only change the supporting helpers

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests :TestBase
    {
       
        [Test]
        public void GroupRemovalTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupsPage();
        }

    }
}

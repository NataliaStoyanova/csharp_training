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
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.LoginHelper.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Navigator.InintGroupCreation();
            GroupData group = new GroupData("group1");
            group.Group_header = "header1";
            group.Group_footer = "footer1";
            app.GroupHelper.FillGroupForm(group);
            app.GroupHelper.SubmitNewGroup();
            app.Navigator.ReturnToGroupsPage();
        }
     
    }
}

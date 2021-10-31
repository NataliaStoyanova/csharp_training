using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests :TestBase
    {
     
        [Test]
        public void GroupCreationTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.InintGroupCreation();
            GroupData group = new GroupData("group1");
            group.Group_header = "header1";
            group.Group_footer = "footer1";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitNewGroup();
            groupHelper.ReturnToGroupsPage();
        }

    }
}

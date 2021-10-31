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
            app.Navigator.GoToGroupsPage();       
            GroupData group = new GroupData("group1");
            group.Group_header = "header1";
            group.Group_footer = "footer1";

            app.GroupHelper
                .InintGroupCreation()
                .FillGroupForm(group)
                .SubmitNewGroup()
                .ReturnToGroupsPage();
        }

        public void EmptyGroupCreationTest()
        {
            app.Navigator.GoToGroupsPage();
            GroupData group = new GroupData("");
            group.Group_header = "";
            group.Group_footer = "";

            app.GroupHelper
                .InintGroupCreation()
                .FillGroupForm(group)
                .SubmitNewGroup()
                .ReturnToGroupsPage();
        }

    }
}

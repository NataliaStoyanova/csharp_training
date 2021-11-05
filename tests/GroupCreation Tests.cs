using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     
        [Test]
        public void GroupCreationTest()
        {
   
            GroupData group = new GroupData("group1");
            group.Group_header = "header1";
            group.Group_footer = "footer1";

            app.GroupHelper.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            
            GroupData emptygroup = new GroupData("");
            emptygroup.Group_header = "";
            emptygroup.Group_footer = "";

            app.GroupHelper.Create(emptygroup);
        }

    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     
        [Test]
        public void GroupCreationTest()
        {
   
            GroupData group = new GroupData("group3");
            group.Group_header = "header3";
            group.Group_footer = "footer3";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
        
            app.GroupHelper.Create(group);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            oldGroups.Add(group);


            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            
            GroupData emptygroup = new GroupData("");
            emptygroup.Group_header = "";
            emptygroup.Group_footer = "";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(emptygroup);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            oldGroups.Add(emptygroup);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }

       /*
        [Test]
        public void InvalidNameGroupCreationTest()
        {

            GroupData emptygroup = new GroupData("a'a");
            emptygroup.Group_header = "";
            emptygroup.Group_footer = "";

            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

            app.GroupHelper.Create(emptygroup);

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();

            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
       */
    }
}

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
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {

            List<GroupData> oldGroups = null;


            if (app.GroupHelper.DoesTheGroupExist(0))

            {
                oldGroups = app.GroupHelper.GetGroupList();               
            }
            else
            {
                GroupData group = new GroupData("group1");
                group.Group_header = "header1";
                group.Group_footer = "footer1";
                app.GroupHelper.Create(group);
                oldGroups = app.GroupHelper.GetGroupList();
            }
            GroupData newdata = new GroupData("groupM");
            newdata.Group_header = null;
            newdata.Group_footer = null;
            app.GroupHelper.ModifyGroup(0, newdata);

            Assert.AreEqual(oldGroups.Count, app.GroupHelper.GetGroupCount());


            oldGroups[0].Group_name = newdata.Group_name;          
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();         
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
       
        }


    }
}

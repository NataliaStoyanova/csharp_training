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
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            List<GroupData> oldGroups = null;
            GroupData oldData = null;
            if (app.GroupHelper.DoesTheGroupExist(0))
            {
                oldGroups = app.GroupHelper.GetGroupList();
                oldData = oldGroups[0];
            }
            else
            {
                GroupData group = new GroupData("group1");
                group.Group_header = "header1";
                group.Group_footer = "footer1";
                app.GroupHelper.Create(group);
                oldGroups = app.GroupHelper.GetGroupList();
                oldData = oldGroups[0];
            }
            GroupData newdata = new GroupData("groupM");
            newdata.Group_header = null;
            newdata.Group_footer = null;
            app.GroupHelper.ModifyGroup(0, newdata);
            Assert.AreEqual(oldGroups.Count, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups[0].Group_name = newdata.Group_name;                      
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.id == oldData.id)
                {
                    Assert.AreEqual(newdata.Group_name, group.Group_name);                
                }
            }      
        }

        [Test]
        public void GroupModificationTestDB()
        {
            List<GroupData> oldGroups = null;
            GroupData oldData = null;
            if (app.GroupHelper.DoesTheGroupExist(0))
            {
                oldGroups = GroupData.GetAllGroupsFromDB();
                oldData = oldGroups[0];
            }
            else
            {
                GroupData group = new GroupData("group1");
                group.Group_header = "header1";
                group.Group_footer = "footer1";
                app.GroupHelper.Create(group);
                oldGroups = GroupData.GetAllGroupsFromDB();
                oldData = oldGroups[0];
            }
            GroupData newdata = new GroupData("groupM");
            newdata.Group_header = null;
            newdata.Group_footer = null;
            app.GroupHelper.ModifyGroupID(oldData, newdata);
            
            Assert.AreEqual(oldGroups.Count, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAllGroupsFromDB();
            oldGroups[0].Group_name = newdata.Group_name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.id == oldData.id)
                {
                    Assert.AreEqual(newdata.Group_name, group.Group_name);
                }
            }
        }
    }
}

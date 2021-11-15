using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;


//Responsibility is shared. Tests do only testing. In future if the app changes we do not need to change the test, only change the supporting helpers

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
       
        [Test]
        public void GroupRemovalTest()
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
            app.GroupHelper.RemoveGroup(0);

            Assert.AreEqual(oldGroups.Count -1, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}

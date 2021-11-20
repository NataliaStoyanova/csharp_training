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
        //this method must be static for the random test data to be generated on the compilation stage
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        { 
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(15))
                {
                    Group_header = GenerateRandomString(10),
                    Group_footer = GenerateRandomString(10)
                });           
            }

            return groups;        
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {   
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
        
            app.GroupHelper.Create(group);
           
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(group);
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

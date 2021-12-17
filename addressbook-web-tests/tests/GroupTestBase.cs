using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroups_UI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = app.GroupHelper.GetGroupList();
                List<GroupData> fromDB = GroupData.GetAllGroupsFromDB();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }
        }
     }
}

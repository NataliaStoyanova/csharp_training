using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newdata = new GroupData("groupM");
            newdata.Group_header = null;
            newdata.Group_footer = null;
            app.GroupHelper.ModifyGroup(1, newdata);
        }


    }
}

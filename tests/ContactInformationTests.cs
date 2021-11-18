using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = app.ContactHelper.GetContactInfoFromTable(0);
            ContactData fromForm = app.ContactHelper.GetContactInfoFromForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);

            Assert.AreEqual(fromTable.Address, fromForm.Address);

            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

    }
}

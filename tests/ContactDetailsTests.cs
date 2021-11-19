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
    public class ContactDetailsTests : AuthTestBase
    {
        [Test]
        public void ContactDetailsTest()
        {
            var fromDetails = app.ContactHelper.GetContactDetails(0);
            var fromForm = app.ContactHelper.GetContactInfoFromForm(0);
            
            //verification                
            Assert.AreEqual(fromDetails, fromForm.AllDetails);
        }

    }
}


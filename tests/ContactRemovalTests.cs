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
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacs;
            
            if (app.ContactHelper.DoesTheContactExist(0))
            {
                oldContacs = app.ContactHelper.GetContactList();                
            }
            else
            {
                ContactData contact = new ContactData("ContactNew");
                contact.Lastname = "ContactNew";
                contact.Mobile = "ContactNew";
                app.ContactHelper.Create(contact);
                oldContacs = app.ContactHelper.GetContactList();
               
            }
            app.ContactHelper.RemoveContact(0);

            //Fast check using hash
            Assert.AreEqual(oldContacs.Count-1, app.ContactHelper.GetContactCount());

            //Slow check
            List<ContactData> newContacs = app.ContactHelper.GetContactList();
            oldContacs.RemoveAt(0);
            oldContacs.Sort();
            newContacs.Sort();
            Assert.AreEqual(oldContacs, newContacs);
        }

    }
}

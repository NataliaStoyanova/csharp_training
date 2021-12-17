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
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacs;
            
            if (app.ContactHelper.DoesTheContactExist(0))
            {
                oldContacs = ContactData.GetAllContactsFromDB();
            }
            else
            {
                ContactData contact = new ContactData("ContactNew");
                contact.Lastname = "ContactNew";
                contact.Mobile = "ContactNew";
                app.ContactHelper.Create(contact);
                oldContacs = ContactData.GetAllContactsFromDB();
            }

            ContactData contactTobeRemoved = oldContacs[0];
            app.ContactHelper.RemoveContactID(contactTobeRemoved);

            //Fast check using hash
            Assert.AreEqual(oldContacs.Count-1, app.ContactHelper.GetContactCount());

            //Slow check
            List<ContactData> newContacs = ContactData.GetAllContactsFromDB();

            

            oldContacs.RemoveAt(0);
            oldContacs.Sort();
            newContacs.Sort();
            Assert.AreEqual(oldContacs, newContacs);

            foreach (ContactData contact in newContacs)
            {
                Assert.AreNotEqual(contact.id, contactTobeRemoved.id);
            }
        }

    }
}

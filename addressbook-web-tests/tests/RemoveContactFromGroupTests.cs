using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace WebAddressbookTests
{
    
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemoveContactToGroupTest() 
        
        {
            //take a group0 from DB(index 0)
            GroupData group = GroupData.GetGroupsFromDB()[0];

            //select contacts that belong to that group0
            List<ContactData> oldcontacts = group.GetContactsFromDB();

           
            ContactData contact = oldcontacts.First();

            app.ContactHelper.RemoveContactFromGroup(contact, group);

            //select new contacts that are in group0
            List<ContactData> newcontacts = group.GetContactsFromDB();

            //add new contact to group0
            oldcontacts.Remove(contact);

            //Compare
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);


        }
    }
}

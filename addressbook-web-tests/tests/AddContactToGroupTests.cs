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
    
    public class AddContactToGroupTests : AuthTestBase
    {
        [Test]
        public void AddContactToGroupTest()
        {
            //take a group0 from DB(index 0)
            GroupData group = GroupData.GetGroupsFromDB()[0];
            
            //select contacts that belong to that group0
            List<ContactData> oldcontacts = group.GetContactsFromDB();

            //select 1 contact from a set of contacts that are not in the group0
            ContactData contact = ContactData.GetContactsFromDB().Except(oldcontacts).First();

            app.ContactHelper.AddContactToGroup(contact, group);

            //select new contacts that are in group0
            List<ContactData> newcontacts = group.GetContactsFromDB();
            
            //add new contact to group0
            oldcontacts.Add(contact);

            //Compare
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }
    }
}

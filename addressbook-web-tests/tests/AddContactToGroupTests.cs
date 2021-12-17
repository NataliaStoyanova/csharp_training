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
            List<GroupData> groups = GroupData.GetAllGroupsFromDB();
            if (groups.Count == 0)
            {
                GroupData newgroup = new GroupData("newgroup", "footer", "header");
                app.GroupHelper.Create(newgroup);
            }
            List<ContactData> contacts = ContactData.GetAllContactsFromDB();
            if (contacts.Count == 0)
            {
                ContactData newcontact = new ContactData("NewContactName", "LastName", "058949849849");
                app.ContactHelper.Create(newcontact);
            }
            //take a group0 from DB(index 0)
            GroupData group = GroupData.GetAllGroupsFromDB()[0];            
            //select contacts that belong to that group0
            List<ContactData> oldcontacts = group.GetGroupContactsFromDB();
            //select 1 contact from a set of contacts that are not in the group0
            ContactData contact = ContactData.GetAllContactsFromDB().Except(oldcontacts).First();
            if (contact == null)
            {
                ContactData newcontact = new ContactData("NewContactName", "LastName", "058949849849");
                app.ContactHelper.Create(newcontact);
                contact = ContactData.GetAllContactsFromDB().Except(oldcontacts).First();
            }
            app.ContactHelper.AddContactToGroup(contact, group);
            //select new contacts that are in group0
            List<ContactData> newcontacts = group.GetGroupContactsFromDB();           
            //add new contact to group0
            oldcontacts.Add(contact);
            //Compare
            oldcontacts.Sort();
            newcontacts.Sort();
            Assert.AreEqual(oldcontacts, newcontacts);
        }
    }
}

﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            List<ContactData> oldContacts = null;
            if (app.ContactHelper.DoesTheContactExist(0))

            {
                oldContacts = app.ContactHelper.GetContactList();                
            }
            else
            {
                ContactData newcontact = new ContactData("NewVladislav", "NewStoyanov", "08968756");
                //contact.Firstname = "Natalia";             
                newcontact.Middlename = null;
                //contact.Lastname = "Stoyanova";
                newcontact.Nickname = null;
                newcontact.Photo = null;
                newcontact.Title = null;
                newcontact.Company = null;
                newcontact.Address = null;
                newcontact.Home = null;
                //contact.Mobile = null;
                newcontact.Work = null;
                newcontact.Fax = null;
                newcontact.Email = null;
                newcontact.Email2 = null;
                newcontact.Email3 = null;
                newcontact.Homepage = null;
                newcontact.Bday = null;
                newcontact.Bmonth = null;
                newcontact.Byear = null;
                newcontact.Aday = null;
                newcontact.Amonth = null;
                newcontact.Ayear = null;
                newcontact.Address2 = null;
                newcontact.Phone2 = null;
                newcontact.Notes = null;
                app.ContactHelper.Create(newcontact);
                oldContacts = app.ContactHelper.GetContactList();
            }
            ContactData contactM = new ContactData("MVladislav", "MStoyanov", "08968756");
            //contact.Firstname = "Natalia";             
            contactM.Middlename = null;
            //contact.Lastname = "Stoyanova";
            contactM.Nickname = null;
            contactM.Photo = null;
            contactM.Title = null;
            contactM.Company = null;
            contactM.Address = null;
            contactM.Home = null;
            //contact.Mobile = null;
            contactM.Work = null;
            contactM.Fax = null;
            contactM.Email = null;
            contactM.Email2 = null;
            contactM.Email3 = null;
            contactM.Homepage = null;
            contactM.Bday = null;
            contactM.Bmonth = null;
            contactM.Byear = null;
            contactM.Aday = null;
            contactM.Amonth = null;
            contactM.Ayear = null;
            contactM.Address2 = null;
            contactM.Phone2 = null;
            contactM.Notes = null;
            app.ContactHelper.Modify(0, contactM);
            oldContacts[0].Firstname = contactM.Firstname;
            oldContacts[0].Lastname = contactM.Lastname;
            oldContacts[0].Mobile = contactM.Mobile;
            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}

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
    public class ContactCreationTests : AuthTestBase
    {
       
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();


            ContactData contact = new ContactData("Batalia", "Stoyanova", "08968756");
            //contact.Firstname = "Natalia";             
            contact.Middlename= "Yurieva";
            //contact.Lastname = "Stoyanova";
            contact.Nickname = "Nt_St";
            contact.Photo= @"C:\Users\User\Pictures\images.jpg";
            contact.Title = "Mrs";
            contact.Company = "Soft2Run";
            contact.Address = "Sofia";
            contact.Home = "099345435";
            //contact.Mobile = "08968756";
            contact.Work = "03345346";
            contact.Fax = "9887665";
            contact.Email = "qa.natalia.ruseva@gmail.com";
            contact.Email2 = "qa2.natalia.ruseva@gmail.com";
            contact.Email3 = "qa3.natalia.ruseva@gmail.com";
            contact.Homepage = "https://google.com";
            contact.Bday = "4";
            contact.Bmonth = "July";
            contact.Byear = "1985";
            contact.Aday = "29";
            contact.Amonth = "July";
            contact.Ayear = "2018";
            contact.Address2 = "Tsarevo";
            contact.Phone2 = "09898786";
            contact.Notes = "notes";         
            app.ContactHelper.Create(contact);

            //Fast check using hash
            Assert.AreEqual(oldContacts.Count + 1, app.ContactHelper.GetContactCount());


            //Slow check
            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);            
        }

    }
}

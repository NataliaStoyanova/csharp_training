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

        //this method must be static for the random test data to be generated on the compilation stage
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(15), GenerateRandomString(15), GenerateRandomPhoneNumber())
                {
                    Middlename = GenerateRandomString(10),
                    Nickname = GenerateRandomString(10),
                    Title = GenerateRandomString(3),
                    Company = GenerateRandomString(10),
                    Address = GenerateRandomString(10),
                    Home = GenerateRandomPhoneNumber(),
                    Work = GenerateRandomPhoneNumber(),
                    Fax = GenerateRandomPhoneNumber(),
                    Email = GenerateRandomEmail(),
                    Email2 = GenerateRandomEmail(),
                    Email3 = GenerateRandomEmail(),
                    Homepage = GenerateRandomWebAddress(),
                    Bday = GenerateRandomNumber(31),
                    Bmonth = GenerateRandomMonth(),
                    Byear = GenerateRandomYear(),
                    Aday = GenerateRandomNumber(31),
                    Amonth = GenerateRandomMonth(),
                    Ayear = GenerateRandomYear(),
                    Address2 = GenerateRandomString(10),
                    Phone2 = GenerateRandomPhoneNumber(),
                    Notes = GenerateRandomString(10)

                });
            }

            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]     
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            /*
            ContactData contact = new ContactData("Batalia", "Stoyanova", "08968756");
            //contact.Firstname = "Natalia";             
            contact.Middlename= "Yurieva";
            //contact.Lastname = "Stoyanova";
            contact.Nickname = "Nt_St";
            //contact.Photo= @"C:\Users\User\Pictures\images.jpg";
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
            */

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

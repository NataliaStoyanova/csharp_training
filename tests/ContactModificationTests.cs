using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationnTest()
        {
            ContactData contactM = new ContactData("Vladislav", "Stoyanov", "08968756");
            //contact.Firstname = "Natalia";             
            contactM.Middlename = "Yurieva";
            //contact.Lastname = "Stoyanova";
            contactM.Nickname = "Nt_St";
            contactM.Photo = @"C:\Users\User\Pictures\images.jpg";
            contactM.Title = "Mrs";
            contactM.Company = "Soft2Run";
            contactM.Address = "Sofia";
            contactM.Home = "099345435";
            //contact.Mobile = "08968756";
            contactM.Work = "03345346";
            contactM.Fax = "9887665";
            contactM.Email = "qa.natalia.ruseva@gmail.com";
            contactM.Email2 = "qa2.natalia.ruseva@gmail.com";
            contactM.Email3 = "qa3.natalia.ruseva@gmail.com";
            contactM.Homepage = "https://google.com";
            contactM.Bday = "4";
            contactM.Bmonth = "July";
            contactM.Byear = "1985";
            contactM.Aday = "29";
            contactM.Amonth = "July";
            contactM.Ayear = "2018";
            contactM.Address2 = "Tsarevo";
            contactM.Phone2 = "09898786";
            contactM.Notes = "notes";

            app.ContactHelper.Modify(1, contactM);
            app.Navigator.GoToContactsPage();
        }

    }
}

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationnTest()
        {
            ContactData contactM = new ContactData("Vladislav", "Stoyanov", "08968756");
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

            app.ContactHelper.Modify(1, contactM);
            app.Navigator.GoToContactsPage();
        }

    }
}

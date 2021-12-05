using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;


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


        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
                {
                    string[] parts = l.Split(',');
                    contacts.Add(new ContactData(
                        parts[0],
                        parts[1],
                        parts[2]                      
                        ));
                }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"Contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>
                (File.ReadAllText(@"Contacts.json"));
        }


        [Test, TestCaseSource("ContactDataFromXmlFile")]     
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

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

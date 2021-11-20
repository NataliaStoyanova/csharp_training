using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
//ContactHelper Responsible for interactions with application under test(contacts part)

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
     
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToContactsPage();
            manager.Navigator.InitContactCreation();
            FillContactForm(contact);
            SubmitNewContact();
            return this;
        }



        public ContactHelper Modify(int i, ContactData newcontact)
        {
            manager.Navigator.GoToContactsPage();
            InitContactModification(i);            
            FillContactForm(newcontact);
            SubmitContactModification();
            return this;
        }

        public ContactHelper RemoveContact(int tr)
        {
            manager.Navigator.GoToContactsPage();
            DeleteContact(tr);
            Thread.Sleep(3000);
            return this;
        }

        public ContactHelper DeleteContact(int index)
        {                  
                SelectContact(index);
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                driver.SwitchTo().Alert().Accept();
                contactCache = null;
                return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToContactsPage();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name='entry']"));                                 
                foreach (IWebElement tr in elements)
                {       
                           
                    var tds = tr.FindElements(By.TagName("td"));
                    
                    var id1 = tr.FindElement(By.TagName("input")).GetAttribute("value");

                    if (tds.Count > 0)
                    {
                        var firstName = tds[2].Text;
                        var lastName = tds[1].Text;

                        contactCache.Add(new ContactData
                        {
                            Firstname = firstName,
                            Lastname = lastName,
                            id = id1
                        }
                        ); ;
                    }
                }

            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            manager.Navigator.GoToContactsPage();
            return driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr")).Count - 1;
        }

        public ContactHelper InitContactModification(int row2)
        {
            SelectContact(row2);
            //another way
            //driver.FindElements(By.Name("entry"))[row2]
            //.FindElements(By.TagName("td"))[7]
            //.FindElement(By.TagName("a")).Click();
                
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (row2 + 2) + "]/td[8]/a")).Click();        
            return this;
        }

        public ContactHelper InitContactDetails(int row2)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (row2 + 2) + "]/td[7]/a")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {          
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillContactForm(ContactData newcontact)
        {      
            Type(By.Name("firstname"), newcontact.Firstname);
            Type(By.Name("middlename"), newcontact.Middlename);
            Type(By.Name("lastname"), newcontact.Lastname);
            Type(By.Name("nickname"), newcontact.Nickname);
            Type(By.Name("photo"), newcontact.Photo);
            Type(By.Name("title"), newcontact.Title);
            Type(By.Name("company"), newcontact.Company);
            Type(By.Name("address"), newcontact.Address);
            Type(By.Name("home"), newcontact.Home);
            Type(By.Name("mobile"), newcontact.Mobile);
            Type(By.Name("work"), newcontact.Work);
            Type(By.Name("fax"), newcontact.Fax);
            Type(By.Name("email"), newcontact.Email);
            Type(By.Name("email2"), newcontact.Email2);
            Type(By.Name("email3"), newcontact.Email3);
            Type(By.Name("homepage"), newcontact.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            TypeNoClear(By.Name("bday"), newcontact.Bday);
            TypeNoClear(By.Name("bmonth"), newcontact.Bmonth);
            driver.FindElement(By.Name("byear")).Click();
            TypeNoClear(By.Name("byear"), newcontact.Byear);
            TypeNoClear(By.Name("aday"), newcontact.Aday);
            TypeNoClear(By.Name("amonth"), newcontact.Amonth);
            driver.FindElement(By.Name("ayear")).Click();
            TypeNoClear(By.Name("ayear"), newcontact.Ayear);
            Type(By.Name("address2"), newcontact.Address2);
            driver.FindElement(By.XPath("//div[@id='content']/form/label[24]")).Click();
            driver.FindElement(By.Name("phone2")).Click();      
            Type(By.Name("phone2"), newcontact.Phone2);
            driver.FindElement(By.Name("notes")).Click();
            Type(By.Name("notes"), newcontact.Notes);
            return this;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }      
        public ContactHelper SelectContact(int row)
        {
            manager.Navigator.GoToContactsPage();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (row+2) + "]/td[1]/input")).Click();
            return this;
        }
        public bool DoesTheContactExist(int ii)
        {
            manager.Navigator.GoToContactsPage();
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + (ii + 2) + "]"));           
        }

        public ContactData GetContactInfoFromTable(int i)
        {
            manager.Navigator.GoToContactsPage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[i]
                                             .FindElements(By.TagName("td"));

            string lastname = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;

            return new ContactData(firstName, lastname)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInfoFromForm(int i)
        {
            manager.Navigator.GoToContactsPage();
            InitContactModification(i);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastname, mobilePhone)
            {
                Middlename = middlename,
                Nickname = nickname,
                Address = address,
                Title = title,
                Company = company,
                Homepage= homepage,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Home = homePhone,
                Work = workPhone,
                Phone2 = phone2,
                Notes = notes,
                Fax = fax,
                Address2 = address2
            };
        }

        public string GetContactDetails(int i)
        {
            manager.Navigator.GoToContactsPage();
            InitContactDetails(i);

            IList<IWebElement> cells = driver.FindElements(By.CssSelector("div#content"));
                                            
            string allDetails = cells[0].Text;

            System.Console.Out.Write(cells[0].Text + "\n");
            
            return allDetails;

        }

    }
}

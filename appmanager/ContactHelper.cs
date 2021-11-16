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
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (row2 + 2) + "]/td[8]/a")).Click();        
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

    }
}

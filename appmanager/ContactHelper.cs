using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
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
            SelectContact(tr);
            DeleteContact();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {          
            driver.FindElement(By.Name("update")).Click();
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
            return this;
        }      
        public ContactHelper SelectContact(int row)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (row+1) + "]/td/input")).Click();
            return this;
        }
      
        public ContactHelper InitContactModification(int row2)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (row2+1) + "]/td[8]/a")).Click();
            return this;
        }
      
    }
}

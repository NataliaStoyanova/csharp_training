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

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {


        public GroupHelper(ApplicationManager manager): base(manager)
        {
        }
        public GroupHelper ModifyGroup(int v, GroupData newdata)
        {
            manager.Navigator.GoToGroupsPage();         
            InitGroupModification(v);
            FillGroupForm(newdata);
            SubmitGroupModification();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();

            manager.Navigator.GoToGroupsPage();
            
            
            ICollection<IWebElement>  elements  = driver.FindElements(By.CssSelector("span.group"));

            foreach (IWebElement element in elements)
            {
                //System.Console.Out.Write(element.Text + "\n");

                groups.Add(new GroupData(element.Text));

            }

            return groups;
        }

        public GroupHelper Create(GroupData group)

        {
            manager.Navigator.GoToGroupsPage();
            InintGroupCreation();
            FillGroupForm(group);
            SubmitNewGroup();
            ReturnToGroupsPage();           
            return this;
        }

        public GroupHelper RemoveGroup(int a)
        {
            manager.Navigator.GoToGroupsPage();           
            DeleteGroup(a);
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {           
            Type(By.Name("group_name"), group.Group_name);
            Type(By.Name("group_header"), group.Group_header);
            Type(By.Name("group_footer"), group.Group_footer);
            return this;
        }

      /*  public GroupHelper DeleteGroup(int ii)
        {

            if (DoesTheGroupExist(ii))

            {
                SelectGroup(ii);
                driver.FindElement(By.Name("delete")).Click();
            }
            else
            {
                GroupData group = new GroupData("group1");
                group.Group_header = "header1";
                group.Group_footer = "footer1";               
                Create(group);
                SelectGroup(ii);
                driver.FindElement(By.Name("delete")).Click();

            }            
            return this;
        }
      */
        public GroupHelper DeleteGroup(int ii)
        {          
                SelectGroup(ii);
                driver.FindElement(By.Name("delete")).Click();             
                return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index+1) + "]/input")).Click();
            return this;
        }


        public bool DoesTheGroupExist(int i)
        {
       
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.XPath("//div[@id='content']/form[1]/span[" + (i + 1) + "]"));

        }


        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelper InintGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper SubmitNewGroup()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        /*  public GroupHelper InitGroupModification(int iii)
          {
              if (DoesTheGroupExist(iii))

              {
                  SelectGroup(iii);
                  driver.FindElement(By.Name("edit")).Click();
              }
              else
              {
                  GroupData group = new GroupData("group1");
                  group.Group_header = "header1";
                  group.Group_footer = "footer1";
                  Create(group);
                  SelectGroup(iii);
                  driver.FindElement(By.Name("edit")).Click();

              }
              return this;
          }
        */
        public GroupHelper InitGroupModification(int iii)
        {   
                SelectGroup(iii);
                driver.FindElement(By.Name("edit")).Click();       
                return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }
    }
}

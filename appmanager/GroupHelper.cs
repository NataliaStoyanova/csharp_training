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

        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    /*
                    GroupData group = new GroupData(element.Text);
                    group.id = element.FindElement(By.TagName("input")).GetAttribute("value");
                    //System.Console.Out.Write(element.Text + "\n");
                    groupCache.Add(group);
                   */

                    GroupData group = new GroupData(element.Text) {
                        id = element.FindElement(By.TagName("input")).GetAttribute("value")
                     };                  
                    groupCache.Add(group);
                }
            }
            return new List<GroupData> (groupCache);
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
        public GroupHelper DeleteGroup(int ii)
        {          
                SelectGroup(ii);
                driver.FindElement(By.Name("delete")).Click();
                groupCache = null;
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
            groupCache = null;
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
            groupCache = null;
            return this;
        }    
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

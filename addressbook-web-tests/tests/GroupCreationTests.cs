using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        //this method must be static for the random test data to be generated on the compilation stage
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        { 
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(15))
                {
                    Group_header = GenerateRandomString(10),
                    Group_footer = GenerateRandomString(10)
                });           
            }
            return groups;        
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Group_header = parts[1],
                    Group_footer = parts[2]
                });            
            }
            return groups;       
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return  (List<GroupData>) new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>
                (File.ReadAllText(@"groups.json"));                 
        }


        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupData group)
        {   
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
        
            app.GroupHelper.Create(group);
           
            Assert.AreEqual(oldGroups.Count + 1, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        /*
         [Test]
         public void InvalidNameGroupCreationTest()
         {

             GroupData emptygroup = new GroupData("a'a");
             emptygroup.Group_header = "";
             emptygroup.Group_footer = "";

             List<GroupData> oldGroups = app.GroupHelper.GetGroupList();

             app.GroupHelper.Create(emptygroup);

             List<GroupData> newGroups = app.GroupHelper.GetGroupList();

             Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
         }
        */

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<GroupData> groupsFromUI = app.GroupHelper.GetGroupList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            
            start = DateTime.Now;
            List<GroupData> groupsfromDB = GroupData.GetGroupsFromDB();                        
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}

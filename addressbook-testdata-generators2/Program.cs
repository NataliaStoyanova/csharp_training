using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            //data type: group or contacts 
            string datatype = args[0];
            //number of lines to generate
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            //format: csv,xmsl, json
            string format = args[3];

            if (datatype == "group")
            {
                StreamWriter writerGroups = new StreamWriter(filename);
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Group_header = TestBase.GenerateRandomString(10),
                        Group_footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writerGroups);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writerGroups);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writerGroups);
                }
                else
                {
                    System.Console.Out.Write("Unrecognised format " + format);
                }
                writerGroups.Close();
            }
            else if (datatype == "contact")
            {

                StreamWriter writerContacts = new StreamWriter(filename);
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(15),
                        TestBase.GenerateRandomString(15),
                        TestBase.GenerateRandomPhoneNumber()
                        ));
                }

                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writerContacts);
                }
                else if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writerContacts);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writerContacts);
                }
                else
                {
                    System.Console.Out.Write("Unrecognised format " + format);
                }
                writerContacts.Close();
            }

            static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
            {
                foreach (GroupData group in groups)
                {
                    writer.WriteLine(String.Format("${0},${1},${2}",
                        group.Group_name,
                        group.Group_header,
                        group.Group_footer
                        ));
                }
            }

            static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            }

            static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
            }

            static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
            {
                foreach (ContactData contact in contacts)
                {
                    writer.WriteLine(String.Format("${0},${1},${2}",
                        contact.Firstname,
                        contact.Lastname,
                        contact.Mobile
                       ));
                }
            }

            static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
            {
                new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            }

            static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
            {
                writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
            }
        }
    }
}
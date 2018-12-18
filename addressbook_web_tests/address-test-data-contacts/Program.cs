using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbooktests;

namespace address_test_data_contacts
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    Lastname = TestBase.GenerateRandomString(100),
                    Middlename = TestBase.GenerateRandomString(100)

                });

            }
            if (format == "csv")
            {
                writeContactsToCsvFile(contacts, writer);
            }
            else if (format == "xml")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else if (format == "json")
            {
                writeContactsToJsonFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format" + format);
            }
            writer.Close();
        }



        //Contacts
        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                contact.Firstname, contact.Lastname, contact.Middlename));
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

      
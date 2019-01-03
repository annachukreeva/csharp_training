using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    //public class AddNewContactsTests : AuthTestBase


    public class AddNewContactsTests : ContactTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Lastname = GenerateRandomString(100),
                    Middlename = GenerateRandomString(100),
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {

            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));

        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"groups.json"));
            Excel.Worksheet sheet = wb.Sheets[1];
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 1].Value,
                    Middlename = range.Cells[i, 1].Value,
                });

            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        // [Test, TestCaseSource("RandomContactDataProvider")]
        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void AddNewContactTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.CreateContact(contact);

            
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }



        [Test]
        public void TestDBConnectivityContacts()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUI = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}
          
   
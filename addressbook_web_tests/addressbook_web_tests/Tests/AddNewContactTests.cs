using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    public class AddNewContactsTests : AuthTestBase
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

        // [Test, TestCaseSource("RandomContactDataProvider")]
        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void AddNewContactTest(ContactData contact)
        {
           //ContactData contact = new ContactData("Anna");
            //contact.Lastname = "Chukreeva";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

      //  [Test]
       // public void EmptyAddNewContactTest()
       // {
         //   ContactData contact = new ContactData("");
        //    contact.Lastname = "";

         //   List<ContactData> oldContacts = app.Contacts.GetContactList();

         //   app.Contacts.CreateContact(contact);

         //   Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

        //    List<ContactData> newContacts = app.Contacts.GetContactList();
         //   oldContacts.Add(contact);
         //   oldContacts.Sort();
         //   newContacts.Sort();
         //   Assert.AreEqual(oldContacts, newContacts); ;
       // }
    }
}
          
   
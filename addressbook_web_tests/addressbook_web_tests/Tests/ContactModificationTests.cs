using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
    //public class ContactModificationTests : AuthTestBase
      public class ContactModificationTests : GroupTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            app.Navigator.GoToHomePage();
            if (!app.Contacts.IsElementPresent(By.CssSelector("tr[name='entry']")))
            {
                ContactData contact = new ContactData("Ivan", "Ivanov");
                app.Contacts.CreateContact(contact);
            }
            ContactData newData = new ContactData("Ivan");
            newData.Lastname = "Ivanov";
            newData.Bday = "1";
            List<ContactData> oldContacts = ContactData.GetAll();
            // List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData toBeModified = oldContacts[0];
            app.Contacts.Modify(toBeModified);
            List<ContactData> newContacts = ContactData.GetAll();
            // List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
           // Assert.AreEqual(oldContacts, newContacts);
            Assert.AreEqual(oldContacts, toBeModified.Id);
       

        }
    }
}
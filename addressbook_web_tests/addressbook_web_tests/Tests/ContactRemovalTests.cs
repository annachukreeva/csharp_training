using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
  //  public class ContactRemovalTests : AuthTestBase
        public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Navigator.GoToHomePage();
            if (!app.Contacts.IsElementPresent(By.CssSelector("tr[name='entry']")))
            {
                ContactData contact = new ContactData("Ivan", "Ivanov");
                app.Contacts.CreateContact(contact);
            }

            // List<ContactData> oldContacts = app.Contacts.GetContactList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.Remove(toBeRemoved);



            // List<ContactData> newContacts = app.Contacts.GetContactList();
            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

           foreach (ContactData contact in newContacts)
              {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
              }

           // Assert.AreEqual(oldContacts, toBeRemoved);
        }
    }
}
  

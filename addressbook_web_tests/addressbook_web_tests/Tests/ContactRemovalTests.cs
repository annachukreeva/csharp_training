using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
 public class ContactRemovalTests : AuthTestBase
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(0);

        

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);


            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
  

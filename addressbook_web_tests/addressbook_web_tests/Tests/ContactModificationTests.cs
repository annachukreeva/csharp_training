using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
    public class ContactModificationTests : AuthTestBase
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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
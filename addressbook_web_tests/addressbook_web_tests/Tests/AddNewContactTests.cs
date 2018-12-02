using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    public class AddNewContactsTests : AuthTestBase
    {
        [Test]
        public void AddNewContactTest()
        {
            ContactData contact = new ContactData("Anna");
            contact.Lastname = "Chukreeva";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test]
        public void EmptyAddNewContactTest()
        {
            ContactData contact = new ContactData(" ");
            contact.Lastname = " ";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CreateContact(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }
    }
}
          
   
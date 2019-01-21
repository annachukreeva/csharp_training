using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
    public class DeletingContactsFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];

            if (group.GetContacts().Count() == 0)
            {
                ContactData contacts = new ContactData("Ivan", "Ivanov");
                app.Contacts.AddContactToGroup(contacts, group);
            }

            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0] ;// ; ContactData.GetAll()[0];
            //actions
            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.RemoveAt(0);// delete(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList.Count, newList.Count);
        }
    }
}

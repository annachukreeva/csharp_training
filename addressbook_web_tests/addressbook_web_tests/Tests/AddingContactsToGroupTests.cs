using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbooktests
{
    public class AddingContactsToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {

            if (GroupData.GetAll().Count() == 0)
            {
                GroupData newgroup = new GroupData("ааа");
                newgroup.Header = "ddd";
                newgroup.Footer = "fff";
                app.Groups.Create(newgroup);
            }
            GroupData group = GroupData.GetAll()[0];

            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count() == 0)
            {
                    app.Contacts.CreateContact(new ContactData("Anna"));
                    oldList = group.GetContacts();
                    app.Contacts.CreateContact(new ContactData("Anna1"));

                    // app.Contacts.AddContactToGroup(new ContactData("Anna"), group);

                    // app.Contacts.AddContactToGroup(newcontact, group);

            }
            

            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}

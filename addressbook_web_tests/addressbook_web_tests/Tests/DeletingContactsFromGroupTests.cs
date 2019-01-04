using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbooktests
{
    public class DeletingContactsFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeletingContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            //actions
            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Delete(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList.Count-1, newList);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbooktests
{
  public class ContactModificationTests : AuthTestBase
    {


        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Ivan");
            newData.Lastname = "Ivanov";
            app.Contacts.Modify(newData);
          }
    }
}
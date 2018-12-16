using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]

    public class ContactInformationalTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditTForm(0);

            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }
 
      [Test]

      public void DetailedContactImformation()
      {
        ContactData fromForm = app.Contacts.GetContactInformationFromEditTForm(0);
        string fromСontactDetails = app.Contacts.GetContactInformationFromDetails(0);
        //this test is valid only for data mentioned in the main form: firstname, lastname, address, 
        //homephone, mobilephone, workphone, email, email2, email3
        //verification
        Assert.AreEqual(fromForm.Details, fromСontactDetails);
      }
    }
}


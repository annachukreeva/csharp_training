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
            string fromContactDetails = fromForm.Firstname + fromForm.Lastname  + fromForm.Address +
               // "H:" + fromForm.Home + "M:" + fromForm.Mobile + "W:" + fromForm.Work  + fromForm.Email + fromForm.Email2 + fromForm.Email3;
               fromForm.Home +  fromForm.Mobile + fromForm.Work + fromForm.Email + fromForm.Email2 + fromForm.Email3;
            //verification
            Assert.AreEqual(fromContactDetails, fromContactDetails);
        }
    }
}


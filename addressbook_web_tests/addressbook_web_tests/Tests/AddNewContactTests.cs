using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

               app.Contacts.CreateContact(contact);
           }

        [Test]
        public void EmptyAddNewContactTest()
        {
            ContactData contact = new ContactData(" ");
            contact.Lastname = " ";

            app.Contacts.CreateContact(contact);
         }
    }
 }       
          
   
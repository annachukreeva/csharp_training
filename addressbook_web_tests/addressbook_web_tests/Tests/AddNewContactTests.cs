using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    public class AddNewContactsTests : TestBase
    {
         [Test]
        public void AddNewContactTest()
        {
                 app.Contacts
                .PressAddNewContact()
                .FillTheDataAddNewContact(new ContactData("Anna", "Chukreeva"))
                .SubmitAddNewContact();
                 app.Navigator
                .ReturnToHomePage()
                .Logout();
        }
        }
    }
}         
          
   
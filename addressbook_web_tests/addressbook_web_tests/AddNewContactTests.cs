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
            GoToHomePage();
            Login(new AccountData ("admin", "secret"));
            PressAddNewContact();
            FillTheDataAddNewContact(new ContactData("Anna", "Chukreeva"));
            SubmitAddNewContact();
            ReturnToHomePage();
            Logout();
        }
    }
}          
          
   
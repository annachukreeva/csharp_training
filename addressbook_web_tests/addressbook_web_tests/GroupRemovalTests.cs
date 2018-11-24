using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupPage();
        }            
     }
}
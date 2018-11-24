using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    { 
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("ааа");
            group.Header = "ddd";
            group.Footer = "fff";
            FillGroupFormin(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
        }         
    }                   
 }
  

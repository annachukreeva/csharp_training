﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

namespace WebAddressbooktests
{
    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            navigator.GoToHomePage();
            loginHelper.Login(new AccountData ("admin", "secret"));
            navigator.GoToGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.DeleteGroup();
            groupHelper.ReturnToGroupPage();
        }
        }
}

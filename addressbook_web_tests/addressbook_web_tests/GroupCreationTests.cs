using System;
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

        //private void ReturnToGroupPage()
       // {
         //   driver.FindElement(By.LinkText("group page")).Click();
           // driver.FindElement(By.LinkText("Logout")).Click();
       // }

        //private void SubmitGroupCreation()
       // {
         //   driver.FindElement(By.Name("submit")).Click();
        //}

       // private void FillGroupFormin(GroupData group)
        //{
           // driver.FindElement(By.Name("group_name")).Click();
            //driver.FindElement(By.Name("group_name")).Clear();
           // driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
           // driver.FindElement(By.Name("group_header")).Click();
           // driver.FindElement(By.Name("group_header")).Clear();
           // driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
           // driver.FindElement(By.Name("group_footer")).Click();
            //driver.FindElement(By.Name("group_footer")).Clear();
           // driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
       // }

       // private void InitNewGroupCreation()
       // {
        //    driver.FindElement(By.Name("new")).Click();
        //}

        //private void GoToGroupsPage()
        //{
           // driver.FindElement(By.LinkText("groups")).Click();
       // }
        }
    }

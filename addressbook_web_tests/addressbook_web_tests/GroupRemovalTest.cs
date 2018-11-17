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
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            GoToHomePage();
            Login(new AccountData ("admin", "secret"));
            GoToGroupsPage();
            SelectGroup(1);
            DeleteGroup();
            ReturnToGroupPage();
        }

      // private void ReturnToGroupPage()
       // {
         //   driver.FindElement(By.XPath("(//*[normalize-space(text()) and normalize-space(.)='Groups'])[1]/following::div[1]")).Click();
         //   driver.FindElement(By.LinkText("group page")).Click();
       // }

      //  private void DeleteGroup()
       // {
        //    driver.FindElement(By.Name("delete")).Click();
       // }

       // private void SelectGroup(int index)
        //{
          // driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
           //driver.FindElement(By.XPath("//input[@name='selected[]']")).Click();
        //}

       // private void GoToGroupsPage()
       // {
        //    driver.FindElement(By.LinkText("groups")).Click();
       // }
        }
}

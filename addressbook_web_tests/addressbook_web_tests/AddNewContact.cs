using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbooktests
{
    [TestFixture]
    public class AddNewContactsTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void AddNewContactTest()
        {
            GoToHomePage();
            Login(new AccountData ("admin", "secret"));
            AddNew();
            FillTheDataIn("Anna", "Chukreeva", "1", "2", "3", "4", "5", "6", "7", 
                "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22");
            Submit();
            ReturnHome();
            Logout();
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void ReturnHome()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }

        private void Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillTheDataIn(string firstname,  string lastname,
        string nickname,string middlename,
        string title, string company, string address, string home, string mobile, string work,
        string fax, string email, string email2, string email3, string homepage,
        string bdate, string bmonth, string byear,
        string adate, string amonth, string ayear,
        string address2, string phone2, string notes)
        {
           driver.FindElement(By.Name("firstname")).Click();
           driver.FindElement(By.Name("firstname")).Clear();
           driver.FindElement(By.Name("firstname")).SendKeys(firstname);
           driver.FindElement(By.Name("theform")).Click();
           driver.FindElement(By.Name("middlename")).Click();
           driver.FindElement(By.Name("middlename")).Clear();
           driver.FindElement(By.Name("middlename")).SendKeys(middlename);
           driver.FindElement(By.Name("lastname")).Click();
           driver.FindElement(By.Name("lastname")).Clear();
           driver.FindElement(By.Name("lastname")).SendKeys(lastname);
           driver.FindElement(By.Name("theform")).Click();
           driver.FindElement(By.Name("nickname")).Click();
           driver.FindElement(By.Name("nickname")).Clear();
           driver.FindElement(By.Name("nickname")).SendKeys(nickname);
           driver.FindElement(By.Name("title")).Click();
           driver.FindElement(By.Name("title")).Clear();
           driver.FindElement(By.Name("title")).SendKeys(title);
           driver.FindElement(By.Name("company")).Click();
           driver.FindElement(By.Name("company")).Clear();
           driver.FindElement(By.Name("company")).SendKeys(company);
           driver.FindElement(By.Name("address")).Click();
           driver.FindElement(By.Name("address")).Clear();
           driver.FindElement(By.Name("address")).SendKeys(address);
           driver.FindElement(By.Name("home")).Click();
           driver.FindElement(By.Name("home")).Clear();
           driver.FindElement(By.Name("home")).SendKeys(home);
           driver.FindElement(By.Name("mobile")).Click();
           driver.FindElement(By.Name("mobile")).SendKeys(mobile);
           driver.FindElement(By.Name("work")).Click();
           driver.FindElement(By.Name("work")).Clear();
           driver.FindElement(By.Name("work")).SendKeys(work);
           driver.FindElement(By.Name("theform")).Click();
           driver.FindElement(By.Name("fax")).Click();
           driver.FindElement(By.Name("fax")).Clear();
           driver.FindElement(By.Name("fax")).SendKeys(fax);
           driver.FindElement(By.Name("email")).Click();
           driver.FindElement(By.Name("email")).Clear();
           driver.FindElement(By.Name("email")).SendKeys(email);
           driver.FindElement(By.Name("email2")).Click();
           driver.FindElement(By.Name("email2")).Clear();
           driver.FindElement(By.Name("email2")).SendKeys(email2);
           driver.FindElement(By.Name("email3")).Click();
           driver.FindElement(By.Name("email3")).Clear();
           driver.FindElement(By.Name("email3")).SendKeys(email2);
           driver.FindElement(By.Name("homepage")).Click();
           driver.FindElement(By.Name("homepage")).Clear();
           driver.FindElement(By.Name("homepage")).SendKeys(homepage);
           driver.FindElement(By.Name("bday")).Click();
           new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("17");
           driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[19]")).Click();
           driver.FindElement(By.Name("theform")).Click();
           driver.FindElement(By.Name("bmonth")).Click();
           new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("November");
           driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[45]")).Click();
           driver.FindElement(By.Name("byear")).Click();
           driver.FindElement(By.Name("byear")).Clear();
           driver.FindElement(By.Name("byear")).SendKeys(byear);
           new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("17");
           driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[19]")).Click();
           driver.FindElement(By.Name("amonth")).Click();
           new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("October");
           driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[44]")).Click();
           driver.FindElement(By.Name("ayear")).Click();
           driver.FindElement(By.Name("ayear")).Clear();
           driver.FindElement(By.Name("ayear")).SendKeys(ayear);
           driver.FindElement(By.Name("address2")).Click();
           driver.FindElement(By.Name("address2")).Clear();
           driver.FindElement(By.Name("address2")).SendKeys(address2);
           driver.FindElement(By.Name("phone2")).Click();
           driver.FindElement(By.Name("phone2")).Clear();
           driver.FindElement(By.Name("phone2")).SendKeys(phone2);
           driver.FindElement(By.Name("notes")).Click();
           driver.FindElement(By.Name("notes")).Clear();
           driver.FindElement(By.Name("notes")).SendKeys(notes);
        }

        private void AddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.Name("pass")).Click();
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.Id("LoginForm")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}

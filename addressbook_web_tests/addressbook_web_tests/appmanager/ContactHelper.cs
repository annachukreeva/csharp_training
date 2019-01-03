using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;



namespace WebAddressbooktests
{
    public class ContactHelper : HelperBase
    {
        private string baseURL;

        public ContactHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }



        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                // ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//td[1]"));
                foreach (IWebElement element in elements)
                {
                    string Firstname = element.FindElement(By.XPath(".//td[3]")).Text;
                    string Lastname = element.FindElement(By.XPath(".//td[2]")).Text;
                    contactCache.Add(new ContactData(Firstname, Lastname));
                }
            }

            return new List<ContactData>(contactCache);
        }

       
        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactDetails(index);

            string details = driver.FindElement(By.Id("content")).Text;

            details = Regex.Replace(details, "H:", "");
            details = Regex.Replace(details, "M:", "");
            details = Regex.Replace(details, "W:", "");
            details = Regex.Replace(details, "[ \n\r]", "");

            return details ;
        }

        public ContactHelper InitContactDetails(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (index + 1) + " ]")).Click();
            return this;
        }
    

        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public bool acceptNextAlert { get; private set; }

        public ContactHelper(ApplicationManager manager): base(manager)
        {
        }
        public ContactHelper CreateContact(ContactData contact)
        {
            PressAddNewContact();
            FillTheDataAddNewContact(contact);
            SubmitAddNewContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            manager.Navigator.GoToHomePage();

            InitContactModification();
            FillTheDataAddNewContact(newData);
            ConfirmContactModification();
            return this;
        }



        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }
        public ContactHelper ConfirmContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitAddNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper FillTheDataAddNewContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("workp"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
          //  new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[19]")).Click();
          //  new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[45]")).Click();
         //   Type(By.Name("byear"), contact.Byear);
         //   new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[19]")).Click();
         //   new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[44]")).Click();
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Anotes);

            return this;
        }

        public void PressAddNewContact()
        {
            if (driver.Url == baseURL + "/addressbook/edit.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            InitRemovalContact();
            ConfirmRemovalContact();
            return this;
        }


        public ContactHelper Remove(ContactData contact)
        {

            manager.Navigator.GoToHomePage();
            SelectContactById(contact.Id);
            InitRemovalContact();
            ConfirmRemovalContact();
            return this;
        }

        public ContactHelper SelectContactById(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
          //  driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();

            return this;
        }

        public ContactHelper ConfirmRemovalContact()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper InitRemovalContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

       public ContactData GetContactInformationFromEditTForm(int index)
       {
            manager.Navigator.GoToHomePage();
            InitContactModification1(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Home = home,
                Mobile = mobile,
                Work = work,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }

        public void InitContactModification1(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"))[7]
                  .FindElement(By.TagName("a")).Click();
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                  .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmail = cells[4].Text;


            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail,
            };

        }

        public int GetNumberOfSerachResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


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

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();

            manager.Navigator.GoToHomePage();
           ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
           // ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//td[1]"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }

            return contacts;
        }

        public ContactHelper SelectContact(int index)
        {
            //driver.FindElement(By.CssSelector("tr[name='entry'][" + (index + 1) + "]")).Click();
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            //  driver.FindElement(By.XPath(".//td[1]")).Click();
            //driver.FindElement(By.Id( v.ToString() )).Click();
            return this;
        }

        public bool acceptNextAlert { get; private set; }

        public ContactHelper(ApplicationManager manager)
            : base(manager)
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
       // public ContactHelper Modify(int v, ContactData newData)
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
            return this;
        }          
               
        public ContactHelper SubmitAddNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
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
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[19]")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[45]")).Click();
            Type(By.Name("byear"), contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[19]")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
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

        public ContactHelper Remove( int index )
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            InitRemovalContact();
            ConfirmRemovalContact();
            return this;
        }

        public ContactHelper ConfirmRemovalContact()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper InitRemovalContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }
    }
}

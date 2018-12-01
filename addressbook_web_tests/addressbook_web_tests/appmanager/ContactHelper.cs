﻿using System;
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
           manager.Navigator.ReturnToHomePage();
           return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.ReturnToHomePage();

           // SelectContact(v);
            InitContactModification();
            FillTheDataAddNewContact(newData);
            ConfirmContactModification();
            return this;
        }

        public ContactHelper SelectContact(int v)
        {
           driver.FindElement(By.Id( v.ToString() )).Click();
          // XPath("(//input[@name='selected[]'])[" + v + "]")) ;
           return this;
       }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            // driver.FindElement(By.Name("Edit")).Click();
           // driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + " ]")).Click();
           // driver.FindElement(By.XPath("//a[@href='edit.php?id=" + index + "']")).Click();
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
            //driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            // driver.FindElement(By.Name("firstname")).Clear();
            // driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            // driver.FindElement(By.Name("theform")).Click();
            // driver.FindElement(By.Name("middlename")).Click();
            Type(By.Name("middlename"), contact.Middlename);
            // driver.FindElement(By.Name("middlename")).Clear();
            // driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            //driver.FindElement(By.Name("lastname")).Click();
            Type(By.Name("lastname"), contact.Lastname);
            // driver.FindElement(By.Name("lastname")).Clear();
            //driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            //  driver.FindElement(By.Name("theform")).Click();
            //driver.FindElement(By.Name("nickname")).Click();
            Type(By.Name("nickname"), contact.Nickname);
            // driver.FindElement(By.Name("nickname")).Clear();
            // driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            // driver.FindElement(By.Name("title")).Click();
            Type(By.Name("title"), contact.Title);
            //driver.FindElement(By.Name("title")).Clear();
            // driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            // driver.FindElement(By.Name("company")).Click();
            Type(By.Name("company"), contact.Company);
            //driver.FindElement(By.Name("company")).Clear();
            // driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            // driver.FindElement(By.Name("address")).Click();
            Type(By.Name("address"), contact.Address);
            //driver.FindElement(By.Name("address")).Clear();
            //driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            // driver.FindElement(By.Name("home")).Click();
            Type(By.Name("home"), contact.Home);
            //driver.FindElement(By.Name("home")).Clear();
            // driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            // driver.FindElement(By.Name("mobile")).Click();
            Type(By.Name("mobile"), contact.Mobile);
            // driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            // driver.FindElement(By.Name("work")).Click();
            Type(By.Name("work"), contact.Work);
            // driver.FindElement(By.Name("work")).Clear();
            // driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            //  driver.FindElement(By.Name("theform")).Click();
            // driver.FindElement(By.Name("fax")).Click();
            Type(By.Name("fax"), contact.Fax);
            //driver.FindElement(By.Name("fax")).Clear();
            // driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            // driver.FindElement(By.Name("email")).Click();
            Type(By.Name("email"), contact.Email);
            //driver.FindElement(By.Name("email")).Clear();
            // driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            // driver.FindElement(By.Name("email2")).Click();
            Type(By.Name("email2"), contact.Email2);
            // driver.FindElement(By.Name("email2")).Clear();
            //driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            // driver.FindElement(By.Name("email3")).Click();
            Type(By.Name("email3"), contact.Email3);
            //  driver.FindElement(By.Name("email3")).Clear();
            // driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            // driver.FindElement(By.Name("homepage")).Click();
            Type(By.Name("homepage"), contact.Homepage);
           // driver.FindElement(By.Name("homepage")).Clear();
           // driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
           // driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[19]")).Click();
         //   driver.FindElement(By.Name("theform")).Click();
           // driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[45]")).Click();
           // driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[19]")).Click();
           // driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[44]")).Click();
            //driver.FindElement(By.Name("ayear")).Click();
            Type(By.Name("ayear"), contact.Ayear);
           // driver.FindElement(By.Name("ayear")).Clear();
           // driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            //  driver.FindElement(By.Name("address2")).Click();
            Type(By.Name("address2"), contact.Address2);
            //driver.FindElement(By.Name("address2")).Clear();
            // driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            // driver.FindElement(By.Name("phone2")).Click();
            Type(By.Name("phone2"), contact.Phone2);
            //driver.FindElement(By.Name("phone2")).Clear();
            // driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            //  driver.FindElement(By.Name("notes")).Click();
            Type(By.Name("notes"), contact.Anotes);
           // driver.FindElement(By.Name("notes")).Clear();
          //  driver.FindElement(By.Name("notes")).SendKeys(contact.Anotes);
            return this;
        }

        public ContactHelper PressAddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper Remove( int v )
        {
            manager.Navigator.ReturnToHomePage();
            SelectContact(v);
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

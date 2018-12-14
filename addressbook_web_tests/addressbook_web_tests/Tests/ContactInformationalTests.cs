﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]

    public class ContactInformationalTests: AuthTestBase
    {
        [Test]

        public void TestContactInfornation()
         {
          ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
          ContactData fromForm = app.Contacts.GetContactInformationFromEditTForm(0);

            //verifocation

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }

}
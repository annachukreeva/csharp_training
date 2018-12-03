﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbooktests
{
 public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(1);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
  

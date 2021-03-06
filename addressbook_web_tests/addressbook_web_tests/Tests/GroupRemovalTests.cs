﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
    [TestFixture]
  //  public class DeleteGroupTests : AuthTestBase
            public class DeleteGroupTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            app.Navigator.GoToGroupsPage(); 
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData(" ");
                app.Groups.Create(group);
            }
            

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.RemoveGroups(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

          //  GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
                {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }            
     }
}
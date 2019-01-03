using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbooktests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData(" ");
                app.Groups.Create(group);
            }

            // List<GroupData> oldGroups = app.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData oldData = oldGroups[0];

            // app.Groups.Modify(0, newData);

            GroupData toBeModified = oldGroups[0];
            app.Groups.Modify(toBeModified);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            // List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, toBeModified.Id);
                }
            }
        }
    }
}
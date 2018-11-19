using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("ааа");
            group.Header = "ddd";
            group.Footer = "fff";

            //app.Navigator.GoToGroupsPage();
            app.Groups.Create(group);
         }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //app.Navigator.GoToGroupsPage();
            app.Groups.Create(group);
       }
    }
    }

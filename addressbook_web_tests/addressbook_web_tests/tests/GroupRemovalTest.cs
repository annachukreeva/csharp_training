using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbooktests
{
    [TestFixture]
    public class DeleteGroupTests : TestBase
    {
        [Test]
        public void DeleteGroupTest()
        {
            app.Groups.Remove(1);
            //app.Navigator.GoToGroupsPage();
            //app.Groups.SelectGroup(1)
                      //.DeleteGroup()
                      //.ReturnToGroupPage();
        }
        }
}

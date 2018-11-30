using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbooktests
{
 public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void DeleteContactTest()
        {
            app.Contacts.Remove(23);
        }
    }
}
  

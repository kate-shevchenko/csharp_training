using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests

{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            if (!app.Contacts.DoesContactExist())
            {
                ContactData contact = new ContactData("FirstName1");

                app.Contacts.Create(contact);
            }

            app.Contacts.Remove(1);
        }

    }
}

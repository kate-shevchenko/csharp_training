using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("test1");
            
            if (!app.Groups.DoesGroupExist())
            {
                app.Groups.Create(group);
            }

            app.Groups.Remove(1);
        }
    }
}

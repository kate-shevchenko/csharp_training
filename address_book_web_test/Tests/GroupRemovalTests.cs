using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests: AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newGroup = new GroupData("test1");
            
            if (!app.Groups.DoesGroupExist())
            {
                app.Groups.Create(newGroup);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}

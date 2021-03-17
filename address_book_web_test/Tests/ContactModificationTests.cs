using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests

{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (!app.Contacts.DoesContactExist())
            {
                ContactData contact = new ContactData("FirstName1");

                app.Contacts.Create(contact);
            }

            ContactData newData = new ContactData("FirstNameNew");
            newData.MiddleName = "MiddleNameNew";
            newData.LastName = "LastNameNew";
            newData.Nickname = "NicknameNew";
            newData.Title = "TitleNew";
            newData.Company = "CompanyNew";
            newData.Address = "AddressNew";
            newData.HomePhone = "HomePhoneNew";
            newData.MobilePhone = "MobilePhoneNew";
            newData.WorkPhone = "WorkPhoneNew";
            newData.Fax = "FaxNew";
            newData.Email = "email1New";
            newData.Email2 = "email2New";
            newData.Email3 = "email3New";
            newData.Homepage = "HomePhoneNew";
            newData.BirthdayDay = null;
            newData.BirthdayMonth = null;
            newData.BirthdayYear = null;
            newData.AnniversaryDay = "20";
            newData.AnniversaryMonth = "January";
            newData.AnniversaryYear = "2011";
            newData.SecondaryAddress = "SecondaryAddressNew";
            newData.SecondaryHome = "SecondaryHomeNew";
            newData.Notes = "NotesNew";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}

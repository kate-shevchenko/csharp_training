using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests

{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("FirstNameNew");
            newData.MiddleName = "MiddleNameNew";
            newData.LastName = "LastNameNew";
            newData.Nickname = "NicknameNew";
            newData.Title = "TitleNew";
            newData.Company = "CompanyNew";
            newData.Address = "AddressNew";
            newData.HomeTelephone = "HomePhoneNew";
            newData.MobileTelephone = "MobilePhoneNew";
            newData.WorkTelephone = "WorkPhoneNew";
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

            app.Contacts.Modify(1, newData);
        }

    }
}

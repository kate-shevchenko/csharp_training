using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactCreationTests: TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            ContactData contact = new ContactData("FirstName1");
            contact.MiddleName = "MiddleName";
            contact.LastName = "LastName";
            contact.Nickname = "Nickname";
            contact.Title = "Title";
            contact.Company = "Company";
            contact.Address = "Address";
            contact.HomeTelephone = "HomePhone";
            contact.MobileTelephone = "MobilePhone";
            contact.WorkTelephone = "WorkPhone";
            contact.Fax = "Fax";
            contact.Email = "email1";
            contact.Email2 = "email2";
            contact.Email3 = "email3";
            contact.Homepage = "HomePhone";
            contact.BirthdayDay = "1";
            contact.BirthdayMonth = "January";
            contact.BirthdayYear = "1990";
            contact.AnniversaryDay = "2";
            contact.AnniversaryMonth = "February";
            contact.AnniversaryYear = "2010";
            contact.SecondaryAddress = "SecondaryAddress";
            contact.SecondaryHome = "SecondaryHome";
            contact.Notes = "Notes";
            FillContactForm(contact);
            SubmitContactCreation();
        }
    }
}


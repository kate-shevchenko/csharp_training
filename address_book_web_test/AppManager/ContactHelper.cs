using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            InitContactRemoving();
            ConfirmContactRemoving();
            contactCache = null;
            ReturnToHomePage();
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            return this;
        }


        public ContactHelper Modify(int index, ContactData newData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            Select(By.Name("bday"), contact.BirthdayDay);
            Select(By.Name("bmonth"), contact.BirthdayMonth);
            Type(By.Name("byear"), contact.BirthdayYear);
            Select(By.Name("aday"), contact.AnniversaryDay);
            Select(By.Name("amonth"), contact.AnniversaryMonth);
            Type(By.Name("ayear"), contact.AnniversaryYear);
            Type(By.Name("address2"), contact.SecondaryAddress);
            Type(By.Name("phone2"), contact.SecondaryHome);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']["+ (index+1) +"]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            index++; //так как первый элемент находится во второй строчке
            driver.FindElement(By.XPath("//tr["+ (index+1) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper InitContactRemoving()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        private void ConfirmContactRemoving()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public bool DoesContactExist()
        {
            manager.Navigator.GoToHomePage();
            return IsElementPresent(By.Name("selected[]"));
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));
                foreach (IWebElement element in elements)
                {
                    var firstName = element.FindElement(By.CssSelector("td:nth-of-type(3)")).Text;
                    var lastName = element.FindElement(By.CssSelector("td:nth-of-type(2)")).Text;
                    contactCache.Add(new ContactData(firstName, lastName));
                }
            }
            return new List<ContactData>(contactCache);
        }
        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string secondaryHome = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthdayDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string birthdayMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string birthdayYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            string anniversaryDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string anniversaryMonth = driver.FindElement(By.Name("amonth")).FindElement(By.CssSelector("option[selected='selected']")).Text;
            string anniversaryYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");

            if (birthdayDay == "0")
                birthdayDay = null;
            if (anniversaryDay == "0")
                anniversaryDay = null;
            if (birthdayMonth == "-")
                birthdayMonth = null;
            if (anniversaryMonth == "-")
                anniversaryMonth = null;

            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                LastName = lastName,
                Nickname = nickname,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                SecondaryHome = secondaryHome,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                BirthdayDay = birthdayDay,
                BirthdayMonth = birthdayMonth,
                BirthdayYear = birthdayYear,
                AnniversaryDay = anniversaryDay,
                AnniversaryMonth = anniversaryMonth,
                AnniversaryYear = anniversaryYear,
                SecondaryAddress = address2,
                Notes = notes
            };
        }
        public ContactHelper ViewContactInformation(int index)
        {
            manager.Navigator.GoToHomePage();
            driver.FindElement(By.XPath("//img[@alt='Details'][" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactData GetContactInformationFromView(int index)
        {
            ViewContactInformation(index);
            string allData = driver.FindElement(By.Id("content")).Text;
            return new ContactData
            {
                AllData = allData
            };
        }
    }
}
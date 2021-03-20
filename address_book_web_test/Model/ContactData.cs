using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAdressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones, allEmails, allData; 

        public ContactData()
        {
        }

        public ContactData(string firstName)
        {
            FirstName = firstName;
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "last name = " + LastName + ", first name = " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            int compareLastName = string.Compare(LastName, other.LastName);
            if (compareLastName != 0)
            {
                return compareLastName;
            }

            return string.Compare(FirstName, other.FirstName);
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string BirthdayDay { get; set; }
        public string BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }
        public string AnniversaryDay { get; set; }
        public string AnniversaryMonth { get; set; }
        public string AnniversaryYear { get; set; }
        public string SecondaryAddress { get; set; }
        public string SecondaryHome { get; set; }
        public string Notes { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    var result = CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryHome);
                    return result.Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    var emails = new string[]
                    {
                        Email, Email2, Email3
                    };
                    var result = string.Join("\r\n", emails);
                    return result.Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public int? Age
        {
            get
            {
                if (BirthdayDay == null || BirthdayMonth == null || BirthdayYear == null)
                    return null;
                var birthdayString = $"{BirthdayDay} {BirthdayMonth} {BirthdayYear}";
                var birthdayDate = DateTime.Parse(birthdayString);
                var age = DateTime.Now - birthdayDate;
                return (int)(age.TotalDays / 365.2425);
            }
        }

        public int? AnniversaryYears
        {
            get
            {
                if (AnniversaryDay == null || AnniversaryMonth == null || AnniversaryYear == null)
                    return null;
                var anniversaryString = $"{AnniversaryDay} {AnniversaryMonth} {AnniversaryYear}";
                var anniversaryDate = DateTime.Parse(anniversaryString);
                var anniversaryYears = DateTime.Now - anniversaryDate;
                return (int)(anniversaryYears.TotalDays / 365.2425);
            }
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                var parts = new string[] {
                    $"{FirstName} {MiddleName} {LastName}",
                    Nickname,
                    Title,
                    Company,
                    Address,
                    "",
                    "H: " + HomePhone,
                    "M: " + MobilePhone,
                    "W: " + WorkPhone,
                    "F: " + Fax,
                    "",
                    Email,
                    Email2,
                    Email3,
                    "Homepage:",
                    Homepage,
                    "",
                    $"Birthday {BirthdayDay}. {BirthdayMonth} {BirthdayYear} ({Age})",
                    $"Anniversary {AnniversaryDay}. {AnniversaryMonth} {AnniversaryYear} ({AnniversaryYears})",
                    "",
                    SecondaryAddress,
                    "",
                    "P: " + SecondaryHome,
                    "",
                    Notes
                };
                var result = string.Join("\r\n", parts);
                return result;
            }
            set
            {
                allData = value;
            }
        }


        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, @"[ \-()]", "") + "\r\n";
        }
    }
}
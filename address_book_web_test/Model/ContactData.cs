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
                    string result = CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(SecondaryHome);
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
                    List<string> emails = new List<string>();
                    if (!string.IsNullOrEmpty(Email))
                        emails.Add(Email);
                    if (!string.IsNullOrEmpty(Email2))
                        emails.Add(Email2);
                    if (!string.IsNullOrEmpty(Email3))
                        emails.Add(Email3);

                    string result = string.Join("\r\n", emails);
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
                if (BirthdayYear == null)
                    return null;
                string birthdayDay = string.IsNullOrEmpty(BirthdayDay)
                    ? "1"
                    : BirthdayDay;
                string birthdayMonth = string.IsNullOrEmpty(BirthdayMonth)
                    ? "1"
                    : BirthdayMonth;

                string birthdayString = $"{birthdayDay} {birthdayMonth} {BirthdayYear}";
                DateTime birthdayDate = DateTime.Parse(birthdayString);
                TimeSpan age = DateTime.Now - birthdayDate;
                return (int)(age.TotalDays / 365.2425);
            }
        }

        public int? AnniversaryYears
        {
            get
            {
                if (AnniversaryYear == null)
                    return null;
                int anniversaryYear = int.Parse(AnniversaryYear);
                int result = DateTime.Now.Year - anniversaryYear;
                return result;
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
                List<string> parts = new List<string>();

                bool isNamePresent = !string.IsNullOrEmpty(FirstName) 
                    || !string.IsNullOrEmpty(MiddleName) 
                    || !string.IsNullOrEmpty(LastName);
                if (isNamePresent)
                {
                    List<string> fullNameParts = new List<string>();
                    if (!string.IsNullOrEmpty(FirstName))
                        fullNameParts.Add(FirstName);
                    if (!string.IsNullOrEmpty(MiddleName))
                        fullNameParts.Add(MiddleName);
                    if (!string.IsNullOrEmpty(LastName))
                        fullNameParts.Add(LastName);

                    string fullName = string.Join(" ", fullNameParts);
                    parts.Add(fullName);
                }

                if (!string.IsNullOrEmpty(Nickname))
                    parts.Add(Nickname);
                if (!string.IsNullOrEmpty(Title))
                    parts.Add(Title);
                if (!string.IsNullOrEmpty(Company))
                    parts.Add(Company);
                if (!string.IsNullOrEmpty(Address))
                    parts.Add(Address);

                bool arePhonesPresent = !string.IsNullOrEmpty(HomePhone) 
                    || !string.IsNullOrEmpty(MobilePhone) 
                    || !string.IsNullOrEmpty(WorkPhone) 
                    || !string.IsNullOrEmpty(Fax);
                if (arePhonesPresent)
                {
                    parts.Add(string.Empty);
                    if (!string.IsNullOrEmpty(HomePhone))
                        parts.Add("H: " + HomePhone);
                    if (!string.IsNullOrEmpty(MobilePhone))
                        parts.Add("M: " + MobilePhone);
                    if (!string.IsNullOrEmpty(WorkPhone))
                        parts.Add("W: " + WorkPhone);
                    if (!string.IsNullOrEmpty(Fax))
                        parts.Add("F: " + Fax);
                }

                bool areEmailsPresent = !string.IsNullOrEmpty(Email) 
                    || !string.IsNullOrEmpty(Email2) 
                    || !string.IsNullOrEmpty(Email3) 
                    || !string.IsNullOrEmpty(Homepage);
                if (areEmailsPresent)
                {
                    parts.Add(string.Empty);
                    if (!string.IsNullOrEmpty(Email))
                        parts.Add(Email);
                    if (!string.IsNullOrEmpty(Email2))
                        parts.Add(Email2);
                    if (!string.IsNullOrEmpty(Email3))
                        parts.Add(Email3);
                    if (!string.IsNullOrEmpty(Homepage))
                        parts.Add("Homepage:\r\n" + Homepage);
                }

                bool isBirthdayPresent = !string.IsNullOrEmpty(BirthdayDay) 
                    || !string.IsNullOrEmpty(BirthdayMonth) 
                    || !string.IsNullOrEmpty(BirthdayYear);
                bool isAnniversaryPresent = !string.IsNullOrEmpty(AnniversaryDay)
                    || !string.IsNullOrEmpty(AnniversaryMonth)
                    || !string.IsNullOrEmpty(AnniversaryYear);
                if (isBirthdayPresent || isAnniversaryPresent)
                {
                    parts.Add(string.Empty);

                    if (isBirthdayPresent)
                    {
                        List<string> birthdayParts = new List<string> { "Birthday" };

                        if (!string.IsNullOrEmpty(BirthdayDay))
                            birthdayParts.Add(BirthdayDay + ".");
                        if (!string.IsNullOrEmpty(BirthdayMonth))
                            birthdayParts.Add(BirthdayMonth);
                        if (!string.IsNullOrEmpty(BirthdayYear))
                        {
                            birthdayParts.Add(BirthdayYear);
                            birthdayParts.Add($"({Age})");
                        }

                        string birthday = string.Join(" ", birthdayParts);
                        parts.Add(birthday);
                    }

                    if (isAnniversaryPresent)
                    {
                        List<string> anniversaryParts = new List<string> { "Anniversary" };

                        if (!string.IsNullOrEmpty(AnniversaryDay))
                            anniversaryParts.Add(AnniversaryDay+ ".");
                        if (!string.IsNullOrEmpty(AnniversaryMonth))
                            anniversaryParts.Add(AnniversaryMonth);
                        if (!string.IsNullOrEmpty(AnniversaryYear))
                        {
                            anniversaryParts.Add(AnniversaryYear);
                            anniversaryParts.Add($"({AnniversaryYears})");
                        }

                        string anniversary = string.Join(" ", anniversaryParts);
                        parts.Add(anniversary);
                    }
                }

                if (!string.IsNullOrEmpty(SecondaryAddress))
                {
                    parts.Add(string.Empty);
                    parts.Add(SecondaryAddress);
                }

                if (!string.IsNullOrEmpty(SecondaryHome))
                {
                    parts.Add(string.Empty);
                    parts.Add("P: " + SecondaryHome);
                }

                if (!string.IsNullOrEmpty(Notes))
                {
                    parts.Add(string.Empty);
                    parts.Add(Notes);
                }

                string result = string.Join("\r\n", parts);
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
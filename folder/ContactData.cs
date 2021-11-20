using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public ContactData()
        {
        }

      /*  public ContactData(string text)
        {
            Firstname = text;
        }*/

        public ContactData(string text) => AllDetails = text;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;          
        }

        public ContactData(string firstname, string lastname, string mobile)
        {
            Firstname = firstname;
            Lastname = lastname;
            Mobile = mobile;
        }

        public ContactData(string firstname, string middlename, string lastname, string nickname, string photo, string title, string company, string address, string home, string mobile, string work, string fax, string email, string email2, string email3, string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear, string address2, string phone2, string notes)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Nickname = nickname;
            Photo = photo;
            Title = title;
            Company = company;
            Address = address;
            Home = home;
            Mobile = mobile;
            Work = work;
            Fax = fax;
            Email = email;
            Email2 = email2;
            Email3 = email3;
            Homepage = homepage;
            Bday = bday;
            Bmonth = bmonth;
            Byear = byear;
            Aday = aday;
            Amonth = amonth;
            Ayear = ayear;
            Notes = address2;
            Phone2 = phone2;
            Address2 = notes;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string Homepage { get; set; }
        public string Bday { get; set; }
        public string Bmonth { get; set; }
        public string Byear { get; set; }
        public string Aday { get; set; }
        public string Amonth { get; set; }
        public string Ayear { get; set; }
        public string Notes { get; set; }
        public string Phone2 { get; set; }
        public string Address2 { get; set; }
        public string id { get; set; }
        public string AllEmails {

            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {                   
                    return (PrepareEmail(Email) + PrepareEmail(Email2) + PrepareEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string PrepareEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
            //home.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + "\r\n";
        }

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
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
                }          
            }
          set 
            {
                allPhones = value;
            }         
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
            //home.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "") + "\r\n";
        }

        public string AllDetails
        {
            get
            {
                string text = @"{0} {1} {2}
{3}

{4}
{5}
{6}

H: {7}
M: {8}
W: {9}
F: {10}

{11}
{12}
{13}
Homepage:
{14}

Birthday {15}. {16} {17} ({18})
Anniversary {19}. {20} {21} ({22})

{23}

P: {24}

{25}";
                return string.Format(text,
                    Firstname, Middlename, Lastname,
                    Nickname,Title, Company, Address, Home, Mobile, Work, Fax,
                    Email, Email2, Email3, Homepage.Replace("https://", "").Replace("http://", ""),
                    Bday, Bmonth, Byear,
                    (DateTime.Now.Year - int.Parse(Byear)).ToString(),
                    Aday, Amonth, Ayear,
                    (DateTime.Now.Year - int.Parse(Ayear)).ToString(),
                    Address2, Phone2, Notes
                    );
            }
            set
            {
                allDetails = value;
            }
        }
        public int CompareTo(ContactData other)
        {
            //if the second object  is null, then our object is greater
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(other.Firstname, Firstname))

            {
                return Lastname.CompareTo(other.Lastname);
            }
            else
            { 
                return Firstname.CompareTo(other.Firstname);            
            }
                
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

            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname= " + Firstname +"\nLastname " +Lastname+ "\nMiddleName " + Middlename
                + "\nNickname " + Nickname + "\nTitle " + Title+ "" + "\nCompany " + Company +
                "\nAddress " + Address + "\nHome " + Home + "\nEmail " + Email+ "\nHomepage " + Homepage+
                "\nBday " + Bday + "\nBmonth "+ Bmonth + "\nByear " + Byear + "\nFax " + Fax;            
        }
    }
}

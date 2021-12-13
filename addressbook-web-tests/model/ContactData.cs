using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public ContactData()
        {
        }

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

        public ContactData(string firstname, string middlename, string lastname, string nickname, string title, string company, string address, string home, string mobile, string work, string fax, string email, string email2, string email3, string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear, string address2, string phone2, string notes)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Nickname = nickname;
            //Photo = photo;
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

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }


        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }


        [Column(Name = "photo")]
        public string Photo { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }


        [Column(Name = "address")]
        public string Address { get; set; }


        [Column(Name = "home")]
        public string Home { get; set; }


        [Column(Name = "mobile")]
        public string Mobile { get; set; }


        [Column(Name = "work")]
        public string Work { get; set; }


        [Column(Name = "fax")]
        public string Fax { get; set; }


        [Column(Name = "email")]
        public string Email { get; set; }


        [Column(Name = "email2")]
        public string Email2 { get; set; }


        [Column(Name = "email3")]
        public string Email3 { get; set; }


        [Column(Name = "homepage")]    
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "phone2")] 
        public string Phone2 { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "id"),PrimaryKey, Identity]
        public string id { get; set; }

        public static List<ContactData> GetContactsFromDB()
        {
            //Linq
            using
                    //create the connection to the DB
                    (AddressbookDB db = new AddressbookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }

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
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return                     
                        (prepareParagraph1(Firstname,Middlename,Lastname,Nickname, Title, Company,Address) +
                        prepareParagraph2(Home, Mobile, Work, Fax) +
                        prepareParagraph3(Email, Email2, Email3,Homepage) +
                        prepareParagraph4p1(Bday,Bmonth,Byear)+
                        prepareParagraph4p2(Aday, Amonth, Ayear) +
                        prepareParagraph5(Address2)+
                        prepareParagraph6(Phone2)+
                        prepareParagraph7(Notes)
                        ).Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        public string prepareParagraph1(string firstname, string middlename, string lastname, string nickname, string title, string company, string address)
        {

            string Tfirstname, Tmiddlename, Tlastname;


            if (!string.IsNullOrEmpty(firstname))
            {
                Tfirstname = firstname + " ";
            }
            else Tfirstname = "";

            if (!string.IsNullOrEmpty(middlename))
            {
                Tmiddlename = middlename + " ";
            }
            else Tmiddlename = "";

            if (!string.IsNullOrEmpty(lastname))
            {
                Tlastname = lastname;
            }
            else Tlastname = "";

            return Tfirstname + Tmiddlename + Tlastname + NewLineValue(nickname) + NewLineValue(title) + NewLineValue(company) + NewLineValue(address);
        }

        private string prepareParagraph2(string home, string mobile, string work, string fax)
        {
            string Hhome, Hmobile, Hwork, Hfax;

            if (!string.IsNullOrEmpty(home)) 
                {
                    Hhome = "H: " + home;
                }
            else Hhome = "";


            if (!string.IsNullOrEmpty(mobile))
                {
                     Hmobile = "M: " + mobile;
                }
            else Hmobile = "";

            if
                (!string.IsNullOrEmpty(work) )
                {
                     Hwork = "W: " + work;
                }
            else Hwork = "";

            if (!string.IsNullOrEmpty(fax))
                {
                    Hfax = "F: " + fax;
                }
            else Hfax = "";

            return NewParagraph(NextWithNewLine(Hhome) + NextWithNewLine(Hmobile) + NextWithNewLine(Hwork) + NextWithNewLine(Hfax));
        }

        private string prepareParagraph3(string email1, string email2, string email3, string homepage)
        {
           
            string Thomepage;

            if  (!string.IsNullOrEmpty(homepage))
            {
                Thomepage = "Homepage:" + "\r\n"+ homepage.Replace("http://", "").Replace("https://", "");
            }
            else Thomepage = "";

            return NewLineValue(NextWithNewLine((email1 ?? "")) + NextWithNewLine((email2 ?? "")) + NextWithNewLine((email3 ?? "")) + Thomepage);
        }

        private string prepareParagraph4p1(string bday, string bmonth, string byear)
        {
            string Tbyear;

            if (!string.IsNullOrEmpty(byear))
            {
                Tbyear = byear + " (" + (DateTime.Now.Year - int.Parse(byear)).ToString() + ")";
            }
            else Tbyear = "";

            string Tbday;

            if (!string.IsNullOrEmpty(bday) && (Convert.ToInt32(bday)!=0))
            {
                Tbday = bday + ". ";
            }
            else Tbday = "";

            string Tbmonth;

            if (!string.IsNullOrEmpty(bmonth) && bmonth != "-")
            {
                Tbmonth = bmonth + " ";
            }
            else Tbmonth = "";

            if (!string.IsNullOrEmpty(bday) || !string.IsNullOrEmpty(bmonth)|| !string.IsNullOrEmpty(byear))
            {
                return NewLineValue("Birthday ") + Tbday + Tbmonth  + Tbyear;
            }
            else return "";
        }
        private string prepareParagraph4p2(string aday, string amonth, string ayear)
        {
            string Tayear;

            if (!string.IsNullOrEmpty(ayear))
            {
                Tayear = ayear + " (" + (DateTime.Now.Year - int.Parse(ayear)).ToString() + ")";
            }                  
            else Tayear = "";

            string Taday;

            if (!string.IsNullOrEmpty(aday) && (Convert.ToInt32(aday) != 0))
            {
                Taday = aday + ". ";
            }
            else Taday = "";

            string Tamonth;

            if (!string.IsNullOrEmpty(amonth) && amonth != "-")
            {
                Tamonth = amonth + " ";
            }
            else Tamonth = "";

            if (!string.IsNullOrEmpty(aday) || !string.IsNullOrEmpty(amonth) || !string.IsNullOrEmpty(ayear))
            {                
                return NewLineValue("Anniversary ") + Taday + Tamonth + Tayear;
            }
            else return "";
        }

        private string prepareParagraph5(string address2)
        {
            if (!string.IsNullOrEmpty(address2))
            {
                return NewParagraph(address2); ;
            }
            else return "";           
        }

        private string prepareParagraph6( string phone2)
        {
            if (!string.IsNullOrEmpty(phone2))
            {
                return NewParagraph("P: "+phone2); ;
            }
            else return "";
        }
        private string prepareParagraph7( string notes)
        {
            if (!string.IsNullOrEmpty(notes))
            {
                return NewParagraph(notes); ;
            }
            else return "";
        }

        private string NewLineValue(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return "\r\n" + value;
            }
            else return "";
        }

        public string NextWithNewLine(string value)
        {
            if (value != null && value !="")
            {
                return  value + "\r\n";
            }
            else return "";               
        }

        public string NewParagraph(string value)
        {
            if (value != null && value != "")
            {
                return "\r\n\r\n"+ value;
            }
            else return "\r\n\r\n";
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

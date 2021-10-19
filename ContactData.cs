using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string photo;
        private string title;
        private string company;
        private string address;
        private string home;
        private string mobile;
        private string work;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepage;
        private string bday;
        private string bmonth;
        private string byear;
        private string aday;
        private string amonth;
        private string ayear;
        private string address2;
        private string phone2;
        private string notes;

        public ContactData(string firstname, string lastname, string mobile)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.mobile = mobile;
        }

        public ContactData(string firstname, string middlename, string lastname, string nickname, string photo, string title, string company, string address, string home, string mobile, string work, string fax, string email, string email2, string email3, string homepage, string bday, string bmonth, string byear, string aday, string amonth, string ayear, string address2, string phone2, string notes)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.photo = photo;
            this.title = title;
            this.company = company;
            this.address = address;
            this.home = home;
            this.mobile = mobile;
            this.work = work;
            this.fax = fax;
            this.email = email;
            this.email2 = email2;
            this.email3 = email3;
            this.homepage = homepage;
            this.bday = bday;
            this.bmonth = bmonth;
            this.byear = byear;
            this.aday = aday;
            this.amonth = amonth;
            this.ayear = ayear;
            this.address2 = address2;
            this.phone2 = phone2;
            this.notes = notes;
        }

        public string Firstname { get => firstname; set => firstname = value; }
        public string Middlename { get => middlename; set => middlename = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Title { get => title; set => title = value; }
        public string Company { get => company; set => company = value; }
        public string Address { get => address; set => address = value; }
        public string Home { get => home; set => home = value; }
        public string Mobile { get => mobile; set => mobile = value; }
        public string Work { get => work; set => work = value; }
        public string Fax { get => fax; set => fax = value; }
        public string Email { get => email; set => email = value; }
        public string Email2 { get => email2; set => email2 = value; }
        public string Email3 { get => email3; set => email3 = value; }
        public string Homepage { get => homepage; set => homepage = value; }
        public string Bday { get => bday; set => bday = value; }
        public string Bmonth { get => bmonth; set => bmonth = value; }
        public string Byear { get => byear; set => byear = value; }
        public string Aday { get => aday; set => aday = value; }
        public string Amonth { get => amonth; set => amonth = value; }
        public string Ayear { get => ayear; set => ayear = value; }
        public string Notes { get => notes; set => notes = value; }
        public string Phone2 { get => phone2; set => phone2 = value; }
        public string Address2 { get => address2; set => address2 = value; }
    }
}

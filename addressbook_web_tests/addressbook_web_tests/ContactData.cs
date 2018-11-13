using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbooktests
{
    class ContactData
    {
        private string firstname;
        private string lastname = " ";
        public ContactData(string firstname)
        {
            this.firstname = firstname;
                  }
        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
               lastname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return Middlename;
            }
            set
            {
                Middlename = value;
            }
        }
        public string Nickname
        {
            get
            {
                return Nickname;
            }
            set
            {
                Nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return Title;
            }
            set
            {
                Title = value;
            }
        }
        public string Company
        {
            get
            {
                return Company;
            }
            set
            {
                Company = value;
            }
        }
        public string Address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
            }
        }
        public string Home
        {
            get
            {
                return Home;
            }
            set
            {
                Home = value;
            }
        }
        public string Mobile
        {
            get
            {
                return Mobile;
            }
            set
            {
                Mobile = value;
            }
        }
        public string Work
        {
            get
            {
                return Work;
            }
            set
            {
                Work = value;
            }
        }
        public string Fax
        {
            get
            {
                return Fax;
            }
            set
            {
                Fax = value;
            }
        }
        public string Email
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }
        public string Email2
        {
            get
            {
                return Email2;
            }
            set
            {
                Email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return Email3;
            }
            set
            {
                Email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return Homepage;
            }
            set
            {
                Homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return Bday;
            }
            set
            {
                Bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return Bmonth;
            }
            set
            {
                Bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return Byear;
            }
            set
            {
                Byear = value;
            }
        }
        public string Aday
        {
            get
            {
                return Aday;
            }
            set
            {
                Aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return Amonth;
            }
            set
            {
                Amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return Ayear;
            }
            set
            {
                Ayear = value;
            }
        }
        public string Address2
        {
            get
            {
                return Address2;
            }
            set
            {
                Address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return Phone2;
            }
            set
            {
                Phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return Notes;
            }
            set
            {
                Notes = value;
            }
        }
    }
}
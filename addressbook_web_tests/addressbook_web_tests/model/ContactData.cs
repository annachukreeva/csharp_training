﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbooktests
{


    [Table(Name = "addressbook")]


    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {


        private string allPhones;
        private string allEmail;
        private string details;


        public ContactData()
        {

        }

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
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
            return Firstname == other.Firstname &&
                   Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname = " + Firstname + "; Lastname = " + Lastname;
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

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

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

       // [Column(Name = "id"), PrimaryKey, Identity]

        [Column(Name = "id"), PrimaryKey]

        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

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
                    return CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work).Trim();
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
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {
                    return Email + "\r\n" + Email2 + "\r\n" + Email3;
                }
            }
            set
            {
                allEmail = value;
            }
        }

        //private string CleanUp3(string email)
        // {
        // if (email == null || email == "")
        //  {
        //      return "";
        //  }
        //  return email.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        //}

        public string Anotes { get; set; }

        public string Details
        {
            get
            {
                if (details != null)
                {
                    return details;
                }
                else
                {
                    string details ="";
                    if ( Firstname != string.Empty)
                    { 
                        details = Firstname;
                    }
                    if ( Middlename != string.Empty)
                        details += " " + Middlename;
                    if (Lastname != string.Empty)
                        details += " " + Lastname ;
                    if (Nickname != string.Empty)
                        details += "\r\n" + Nickname;
                    if (Title != string.Empty)
                        details += "\r\n" + Title;
                    if (Company != string.Empty)
                        details += "\r\n" + Company;
                    if (Address != string.Empty)
                        details += "\r\n" + Address;

                    details += "\r\n";

                    if (Home != string.Empty)
                        details += "\r\n" + "H: " + Home;
                    if (Mobile != string.Empty)
                        details += "\r\n" + "M: " + Mobile;
                    if (Work != string.Empty)
                        details += "\r\n" + "W: " + Work;
                    if (Fax != string.Empty)
                        details += "\r\n" + "F: " + Fax;

                    if ( Home+Mobile+Work+Fax != string.Empty)
                        details += "\r\n";

                    if (Email != string.Empty)
                        details += "\r\n" + Email;
                    if (Email2 != string.Empty)
                        details += "\r\n" + Email2;
                    if (Email3 != string.Empty)
                        details += "\r\n" + Email3;
                    if (Homepage != string.Empty )
                        details += "\r\n" + "Homepage:\r\n"+ Homepage;

                    return details;
                    //return Firstname + Lastname + Address + Home + Mobile + Work + Email + Email2 + Email3;
                }
            }
            set
            {
                details = value;
            }
        }
        public string CleanUp1(string details)
        {
            if (details == null || details == "")
            {
                return "";
            }
            return Regex.Replace(details, "[ -()", "") + "\r\n";
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts.Where(x => x.Deprecated =="0000-00-00 00:00:00") select g).ToList();
            }
        }
      
        }
}
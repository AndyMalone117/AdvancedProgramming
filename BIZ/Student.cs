using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Text.RegularExpressions;
using DAL;

namespace BIZ
{
    public class Student : AddData
    {
        public string Num { get; set; }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string Level { get; set; }

        public string Course { get; set; }

        

        public Student(string fname, string lname, string email, string phone, string address1,
            string address2, string city, string county, string level, string course)
        {
            FirstName = fname;
            Surname = lname;
            Email = email;
            Phone = phone;
            Address1 = address1;
            Address2 = address2;
            City = city;
            County = county;
            Level = level;
            Course = course;
        }

        public Student()
        {
        }

        //public bool Validate()
        //{
        //    bool valid = false;
        //    int firstNameLength = 0;
        //    int.TryParse(ConfigurationManager.AppSettings["FirstNameLength"], out firstNameLength);
        //    int surnameLength = 0;
        //    int.TryParse(ConfigurationManager.AppSettings["SurnameLength"], out surnameLength);

        //    string phoneRegEx = ConfigurationManager.AppSettings["PhoneRegEx"];
        //    string emailRegEx = ConfigurationManager.AppSettings["EmailRegEx"];


        //    if (FirstName.Length >= firstNameLength && Surname.Length >= surnameLength)
        //    {
        //        if (Regex.IsMatch(Email, emailRegEx) && Regex.IsMatch(Phone, phoneRegEx))
        //        {
        //            valid = true;
        //        }
        //    }

        //    return valid;
        //}

        public void addNewStudentToDB()
        {
            AddNewStudent(FirstName, Surname, Email, Phone, Address1, Address2, City, County, Level, Course);
        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (Commons.IsValidEmail(value))
                    email = value;
                else
                    throw new Exception("Invalid Email");
            }
        }



        DateTime date;


        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                var result = Commons.CalcAge(value);
                if (result > 150 || result < 0)
                    throw new Exception("Invalid age");
                date = value;
            }
        }

        public Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }

        public bool IsBirthDay
        {
            get
            {
                return DateTime.Now.Month == Date.Month &&
                    DateTime.Now.Day == Date.Day;
            }
        }

        public bool IsAdult
        {
            get
            {
                return Commons.CalcAge(Date) > 18;
            }
        }

        public string ChnZodiac()
        {
            return Commons.GetChineseZodiac(Date);
        }

        public string CalZodiac()
        {
            return Commons.GetCalenderZodiac(Date);
        }
    }
}

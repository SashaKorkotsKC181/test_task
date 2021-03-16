using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Person : IComparable<Person>
    {
        string[] mounths = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        string employeeName;
        DateTime date;
        double hours;
        public Person(string employeeName_, string date_, double hours_)
        {
            employeeName = employeeName_;
            hours = hours_;
            date = ConvertDate(date_);
            
        }
        private DateTime ConvertDate(string date_)
        {
            string[] inputDate = date_.Split(' ');
            for (int i = 0; i < mounths.Length; i++)
            {
                if (mounths[i] == inputDate[0])                    
                    return new DateTime(Convert.ToInt32(inputDate[2]), i + 1, Convert.ToInt32(inputDate[1]));
            }
            return new DateTime();
        }
        public int CompareTo(Person p)
        {
            return -this.date.CompareTo(p.date);
        }
        public override string ToString()
        {
            return employeeName + " " + date.ToShortDateString() + " " + hours.ToString();
        }
    }
}

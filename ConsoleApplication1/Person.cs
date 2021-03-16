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
        //DateTime date;
        //double hours;
        Dictionary<DateTime, double> work = new Dictionary<DateTime, double>();
        public Person(string employeeName_, string date_, double hours_)
        {
            employeeName = employeeName_;
            AddToPerson(date_, hours_);
        }
        public void AddToPerson(string date_, double hours_)
        {
            work.Add(ConvertDate(date_), hours_);
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
        public DateTime LastDate 
        {
            get
            {
                return work.Last().Key;
            }
        }
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }
        }
        public double this[DateTime workHours]
        {
            get
            {
                try
                {
                    return work[workHours];
                }
                catch(Exception)
                {
                    return 0;
                }
            }
        }
        public int CompareTo(Person p)
        {
            return this.employeeName.CompareTo(p.employeeName);
        }
        public override string ToString()
        {
            /*string ans;
            foreach (DateTime item in work)
            {
                ans += ans + work[item];
            }*/
            return employeeName;
        }
    }
}

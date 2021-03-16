using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Output(List<Person> people, SortedSet<DateTime> dateofwork)
        {
            StreamWriter write = new StreamWriter("output.csv", false, System.Text.Encoding.Default);
            string headers = "Name/Date";
            foreach (DateTime item in dateofwork)
            {
                headers += "," + item.ToShortDateString();
            }
            write.WriteLine(headers);

            foreach (Person i in people)
            {
                string row = i.EmployeeName;
                foreach (DateTime j in dateofwork)
                {
                    row += "," + i[j];
                }
                write.WriteLine(row);
            }
            write.Close();
        }
        static void Main(string[] args)
        {                   
            List<string> data = new List<string>();                        
            List<string> namePeople = new List<string>();
            List<Person> people = new List<Person>();
            SortedSet<DateTime> dateofwork = new SortedSet<DateTime>();
            StreamReader read = new StreamReader("acme_worksheet.csv"); 
            read.ReadLine();
            string[] rowOfArray = read.ReadLine().Split(',');
            while(true)
            {
                int check = namePeople.IndexOf(rowOfArray[0]);
                if (check < 0)
                {
                    people.Add(new Person(rowOfArray[0], rowOfArray[1], Convert.ToDouble(rowOfArray[2])));
                    namePeople.Add(rowOfArray[0]);
                    dateofwork.Add(people.Last().LastDate);
                }
                else
                {
                    people[check].AddToPerson(rowOfArray[1], Convert.ToDouble(rowOfArray[2]));
                    dateofwork.Add(people[check].LastDate);
                }

                

                try
                {
                    rowOfArray = read.ReadLine().Split(',');
                }
                catch (Exception)
                {
                    break;
                }
            }
            read.Close();
            people.Sort();
            Output(people, dateofwork);    
            //Console.ReadKey();
        }
    }
}

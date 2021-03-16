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
        static void Main(string[] args)
        {
            List<Person> mas = new List<Person>();
            StreamReader read = new StreamReader("acme_worksheet.csv");            
            List<string> data = new List<string>();
            read.ReadLine();
            string[] input = read.ReadLine().Split(',');

            while(input[0] != "")
            {
                mas.Add(new Person(input[0], input[1], Convert.ToDouble(input[2])));
                try
                {
                    input = read.ReadLine().Split(',');
                }
                catch (Exception)
                {
                    break;
                }

            }
            mas.Sort();
            Console.WriteLine(mas[263]);        
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.Model;

namespace Budweg.View
{
    public class Menu
    {
        public bool showMenu()
        {
            Console.Clear();
            Console.WriteLine("Her er en menu");
            UnderMenu underMenu = new UnderMenu();
            List<Employee> employees = new List<Employee>();
            Employee _employee = underMenu.registreEmployee();//undermenu metode
            employees.Add(_employee);
            for (int i = 0; i < employees.Count(); i++)
            {
                Console.WriteLine(employees[i].FullName);
            }
            Console.ReadKey();
            //if else switch menupunkter 
            Console.WriteLine("1: flow\n2: kontor\n3:kantinen med morten");
            string test = Console.ReadLine();
            bool valid = false;
            switch (test)
            {
                case "1":
                    underMenu.flowValid();//flow
                    break;
                case "2":
                    underMenu.officeValid();//kontor
                    break;
                case "3":
                    underMenu.kantinenValid();//kantinen
                    break;
                default:
                    Console.WriteLine("ikke gyldig");
                    return false;
            }

            return valid;
        }
    }
}

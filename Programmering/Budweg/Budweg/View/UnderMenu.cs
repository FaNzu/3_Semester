using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Budweg.Model;

namespace Budweg.View
{
    public class UnderMenu
    {
        public Employee registreEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("skriv dinne log in");
            Console.Write("id: ");
            employee.Id = int.Parse(Console.ReadLine());
            Console.Write("firstname: ");
            employee.FirstName = Console.ReadLine();
            Console.Write("lastname: ");
            employee.LastName = Console.ReadLine();
            return employee;//employee i registre
        }

        public bool flowValid()
        {
            string placement = "flow";
            Console.WriteLine("1: vaske\n2: renser\n3: pakkeriet");
            string test = Console.ReadLine();
            switch (test)
            {
                case "1":
                    Console.WriteLine(placement + "vaske"); //employee
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine(placement + "renser"); //employee
                    break;
                case "3":
                    Console.WriteLine(placement + "pakkeriet"); //employee
                    break;
                default:
                    Console.WriteLine("ikke gyldig");
                    break;
            }
            return true; //if valid undermenu return, ellers nej   
        }
        public bool officeValid()
        {
            string placement = "office";
            Console.WriteLine("1: hr\n2: ceo\n3: bogholder");
            string test = Console.ReadLine();
            switch (test)
            {
                case "1":
                    Console.WriteLine(placement + "hr"); //employee
                    break;
                case "2":
                    Console.WriteLine(placement + "ceo"); //employee
                    break;
                case "3":
                    Console.WriteLine(placement + "bogholder"); //employee
                    break;
                default:
                    Console.WriteLine("ikke gyldig");
                    return false;
            }
            return true; //if valid undermenu return, ellers nej   
        }
        public bool kantinenValid()
        {
            string placement = "kantinen";
            Console.WriteLine("1: opvasker\n2: assistent\n3: kok");
            string test = Console.ReadLine();
            switch (test)
            {
                case "1":
                    Console.WriteLine(placement + "opvasker"); //employee
                    break;
                case "2":
                    Console.WriteLine(placement + "assistent"); //employee
                    break;
                case "3":
                    Console.WriteLine(placement + "kok"); //employee
                    break;
                default:
                    Console.WriteLine("ikke gyldig");
                    return false;
            }
            return true; //if valid undermenu return, ellers nej   
        }
    }
}

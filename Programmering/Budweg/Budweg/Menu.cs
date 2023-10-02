using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg
{
    public class Menu
    {
        public bool showMenu()
        {
            Console.WriteLine("Her er en menu");
            UnderMenu underMenu = new UnderMenu();
            //if else switch menupunkter
            string test = Console.ReadLine();
            bool valid = false;
            if(test == "hej")
            {
                valid = underMenu.flowValid();
            }
            return valid;
        }
    }
}

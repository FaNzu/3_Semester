﻿using System;
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
            Console.WriteLine("1: flow\n2: kontor\n3:kantinen");
            string test = Console.ReadLine();
            bool valid = false;
            switch (test)
            {
                case "1":
                    underMenu.flowValid();//flow
                    break;
                case "2":
                    underMenu.flowValid();//kontor
                    break;
                case "3":
                    underMenu.flowValid();//kantinen
                    break;
                default:
                    Console.WriteLine("ikke gyldig");
                    break;
            }
            return valid;
        }
    }
}

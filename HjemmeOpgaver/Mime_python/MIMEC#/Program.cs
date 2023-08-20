using System;
using System.Collections.Generic;

namespace MimeTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            Dictionary<string, string> MIME = new Dictionary<string, string>();

            for (int i = 0; i < n; i++)
            {
                string[] keyValue = Console.ReadLine().Split();
                MIME[keyValue[0].ToLower()] = keyValue[1];
            }

            for (int _ = 0; _ < q; _++)
            {
                string[] name = Console.ReadLine().ToLower().Split('.');
                string extension = name.Length != 1 ? name[name.Length - 1] : "null";
                if (MIME.ContainsKey(extension))
                {
                    Console.WriteLine(MIME[extension]);
                }
                else
                {
                    Console.WriteLine("UNKNOWN");
                }
            }
        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace head
{
    class Program
    {
        static void Main(string[] args)
        {
            int pocet_radku = 10;
            string soubor = "";
            try
            {
                if (args.Count() > 0)
                {
                    if (args[0] == "/?")
                    {
                        Console.WriteLine("\nPrint the last 10 lines of each FILE to standard output.");
                        Console.WriteLine("\nUSAGE:\n   tail [OPTION] [FILE]");
                        Console.WriteLine("\nOPTIONS:\n   -n NUMBER | -NUMBER ........ Specify number of lines.\n   /? ......................... Display help.");
                        Console.WriteLine("\nAUTHOR:\n   Tom Milostny, PSA4");
                        return;
                    }
                    else if (args[0] == "-n" && args.Count() > 1) pocet_radku = Convert.ToInt32(args[1]);
                    else if (args[0].StartsWith("-")) pocet_radku = Convert.ToInt32(args[0].Remove(0, 1));

                    soubor = args[args.Count() - 1];
                    if (soubor.Contains("\"")) soubor = soubor.Remove(0, 1).Remove(soubor.Length - 1, 1);
                }

                List<string> vypis = new List<string>();
                if (File.Exists(soubor))
                {
                    StreamReader sr = new StreamReader(soubor);
                    while (!sr.EndOfStream) vypis.Add(sr.ReadLine());
                    sr.Close();
                }
                else
                {
                    string line;
                    for (int i = 0; (line = Console.ReadLine()) != null; i++) vypis.Add(line);
                }

                for (int i = vypis.Count() - pocet_radku; i < vypis.Count(); i++)
                {
                    if (i < 0) i = 0;
                    Console.WriteLine(vypis[i]);
                }
            }
            catch { Console.WriteLine("An error has occured. Use \"tail /?\" to display help."); }
        }
    }
}
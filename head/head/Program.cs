using System;
using System.Linq;
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
                        Console.WriteLine("\nPrint the first 10 lines of each FILE to standard output.");
                        Console.WriteLine("\nUSAGE:\n   head [OPTION] [FILE]");
                        Console.WriteLine("\nOPTIONS:\n   -n NUMBER | -NUMBER ........ Specify number of lines.\n   /? ......................... Display help.");
                        Console.WriteLine("\nAUTHOR:\n   Tom Milostny, PSA4");
                        return;
                    }
                    else if (args[0] == "-n" && args.Count() > 1) pocet_radku = Convert.ToInt32(args[1]);
                    else if (args[0].StartsWith("-")) pocet_radku = Convert.ToInt32(args[0].Remove(0, 1));

                    soubor = args.Last();
                    if (soubor.Contains("\"")) soubor = soubor.Remove(0, 1).Remove(soubor.Length - 1, 1);
                }

                if (File.Exists(soubor))
                {
                    StreamReader sr = new StreamReader(soubor);
                    for (int i = 0; !sr.EndOfStream && i < pocet_radku; i++) Console.WriteLine(sr.ReadLine());
                    sr.Close();
                }
                else
                {
                    string line;
                    for (int i = 0; (line = Console.ReadLine()) != null && i < pocet_radku; i++) Console.WriteLine(line);
                }
            }
            catch { Console.WriteLine("An error has occured. Use \"head /?\" to display help."); }
        }
    }
}
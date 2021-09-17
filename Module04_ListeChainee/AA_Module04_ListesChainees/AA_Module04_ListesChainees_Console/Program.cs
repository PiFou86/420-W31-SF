using Module04_ListesChainees;
using System;

namespace AA_Module04_ListesChainees_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ListeChainee<int> lc = new ListeChainee<int>();


            lc[0] = 12;
            Console.Out.WriteLine(lc[0]);

        }
    }
}

using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace Module07_Recursivite_PreparationCours
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo01.AfficherNombresDe1A_v1(3);
            Demo01.AfficherNombresDe1A_v2(3);
            Stopwatch sw1 = Stopwatch.StartNew();
            Console.Out.WriteLine(Demo01.Fibonacci_v1(40));
            sw1.Stop();
            Console.Out.WriteLine(sw1.ElapsedMilliseconds);
            sw1 = Stopwatch.StartNew();
            Console.Out.WriteLine(Demo01.Fibonacci_v2(40));
            sw1.Stop();
            Console.Out.WriteLine(sw1.ElapsedMilliseconds);

            Console.Out.WriteLine(Demo01.NombreElements_v1(new LinkedList<int>(new int[] {1, 2, 3, 4})));
            Console.Out.WriteLine(Demo01.NombreElements_v2(new LinkedList<int>(new int[] {1, 2, 3, 4})));
            Console.Out.WriteLine(Demo01.Maximum_v1(new LinkedList<int>(new int[] {1, 2, 42,  3, 4}), (v1, v2) => Math.Max(v1, v2) ));
            Console.Out.WriteLine(Demo01.Maximum_v2(new LinkedList<int>(new int[] {1, 2, 42, 3, 4}), (v1, v2) => Math.Max(v1, v2) ));
        }
    }
}

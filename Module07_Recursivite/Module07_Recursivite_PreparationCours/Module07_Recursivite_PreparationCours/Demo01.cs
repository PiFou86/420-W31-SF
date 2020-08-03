using System;

using System.Collections.Generic;

namespace Module07_Recursivite_PreparationCours
{
    public class Demo01
    {
        public static int Factorielle_v1(int p_n)
        {
            if (p_n < 0)
            {
                throw new ArgumentException("La valeur ne doit pas être négative", nameof(p_n));
            }

            // f(0) = 1
            if (p_n == 0)
            {
                return 1;
            }

            // f(n) = n * f(n – 1)
            return p_n * Factorielle_v1(p_n - 1);
        }

        public static int Factorielle_v2(int p_n)
        {
            if (p_n < 0)
            {
                throw new ArgumentException("La valeur ne doit pas être négative", nameof(p_n));
            }

            return Factorielle_v2_rec(p_n);
        }

        private static int Factorielle_v2_rec(int p_n)
        {
            if (p_n == 0)
            {
                return 1;
            }

            return p_n * Factorielle_v2_rec(p_n - 1);
        }

        public static int Factorielle_v3(int p_n)
        {
            if (p_n < 0)
            {
                throw new ArgumentException("La valeur ne doit pas être négative", nameof(p_n));
            }

            return Factorielle_v3_rec(p_n, 1);
        }

        private static int Factorielle_v3_rec(int p_n, int p_res)
        {
            if (p_n == 0)
            {
                return p_res;
            }
            return Factorielle_v3_rec(p_n - 1, p_res * p_n);
        }

        public static void AfficherNombresDe1A_v1(int p_n)
        {
            if (p_n < 1)
            {
                throw new ArgumentException("La valeur doit être supérieure à 0", nameof(p_n));
            }

            AfficherNombresDeA_v1_rec(1, p_n);
        }

        private static void AfficherNombresDeA_v1_rec(int p_de, int p_a)
        {
            Console.Out.WriteLine(p_de);

            if (p_de < p_a)
            {
                AfficherNombresDeA_v1_rec(p_de + 1, p_a);
            }
        }

        public static void AfficherNombresDe1A_v2(int p_n)
        {
            if (p_n < 1)
            {
                throw new ArgumentException("La valeur doit être supérieure à 0", nameof(p_n));
            }

            AfficherNombresDeA_v2_rec(p_n);
        }

        private static void AfficherNombresDeA_v2_rec(int p_n)
        {
            if (p_n > 1)
            {
                AfficherNombresDeA_v2_rec(p_n - 1);
            }

            Console.Out.WriteLine(p_n);
        }

        public static int CalculerSomme1An(int p_n)
        {
            if (p_n < 1)
            {
                throw new ArgumentException("La valeur doit être supérieure à 0", nameof(p_n));
            }

            return CalculerSomme1An_rec(p_n);
        }

        private static int CalculerSomme1An_rec(int p_n)
        {
            if (p_n == 1)
            {
                return 1;
            }

            return p_n + CalculerSomme1An_rec(p_n - 1);
        }

        public static long Fibonacci_v1(int p_n)
        {
            if (p_n < 0)
            {
                throw new ArgumentException("La valeur doit être supérieure à 0", nameof(p_n));
            }

            return Fibonacci_v1_rec(p_n);
        }

        private static long Fibonacci_v1_rec(int p_n)
        {
            if (p_n == 0)
            {
                return 0;
            }

            if (p_n == 1)
            {
                return 1;
            }

            return Fibonacci_v1_rec(p_n - 1) + Fibonacci_v1_rec(p_n - 2);
        }

        public static long Fibonacci_v2(int p_n)
        {
            if (p_n < 0)
            {
                throw new ArgumentException("La valeur doit être supérieure à 0", nameof(p_n));
            }

            if (p_n == 0)
            {
                return 0;
            }

            if (p_n == 1)
            {
                return 1;
            }

            return Fibonacci_v2_rec(p_n, 2, 0, 1);
        }

        private static long Fibonacci_v2_rec(int p_n, int p_currentN, long p_fibonMoins2, long p_fibonMoins1)
        {
            if (p_n == p_currentN)
            {
                return p_fibonMoins2 + p_fibonMoins1;
            }

            return Fibonacci_v2_rec(p_n, p_currentN + 1, p_fibonMoins1, p_fibonMoins2 + p_fibonMoins1);
        }

        public static int NombreElements_v1<TypeElement>(LinkedList<TypeElement> p_liste)
        {
            if (p_liste is null)
            {
                throw new ArgumentNullException(nameof(p_liste));
            }

            return NombreElements_v1_rec(p_liste.First);
        }

        private static int NombreElements_v1_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud)
        {
            if (p_noeud is null)
            {
                return 0;
            }

            return 1 + NombreElements_v1_rec(p_noeud.Next);
        }

        public static TypeElement Maximum_v1<TypeElement>(LinkedList<TypeElement> p_liste, Func<TypeElement, TypeElement, TypeElement> p_fctMax)
        {
            if (p_liste is null || p_liste.Count == 0)
            {
                throw new ArgumentOutOfRangeException("La liste ne doit pas être nulle ou vide", nameof(p_liste));
            }

            if (p_fctMax is null)
            {
                throw new ArgumentNullException(nameof(p_fctMax));
            }

            return Maximum_v1_rec<TypeElement>(p_liste.First, p_liste.First.Value, p_fctMax);
        }

        private static TypeElement Maximum_v1_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud, TypeElement p_maxCourant, Func<TypeElement, TypeElement, TypeElement> p_fctMax)
        {
            if (p_noeud is null)
            {
                return p_maxCourant;
            }

            return Maximum_v1_rec(p_noeud.Next, p_fctMax(p_maxCourant, p_noeud.Value), p_fctMax);
        }

        public static void ParcourirEtAppliquerFonction<TypeElement>(LinkedList<TypeElement> p_liste, Action<TypeElement> p_fct)
        {
            if (p_liste is null)
            {
                throw new ArgumentOutOfRangeException("La liste ne doit pas être nulle ou vide", nameof(p_liste));
            }

            if (p_fct is null)
            {
                throw new ArgumentNullException(nameof(p_fct));
            }

            ParcourirEtAppliquerFonction_rec(p_liste.First, p_fct);
        }

        private static void ParcourirEtAppliquerFonction_rec<TypeElement>(LinkedListNode<TypeElement> p_noeud, Action<TypeElement> p_fct)
        {
            if (p_noeud != null)
            {
                p_fct(p_noeud.Value);
                ParcourirEtAppliquerFonction_rec(p_noeud.Next, p_fct);
            }
        }

        public static TypeElement Maximum_v2<TypeElement>(LinkedList<TypeElement> p_liste, Func<TypeElement, TypeElement, TypeElement> p_fctMax)
        {
            if (p_liste is null || p_liste.Count == 0)
            {
                throw new ArgumentOutOfRangeException("La liste ne doit pas être nulle ou vide", nameof(p_liste));
            }

            if (p_fctMax is null)
            {
                throw new ArgumentNullException(nameof(p_fctMax));
            }

            TypeElement maximum = p_liste.First.Value;
            ParcourirEtAppliquerFonction<TypeElement>(p_liste, (v) => maximum = p_fctMax(maximum, v));

            return maximum;
        }

        public static int NombreElements_v2<TypeElement>(LinkedList<TypeElement> p_liste)
        {
            if (p_liste is null)
            {
                throw new ArgumentNullException(nameof(p_liste));
            }

            int nbElements = 0;
            ParcourirEtAppliquerFonction<TypeElement>(p_liste, (v) => nbElements++);

            return nbElements;
        }
    }
}
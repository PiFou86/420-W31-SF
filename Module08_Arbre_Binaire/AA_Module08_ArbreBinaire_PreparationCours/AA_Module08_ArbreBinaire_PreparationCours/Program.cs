using System;

namespace AA_Module08_ArbreBinaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Out.WriteLine(GenerateurArbreBinaire.ExempleArbre1().Hauteur);
            Console.Out.WriteLine();
            GenerateurArbreBinaire.ExempleArbre1().ParcoursPrefixe(v => Console.Out.WriteLine(v));
            Console.Out.WriteLine();
            GenerateurArbreBinaire.ExempleArbre1().ParcoursInfixe(v => Console.Out.WriteLine(v));
            Console.Out.WriteLine();
            GenerateurArbreBinaire.ExempleArbre1().ParcoursPostfixe(v => Console.Out.WriteLine(v));
            Console.Out.WriteLine();

            ArbreBinaireRecherche<int> abr = new ArbreBinaireRecherche<int>();
            abr.Inserer(-42);
            abr.Inserer(-10);
            abr.Inserer(0);
            abr.Inserer(15);
            abr.Inserer(23);
            abr.Inserer(42);

            Console.Out.WriteLine(abr.Rechercher(-23));
            Console.Out.WriteLine(abr.Rechercher(15));
        }
    }
}

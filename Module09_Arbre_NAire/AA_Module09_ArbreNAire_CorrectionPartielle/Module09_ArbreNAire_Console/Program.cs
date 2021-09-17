using Module09_ArbreNAire;
using System;
using System.Collections.Generic;
using System.IO;

namespace Module09_ArbreNAire_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ArbreAutoCompletion trie = Charger("liste.de.mots.francais.frgut.txt");

            List<string> lstPrefixeATrouver = new List<string>()
            {
                "ne",
                "zo",
                "ab",
                "zzz"
            };

            foreach (var prefixeACompleter in lstPrefixeATrouver)
            {
                Console.Out.WriteLine($"Complétion pour {prefixeACompleter}");
                List<string> lstPrefixesNe = trie.CompleterPrefixe(prefixeACompleter);
                lstPrefixesNe.ForEach(m => Console.Out.WriteLine($"  -> {m}"));
            }

        }

static ArbreAutoCompletion Charger(string p_nomFichierDictionnaire)
{
    if (string.IsNullOrWhiteSpace(p_nomFichierDictionnaire))
    {
        throw new ArgumentException("p_nomFichierDictionnaire");
    }

    ArbreAutoCompletion trie = new ArbreAutoCompletion();

    using (StreamReader sr = new StreamReader(p_nomFichierDictionnaire))
    {
        while (!sr.EndOfStream)
        {
            string mot = sr.ReadLine();
            mot = mot.Trim();
            if (!string.IsNullOrWhiteSpace(mot))
            {
                trie.AjouterMot(mot);
            }
        }

        sr.Close();
    }

    return trie;
}
    }
}

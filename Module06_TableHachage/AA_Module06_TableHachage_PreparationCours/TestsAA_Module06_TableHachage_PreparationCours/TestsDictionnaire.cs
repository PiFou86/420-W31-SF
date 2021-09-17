using AA_Module06_TableHachage_PreparationCours;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestsAA_Module06_TableHachage_PreparationCours
{
    public class TestsDictionnaire
    {
        [Fact]
        public void CtorDefaut_CreationSimple_DictionnaireVide()
        {
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>();

            dic.Count.Should().Be(0);
        }

        [Fact]
        public void CtorInitialisation_Copie3Element_Dictionnaire3Elements()
        {
            List<string> listeClefs = new List<string>() { "Un", "Deux", "Trois" };
            List<string> listeValeurs = new List<string>() { "1", "2", "3" };

            IEnumerable<KeyValuePair<string, string>> donnees = listeClefs.Zip(listeValeurs, (c, v) => new KeyValuePair<string, string>(c, v));
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>(donnees);

            dic.Count.Should().Be(3);
            dic.Keys.Should().BeEquivalentTo(listeClefs);
            dic.Values.Should().BeEquivalentTo(listeValeurs);
        }

        [Fact]
        public void Remove_SupprimerUnElementDe3Elements_Dictionnaire2Elements()
        {
            List<string> listeClefs = new List<string>() { "Un", "Deux", "Trois" };
            List<string> listeValeurs = new List<string>() { "1", "2", "3" };

            IEnumerable<KeyValuePair<string, string>> donnees = listeClefs.Zip(listeValeurs, (c, v) => new KeyValuePair<string, string>(c, v));
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>(donnees);

            bool res = dic.Remove("Un");

            dic.Count.Should().Be(2);
            dic.Keys.Should().BeEquivalentTo(listeClefs.Skip(1));
            dic.Values.Should().BeEquivalentTo(listeValeurs.Skip(1));
            res.Should().BeTrue();
        }

        [Fact]
        public void Remove_100Elements_NombreAleveole2DicVide()
        {
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>();
            for (int i = 0; i < 100; i++)
            {
                dic.Add(i.ToString(), "");
            }


            bool res = true;
            for (int i = 0; i < 100; i++)
            {
                res = res && dic.Remove(i.ToString());
            }


            res.Should().BeTrue();
            dic.Count.Should().Be(0);
        }

        [Fact]
        public void CopyTo_3ElementsVersTableau5Cases_DonneesCopiees()
        {
            List<string> listeClefs = new List<string>() { "Un", "Deux", "Trois" };
            List<string> listeValeurs = new List<string>() { "1", "2", "3" };

            IEnumerable<KeyValuePair<string, string>> donnees = listeClefs.Zip(listeValeurs, (c, v) => new KeyValuePair<string, string>(c, v));
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>(donnees);
            KeyValuePair<string, string>[] donneesDestination = new KeyValuePair<string, string>[5];

            dic.CopyTo(donneesDestination, 1);

            donneesDestination.Skip(1).Take(3).Should().BeEquivalentTo(donnees);
            donneesDestination[0].Should().Be(default(KeyValuePair<string, string>));
            donneesDestination[4].Should().Be(default(KeyValuePair<string, string>));
        }

        [Fact]
        public void CopyTo_3ElementsVersTableau3Cases_DonneesCopiees()
        {
            List<string> listeClefs = new List<string>() { "Un", "Deux", "Trois" };
            List<string> listeValeurs = new List<string>() { "1", "2", "3" };

            IEnumerable<KeyValuePair<string, string>> donnees = listeClefs.Zip(listeValeurs, (c, v) => new KeyValuePair<string, string>(c, v));
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>(donnees);
            KeyValuePair<string, string>[] donneesDestination = new KeyValuePair<string, string>[3];

            dic.CopyTo(donneesDestination, 0);

            donneesDestination.Should().BeEquivalentTo(donnees);
        }

        [Fact]
        public void CopyTo_3ElementsVersTableau2Cases_DonneesCopiees()
        {
            List<string> listeClefs = new List<string>() { "Un", "Deux", "Trois" };
            List<string> listeValeurs = new List<string>() { "1", "2", "3" };

            IEnumerable<KeyValuePair<string, string>> donnees = listeClefs.Zip(listeValeurs, (c, v) => new KeyValuePair<string, string>(c, v));
            Dictionnaire<string, string> dic = new Dictionnaire<string, string>(donnees);
            KeyValuePair<string, string>[] donneesDestination = new KeyValuePair<string, string>[2];

            Action action = (() => dic.CopyTo(donneesDestination, 0));
            action.Should().Throw<ArgumentException>();
        }

    }
}

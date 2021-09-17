using FluentAssertions;
using Module04_ListesChainees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace TestsModule04_ListesChainees
{
    public class TestsListeDoublementChainee
    {
        #region "Constructeur"
        [Fact]
        public void ctor_SansParametre_CapaciteParDefaut()
        {
            int nombreElementsAttendu = 0;

            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>();

            tcp.Count.Should().Be(nombreElementsAttendu);
        }

        [Fact]
        public void ctor_TableauVide_TableauVide()
        {
            int nombreElementsAttendu = 0;
            int[] tableauACopier = new int[] { };
            int[] tableauInitial = new int[] { };

            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(tableauACopier);

            tcp.Should().BeEquivalentTo(tableauACopier);
            tableauACopier.Should().BeEquivalentTo(tableauInitial);
            tcp.Count.Should().Be(nombreElementsAttendu);
        }

        [Fact]
        public void ctor_Tableau3Elements_3Elements()
        {
            int nombreElementsAttendu = 3;
            int[] tableauACopier = new int[] { 23, 42, 13 };
            int[] tableauInitial = new int[] { 23, 42, 13 };

            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(tableauACopier);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Should().BeEquivalentTo(tableauACopier);
            tableauACopier.Should().BeEquivalentTo(tableauInitial);
            tcp.Count.Should().Be(nombreElementsAttendu);
            tableauACopier[0] = 0;
            tcp[0].Should().Be(23);
        }
        #endregion

        #region "Opérateur index"
        [Fact]
        public void OpIndex_Tableau3Elements_ValeursOk()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 23, 42, 13 });

            int valeurCalculeeIdx0 = tcp[0];
            int valeurCalculeeIdx1 = tcp[1];
            int valeurCalculeeIdx2 = tcp[2];

            valeurCalculeeIdx0.Should().Be(23);
            valeurCalculeeIdx1.Should().Be(42);
            valeurCalculeeIdx2.Should().Be(13);
        }

        [Fact]
        public void OpIndex_Tableau3ElementsAccesHorsLimites_Erreur()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 23, 42, 13 });

            tcp.Invoking(t => t[-2]).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t[-1]).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t[3]).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t[4]).Should().Throw<IndexOutOfRangeException>();
        }
        #endregion

        #region "Add"
        [Fact]
        public void Add_TableauVide_Tableau1Element1()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>();
            int valeurAAjouter = 225;
            int nombreElementsAttendu = 1;

            tcp.Add(valeurAAjouter);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp[0].Should().Be(valeurAAjouter);
        }

        [Fact]
        public void Add_Tableau3Elements_Tableau4ElementsAjouteEnFin()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 23, 42, 13 });
            int valeurAAjouter = 225;
            int nombreElementsAttendu = 4;

            tcp.Add(valeurAAjouter);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp[3].Should().Be(valeurAAjouter);
        }

        #endregion

        #region "RemoveAt"
        [Fact]
        public void RemoveAt_Tableau3ElementsHorsLimites_Exception()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 23, 42, 13 });

            tcp.Invoking(t => t.RemoveAt(-2)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.RemoveAt(-1)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.RemoveAt(3)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.RemoveAt(4)).Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void RemoveAt_Tableau3ElementsRemoveAt0_Tablea24Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 42, 10 };
            int position = 0;
            int nombreElementsAttendu = 2;

            tcp.RemoveAt(position);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void RemoveAt_Tableau3ElementsRemoveAt1_Tableau2Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 10 };
            int position = 1;
            int nombreElementsAttendu = 2;

            tcp.RemoveAt(position);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void RemoveAt_Tableau3ElementsRemoveAt2_Tableau2Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 42 };
            int position = 2;
            int nombreElementsAttendu = 2;

            tcp.RemoveAt(position);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }
        #endregion

        #region "Insert"
        [Fact]
        public void Insert_Tableau3ElementsHorsLimites_Exception()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 23, 42, 13 });

            tcp.Invoking(t => t.Insert(-2, 123)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.Insert(-1, 123)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.Insert(4, 123)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.Insert(5, 123)).Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Insert_TableauVide_Tableau1Element()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>();
            int[] collectionAttendue = new int[] { 23 };
            int valeurAInserer = 23;
            int position = 0;
            int nombreElementsAttendu = 1;

            tcp.Insert(position, valeurAInserer);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
            tcp.Reverse().Should().BeEquivalentTo(collectionAttendue.Reverse());
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert0_Tableau4Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 23, 13, 42, 10 };
            int valeurAInserer = 23;
            int position = 0;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
            tcp.Reverse().Should().BeEquivalentTo(collectionAttendue.Reverse());
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert1_Tableau4Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 23, 42, 10 };
            int valeurAInserer = 23;
            int position = 1;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
            tcp.Reverse().Should().BeEquivalentTo(collectionAttendue.Reverse());
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert2_Tableau4Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 42, 23, 10 };
            int valeurAInserer = 23;
            int position = 2;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
            tcp.Reverse().Should().BeEquivalentTo(collectionAttendue.Reverse());
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert3_Tableau4Elements()
        {
            ListeDoublementChainee<int> tcp = new ListeDoublementChainee<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 42, 10, 23 };
            int valeurAInserer = 23;
            int position = 3;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            EstStructureListeDoublementChaineeValide(tcp).Should().BeTrue();
            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
            tcp.Reverse().Should().BeEquivalentTo(collectionAttendue.Reverse());
        }

        #endregion

        #region "Utilitaires"
        private bool EstStructureListeDoublementChaineeValide<TypeElement>(ListeDoublementChainee<TypeElement> p_collection)
        {
            bool estValide = (p_collection.Count == 0
                           && p_collection.PremierNoeud == null
                           && p_collection.DernierNoeud == null)
                ||           (p_collection.Count != 0
                           && p_collection.PremierNoeud != null
                           && p_collection.DernierNoeud != null);

            NoeudListeDoublementChainee<TypeElement> noeudCourant = p_collection.PremierNoeud;
            NoeudListeDoublementChainee<TypeElement> noeudPrecedentCourant = null;
            estValide = estValide && noeudCourant.Precedent == null;
            while (estValide && noeudCourant != null)
            {
                if (noeudCourant.Suivant != null)
                {
                    estValide = noeudCourant.Suivant.Precedent == noeudCourant;
                }

                noeudPrecedentCourant = noeudCourant;
                noeudCourant = noeudCourant.Suivant;
            }

            estValide = estValide && p_collection.DernierNoeud == noeudPrecedentCourant;

            return estValide;
        }
        #endregion
    }
}

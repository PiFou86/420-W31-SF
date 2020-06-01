using AA_Module03_TableauACapaciteVariable;
using FluentAssertions;
using System;
using Xunit;

namespace TestsAA_Module03_TableauACapaciteVariable
{
    public class TestsTableauCapaciteVariable
    {
        #region "Constructeur"
        [Fact]
        public void ctor_SansParametre_CapaciteParDefaut()
        {
            int capaciteAttendue = 1;
            int nombreElementsAttendu = 0;

            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>();

            tcp.Capacity.Should().Be(capaciteAttendue);
            tcp.Count.Should().Be(nombreElementsAttendu);
        }

        [Fact]
        public void ctor_CapaciteDemandeeNeg_Exception()
        {
            int capaciteDemandee = -1;

            Action act = () => new TableauCapaciteVariable<int>(capaciteDemandee);

            act.Should().Throw<ArgumentOutOfRangeException>().And.ParamName.Should().Be("p_capacite");
        }

        [Fact]
        public void ctor_CapaciteDemandeeZero_CapaciteZero()
        {
            int capaciteAttendue = 0;
            int nombreElementsAttendu = 0;
            int capaciteDemandee = 0;

            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(capaciteDemandee);

            tcp.Capacity.Should().Be(capaciteAttendue);
            tcp.Count.Should().Be(nombreElementsAttendu);
        }

        [Fact]
        public void ctor_CapaciteDemandee500_Capacite500()
        {
            int capaciteAttendue = 500;
            int nombreElementsAttendu = 0;
            int capaciteDemandee = 500;

            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(capaciteDemandee);

            tcp.Capacity.Should().Be(capaciteAttendue);
            tcp.Count.Should().Be(nombreElementsAttendu);
        }


        [Fact]
        public void ctor_TableauVide_TableauVide()
        {
            int capaciteAttendue = 0;
            int nombreElementsAttendu = 0;
            int[] tableauACopier = new int[] { };
            int[] tableauInitial = new int[] { };

            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(tableauACopier);

            tcp.Should().BeEquivalentTo(tableauACopier);
            tableauACopier.Should().BeEquivalentTo(tableauInitial);
            tcp.Capacity.Should().Be(capaciteAttendue);
            tcp.Count.Should().Be(nombreElementsAttendu);
        }

        [Fact]
        public void ctor_Tableau3Elements_3Elements()
        {
            int capaciteAttendue = 3;
            int nombreElementsAttendu = 3;
            int[] tableauACopier = new int[] { 23, 42, 13 };
            int[] tableauInitial = new int[] { 23, 42, 13 };

            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(tableauACopier);

            tcp.Should().BeEquivalentTo(tableauACopier);
            tableauACopier.Should().BeEquivalentTo(tableauInitial);
            tcp.Capacity.Should().Be(capaciteAttendue);
            tcp.Count.Should().Be(nombreElementsAttendu);
            tableauACopier[0] = 0;
            tcp[0].Should().Be(23);
        }
        #endregion

        #region "Opérateur index"
        [Fact]
        public void OpIndex_Tableau3Elements_ValeursOk()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 23, 42, 13 });

            int valeurCalculeeIdx0 = tcp[0];
            int valeurCalculeeIdx1 = tcp[1];
            int valeurCalculeeIdx2 = tcp[2];

            valeurCalculeeIdx0.Should().Be(23);
            valeurCalculeeIdx1.Should().Be(42);
            valeurCalculeeIdx2.Should().Be(13);
        }

        [Fact]
        public void OpIndex_Tableau3ElementsAccesHorsLimites_Erreur()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 23, 42, 13 });

            tcp.Invoking(t => t[-2]).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t[-1]).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t[3]).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t[4]).Should().Throw<IndexOutOfRangeException>();
        }
        #endregion

        #region "Add"
        [Fact]
        public void Add_TableauVide_Tableau1Element1()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>();
            int valeurAAjouter = 225;
            int nombreElementsAttendu = 1;

            tcp.Add(valeurAAjouter);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp[0].Should().Be(valeurAAjouter);
        }

        [Fact]
        public void Add_Tableau3Elements_Tableau4ElementsAjouteEnFin()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 23, 42, 13 });
            int valeurAAjouter = 225;
            int nombreElementsAttendu = 4;

            tcp.Add(valeurAAjouter);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp[3].Should().Be(valeurAAjouter);
        }

        #endregion

        #region "RemoveAt"
        [Fact]
        public void RemoveAt_Tableau3ElementsHorsLimites_Exception()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 23, 42, 13 });

            tcp.Invoking(t => t.RemoveAt(-2)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.RemoveAt(-1)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.RemoveAt(3)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.RemoveAt(4)).Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void RemoveAt_Tableau3ElementsRemoveAt0_Tablea24Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10});
            int[] collectionAttendue = new int[] { 42, 10};
            int position = 0;
            int nombreElementsAttendu = 2;

            tcp.RemoveAt(position);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void RemoveAt_Tableau3ElementsRemoveAt1_Tableau2Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 10 };
            int position = 1;
            int nombreElementsAttendu = 2;

            tcp.RemoveAt(position);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void RemoveAt_Tableau3ElementsRemoveAt2_Tableau2Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 42 };
            int position = 2;
            int nombreElementsAttendu = 2;

            tcp.RemoveAt(position);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }
        #endregion

        #region "Insert"
        [Fact]
        public void Insertt_Tableau3ElementsHorsLimites_Exception()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 23, 42, 13 });

            tcp.Invoking(t => t.Insert(-2, 123)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.Insert(-1, 123)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.Insert(4, 123)).Should().Throw<IndexOutOfRangeException>();
            tcp.Invoking(t => t.Insert(5, 123)).Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void Insert_TableauVide_Tableau1Element()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>();
            int[] collectionAttendue = new int[] { 23 };
            int valeurAInserer = 23;
            int position = 0;
            int nombreElementsAttendu = 1;

            tcp.Insert(position, valeurAInserer);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert0_Tableau4Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 23, 13, 42, 10 };
            int valeurAInserer = 23;
            int position = 0;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert1_Tableau4Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 23, 42, 10 };
            int valeurAInserer = 23;
            int position = 1;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert2_Tableau4Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 42, 23, 10 };
            int valeurAInserer = 23;
            int position = 2;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }

        [Fact]
        public void Insert_Tableau3ElementsInsert3_Tableau4Elements()
        {
            TableauCapaciteVariable<int> tcp = new TableauCapaciteVariable<int>(new int[] { 13, 42, 10 });
            int[] collectionAttendue = new int[] { 13, 42, 10, 23 };
            int valeurAInserer = 23;
            int position = 3;
            int nombreElementsAttendu = 4;

            tcp.Insert(position, valeurAInserer);

            tcp.Count.Should().Be(nombreElementsAttendu);
            tcp.Should().BeEquivalentTo(collectionAttendue);
        }
        #endregion
    }
}

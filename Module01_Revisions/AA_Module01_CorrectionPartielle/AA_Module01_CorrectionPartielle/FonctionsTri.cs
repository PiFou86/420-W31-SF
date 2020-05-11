using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Module01_CorrectionPartielle
{
    public static class FonctionsTri
    {
        #region "Tri IComparable et Equals"
        #region "Tri à bulles"
        public static List<TypeElement> TriBulles<TypeElement>(List<TypeElement> p_valeurs) where TypeElement : IComparable<TypeElement>
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            TypeElement ancienneValeur = default(TypeElement);
            bool permutationAuDernierTour = true;
            int indiceMax = p_valeurs.Count - 1;
            List<TypeElement> valeursCopiees = CopierListe(p_valeurs);

            while (permutationAuDernierTour)
            {
                permutationAuDernierTour = false;
                for (int indiceCourant = 0; indiceCourant <= indiceMax - 1; ++indiceCourant)
                {
                    if (valeursCopiees[indiceCourant + 1].CompareTo(valeursCopiees[indiceCourant]) < 0)
                    {
                        ancienneValeur = valeursCopiees[indiceCourant + 1];
                        valeursCopiees[indiceCourant + 1] = valeursCopiees[indiceCourant];
                        valeursCopiees[indiceCourant] = ancienneValeur;
                        permutationAuDernierTour = true;
                    }
                }
                indiceMax = indiceMax - 1;
            }

            return valeursCopiees;
        }
        #endregion

        #region "Tri rapide"
        public static List<TypeElement> TriRapide<TypeElement>(List<TypeElement> p_valeurs) where TypeElement : IComparable<TypeElement>
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            List<TypeElement> valeursCopiees = CopierListe(p_valeurs);

            TriRapide(valeursCopiees, 0, valeursCopiees.Count - 1);

            return valeursCopiees;
        }

        private static void TriRapide<TypeElement>(List<TypeElement> p_valeurs, int p_indicePremier, int p_indiceDernier) where TypeElement : IComparable<TypeElement>
        {
            int indicePivot = 0;
            if (p_indicePremier < p_indiceDernier)
            {
                indicePivot = ChoixPivot(p_valeurs, p_indicePremier, p_indiceDernier);
                indicePivot = Partitionner(p_valeurs, p_indicePremier, p_indiceDernier, indicePivot);
                TriRapide(p_valeurs, p_indicePremier, indicePivot - 1);
                TriRapide(p_valeurs, indicePivot + 1, p_indiceDernier);
            }
        }

        // Version simple
        private static int ChoixPivot<TypeElement>(List<TypeElement> p_valeurs, int p_indicePremier, int p_indiceDernier)
        {
            return p_indicePremier;
        }

        private static int Partitionner<TypeElement>(List<TypeElement> p_valeurs, int p_indicePremier, int p_indiceDernier, int p_indicePivot) where TypeElement : IComparable<TypeElement>
        {
            // échange le pivot avec le dernier du tableau , le pivot devient le dernier du tableau 
            TypeElement ancienneValeur = default(TypeElement);
            int futurIndicePivot = p_indicePremier;

            ancienneValeur = p_valeurs[p_indicePivot];
            p_valeurs[p_indicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            for (int indiceValeurARanger = p_indicePremier; indiceValeurARanger <= p_indiceDernier - 1; ++indiceValeurARanger)
            {
                if (p_valeurs[indiceValeurARanger].CompareTo(p_valeurs[p_indiceDernier]) <= 0)
                {
                    ancienneValeur = p_valeurs[futurIndicePivot];
                    p_valeurs[futurIndicePivot] = p_valeurs[indiceValeurARanger];
                    p_valeurs[indiceValeurARanger] = ancienneValeur;

                    futurIndicePivot = futurIndicePivot + 1;
                }
            }

            ancienneValeur = p_valeurs[futurIndicePivot];
            p_valeurs[futurIndicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            return futurIndicePivot;
        }
        #endregion

        #region "Fonctions utilitaires"
        public static List<TypeElement> CopierListe<TypeElement>(List<TypeElement> p_valeurs)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            return p_valeurs.Select(e => e).ToList();
        }

        public static bool EstTrie<TypeElement>(List<TypeElement> p_valeurs) where TypeElement : IComparable<TypeElement>
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            bool estTrie = true;
            for (int indiceValeur = 0;
                estTrie && indiceValeur < p_valeurs.Count - 1;
                ++indiceValeur)
            {
                if (p_valeurs[indiceValeur].CompareTo(p_valeurs[indiceValeur + 1]) > 0)
                {
                    estTrie = false;
                }
            }
            return estTrie;
        }
        #endregion
        #endregion

        #region "Tri lambda"
        #region "Tri à bulles"
        public static List<TypeElement> TriBulles<TypeElement>(List<TypeElement> p_valeurs, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            if (p_estPlusPetitEgaleA == null)
            {
                throw new ArgumentNullException(nameof(p_estPlusPetitEgaleA));
            }

            TypeElement ancienneValeur = default(TypeElement);
            bool permutationAuDernierTour = true;
            int indiceMax = p_valeurs.Count - 1;
            List<TypeElement> valeursCopiees = CopierListe(p_valeurs);

            while (permutationAuDernierTour)
            {
                permutationAuDernierTour = false;
                for (int indiceCourant = 0; indiceCourant <= indiceMax - 1; ++indiceCourant)
                {
                    if (p_estPlusPetitEgaleA(valeursCopiees[indiceCourant + 1], valeursCopiees[indiceCourant]))
                    {
                        ancienneValeur = valeursCopiees[indiceCourant + 1];
                        valeursCopiees[indiceCourant + 1] = valeursCopiees[indiceCourant];
                        valeursCopiees[indiceCourant] = ancienneValeur;
                        permutationAuDernierTour = true;
                    }
                }
                indiceMax = indiceMax - 1;
            }

            return valeursCopiees;
        }
        #endregion

        #region "Tri rapide"
        public static List<TypeElement> TriRapide<TypeElement>(List<TypeElement> p_valeurs, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }
            if (p_estPlusPetitEgaleA == null)
            {
                throw new ArgumentNullException(nameof(p_estPlusPetitEgaleA));
            }

            List<TypeElement> valeursCopiees = CopierListe(p_valeurs);

            TriRapide(valeursCopiees, 0, valeursCopiees.Count - 1, p_estPlusPetitEgaleA);

            return valeursCopiees;
        }

        private static void TriRapide<TypeElement>(List<TypeElement> p_valeurs, int p_indicePremier, int p_indiceDernier, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA)
        {
            int indicePivot = 0;
            if (p_indicePremier < p_indiceDernier)
            {
                indicePivot = ChoixPivot(p_valeurs, p_indicePremier, p_indiceDernier);
                indicePivot = Partitionner(p_valeurs, p_indicePremier, p_indiceDernier, indicePivot, p_estPlusPetitEgaleA);
                TriRapide(p_valeurs, p_indicePremier, indicePivot - 1, p_estPlusPetitEgaleA);
                TriRapide(p_valeurs, indicePivot + 1, p_indiceDernier, p_estPlusPetitEgaleA);
            }
        }

        private static int Partitionner<TypeElement>(List<TypeElement> p_valeurs, int p_indicePremier, int p_indiceDernier, int p_indicePivot, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA)
        {
            // échange le pivot avec le dernier du tableau , le pivot devient le dernier du tableau 
            TypeElement ancienneValeur = default(TypeElement);
            int futurIndicePivot = p_indicePremier;

            ancienneValeur = p_valeurs[p_indicePivot];
            p_valeurs[p_indicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            for (int indiceValeurARanger = p_indicePremier; indiceValeurARanger <= p_indiceDernier - 1; ++indiceValeurARanger)
            {
                if (p_estPlusPetitEgaleA(p_valeurs[indiceValeurARanger], p_valeurs[p_indiceDernier]))
                {
                    ancienneValeur = p_valeurs[futurIndicePivot];
                    p_valeurs[futurIndicePivot] = p_valeurs[indiceValeurARanger];
                    p_valeurs[indiceValeurARanger] = ancienneValeur;

                    futurIndicePivot = futurIndicePivot + 1;
                }
            }

            ancienneValeur = p_valeurs[futurIndicePivot];
            p_valeurs[futurIndicePivot] = p_valeurs[p_indiceDernier];
            p_valeurs[p_indiceDernier] = ancienneValeur;

            return futurIndicePivot;
        }
        #endregion

        #region "Fonctions utilitaires"
        public static bool EstTrie<TypeElement>(List<TypeElement> p_valeurs, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            if (p_estPlusPetitEgaleA == null)
            {
                throw new ArgumentNullException(nameof(p_estPlusPetitEgaleA));
            }

            bool estTrie = true;
            for (int indiceValeur = 0;
                estTrie && indiceValeur < p_valeurs.Count - 1;
                ++indiceValeur)
            {
                if (!p_estPlusPetitEgaleA(p_valeurs[indiceValeur], p_valeurs[indiceValeur + 1]))
                {
                    estTrie = false;
                }
            }
            return estTrie;
        }
        #endregion
        #endregion
        //Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA
    }
}

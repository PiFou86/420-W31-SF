using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module01_CorrectionPartielle
{
    public class FonctionsRecherche
    {
        #region "Recherche IComparable et Equals"
        public static bool RechercherValeurSimpleOptimisee<TypeElement>(List<TypeElement> p_collection, TypeElement p_valeurAChercher)
        {
            bool estTrouvee = false;
            int indiceValeurCourante = 0;
            while (!estTrouvee && indiceValeurCourante < p_collection.Count)
            {
                if (p_collection[indiceValeurCourante].Equals(p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                ++indiceValeurCourante;
            }

            return estTrouvee;
        }

        public static bool RechercherValeurDichotomie<TypeElement>(List<TypeElement> p_collection, TypeElement p_valeurAChercher) where TypeElement : IComparable<TypeElement>
        {
            bool estTrouvee = false;
            int indicePremier = 0;
            int indiceDernier = p_collection.Count - 1;
            int indiceMilieu = 0;

            while (!estTrouvee && indicePremier <= indiceDernier)
            {
                indiceMilieu = (indicePremier + indiceDernier) / 2;
                if (p_collection[indiceMilieu].Equals(p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                else if (p_collection[indiceMilieu].CompareTo(p_valeurAChercher) < 0)
                {
                    indicePremier = indiceMilieu + 1;
                }
                else
                {
                    indiceDernier = indiceMilieu - 1;
                }
            }

            return estTrouvee;
        }
        #endregion

        #region "Recherche avec lambda"
        public static bool RechercherValeurSimpleOptimisee<TypeElement>(List<TypeElement> p_collection, TypeElement p_valeurAChercher, Func<TypeElement, TypeElement, bool> p_sontEgales)
        {
            bool estTrouvee = false;
            int indiceValeurCourante = 0;
            while (!estTrouvee && indiceValeurCourante < p_collection.Count)
            {
                if (p_sontEgales(p_collection[indiceValeurCourante], p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                ++indiceValeurCourante;
            }

            return estTrouvee;
        }

        public static bool RechercherValeurDichotomie<TypeElement>(List<TypeElement> p_collection, TypeElement p_valeurAChercher, Func<TypeElement, TypeElement, bool> p_sontEgales, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA) 
        {
            bool estTrouvee = false;
            int indicePremier = 0;
            int indiceDernier = p_collection.Count - 1;
            int indiceMilieu = 0;

            while (!estTrouvee && indicePremier <= indiceDernier)
            {
                indiceMilieu = (indicePremier + indiceDernier) / 2;
                if (p_sontEgales(p_collection[indiceMilieu], p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                else if (p_estPlusPetitEgaleA(p_collection[indiceMilieu], p_valeurAChercher))
                {
                    indicePremier = indiceMilieu + 1;
                }
                else
                {
                    indiceDernier = indiceMilieu - 1;
                }
            }

            return estTrouvee;
        }
        #endregion
    }
}

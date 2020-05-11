using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module01_CorrectionPartielle
{
    public class FonctionsRecherche
    {
        #region "Recherche IComparable et Equals"
        public static bool RechercherValeurSimpleOptimisee<TypeElement>(List<TypeElement> p_valeurs, TypeElement p_valeurAChercher)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            bool estTrouvee = false;
            int indiceValeurCourante = 0;
            while (!estTrouvee && indiceValeurCourante < p_valeurs.Count)
            {
                if (p_valeurs[indiceValeurCourante].Equals(p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                ++indiceValeurCourante;
            }

            return estTrouvee;
        }

        public static bool RechercherValeurDichotomie<TypeElement>(List<TypeElement> p_valeurs, TypeElement p_valeurAChercher) where TypeElement : IComparable<TypeElement>
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            bool estTrouvee = false;
            int indicePremier = 0;
            int indiceDernier = p_valeurs.Count - 1;
            int indiceMilieu = 0;

            while (!estTrouvee && indicePremier <= indiceDernier)
            {
                indiceMilieu = (indicePremier + indiceDernier) / 2;
                if (p_valeurs[indiceMilieu].Equals(p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                else if (p_valeurs[indiceMilieu].CompareTo(p_valeurAChercher) < 0)
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
        public static bool RechercherValeurSimpleOptimisee<TypeElement>(List<TypeElement> p_valeurs, TypeElement p_valeurAChercher, Func<TypeElement, TypeElement, bool> p_sontEgales)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            if (p_sontEgales == null)
            {
                throw new ArgumentNullException(nameof(p_sontEgales));
            }
            
            bool estTrouvee = false;
            int indiceValeurCourante = 0;
            while (!estTrouvee && indiceValeurCourante < p_valeurs.Count)
            {
                if (p_sontEgales(p_valeurs[indiceValeurCourante], p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                ++indiceValeurCourante;
            }

            return estTrouvee;
        }

        public static bool RechercherValeurDichotomie<TypeElement>(List<TypeElement> p_valeurs, TypeElement p_valeurAChercher, Func<TypeElement, TypeElement, bool> p_sontEgales, Func<TypeElement, TypeElement, bool> p_estPlusPetitEgaleA)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            if (p_sontEgales == null)
            {
                throw new ArgumentNullException(nameof(p_sontEgales));
            }

            if (p_estPlusPetitEgaleA == null)
            {
                throw new ArgumentNullException(nameof(p_estPlusPetitEgaleA));
            }
            
            bool estTrouvee = false;
            int indicePremier = 0;
            int indiceDernier = p_valeurs.Count - 1;
            int indiceMilieu = 0;

            while (!estTrouvee && indicePremier <= indiceDernier)
            {
                indiceMilieu = (indicePremier + indiceDernier) / 2;
                if (p_sontEgales(p_valeurs[indiceMilieu], p_valeurAChercher))
                {
                    estTrouvee = true;
                }
                else if (p_estPlusPetitEgaleA(p_valeurs[indiceMilieu], p_valeurAChercher))
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

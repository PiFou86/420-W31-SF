using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module01_Preparation_Cours
{
    public static class ExtensionsListes
    {
        public static List<TypeElement> Filtrer<TypeElement>(this List<TypeElement> p_valeurs, Func<TypeElement, bool> p_aGarder)
        {
            List<TypeElement> valeursFiltrees = new List<TypeElement>();

            foreach (TypeElement valeur in p_valeurs)
            {
                if (p_aGarder(valeur))
                {
                    valeursFiltrees.Add(valeur);
                }
            }

            return valeursFiltrees;
        }
    }
}

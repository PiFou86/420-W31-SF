using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module08_ArbreBinaire
{
    public class GenerateurArbreBinaire
    {
        public static ArbreBinaire<int> ExempleArbre1()
        {
            return new ArbreBinaire<int>()
            {
                Racine = new NoeudArbreBinaire<int>()
                {
                    Gauche = new NoeudArbreBinaire<int>()
                    {
                        Gauche = new NoeudArbreBinaire<int>()
                        {
                            Gauche = null,
                            Droit = null,
                            Valeur = 1
                        },
                        Droit = new NoeudArbreBinaire<int>()
                        {
                            Gauche = null,
                            Droit = null,
                            Valeur = 3
                        },
                        Valeur = 2
                    },
                    Droit = new NoeudArbreBinaire<int>()
                    {
                        Gauche = null,
                        Droit = new NoeudArbreBinaire<int>()
                        {
                            Gauche = null,
                            Droit = null,
                            Valeur = 6
                        },
                        Valeur = 5
                    },
                    Valeur = 4
                }
            };
        }
    }
}

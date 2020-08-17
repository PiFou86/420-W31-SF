using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module08_ArbreBinaire
{
    public class ArbreBinaireRecherche<TypeElement> : ArbreBinaire<TypeElement> where TypeElement : IComparable<TypeElement>
    {
        public TypeElement Maximum()
        {
            if (this.Racine is null)
            {
                throw new InvalidOperationException();
            }

            return Maximum_rec(this.Racine);
        }

        private TypeElement Maximum_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud.Droit is null)
            {
                return p_noeud.Valeur;
            }

            return Maximum_rec(p_noeud.Droit);
        }

        public TypeElement Minimum()
        {
            if (this.Racine is null)
            {
                throw new InvalidOperationException();
            }

            return Minimum_rec(this.Racine);
        }

        private TypeElement Minimum_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud.Gauche is null)
            {
                return p_noeud.Valeur;
            }

            return Minimum_rec(p_noeud.Gauche);
        }

        public void Inserer(TypeElement p_valeur)
        {
            if (this.Racine is null)
            {
                this.Racine = new NoeudArbreBinaire<TypeElement>() { Valeur = p_valeur };
            }

            Inserer_rec(p_valeur, this.Racine);
        }

        private void Inserer_rec(TypeElement p_valeur, NoeudArbreBinaire<TypeElement> p_noeud)
        {
            int compare = p_valeur.CompareTo(p_noeud.Valeur);

            if (compare < 0)
            {
                if (p_noeud.Gauche is null)
                {
                    p_noeud.Gauche = new NoeudArbreBinaire<TypeElement>() { Valeur = p_valeur };
                } else
                {
                    Inserer_rec(p_valeur, p_noeud.Gauche);
                }

            } else if (compare == 0)
            {
                ; // Ici, j'ai choisi de ne pas insérer ce qui pourrait être considéré comme un doublon
            } else // > 0
            {
                if (p_noeud.Droit is null)
                {
                    p_noeud.Droit = new NoeudArbreBinaire<TypeElement>() { Valeur = p_valeur };
                }
                else
                {
                    Inserer_rec(p_valeur, p_noeud.Droit);
                }
            }
        }

        public bool Rechercher(TypeElement p_valeur)
        {
            return this.Rechercher_rec(p_valeur, this.Racine);
        }

        private bool Rechercher_rec(TypeElement p_valeur, NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud == null)
            {
                return false;
            }

            int compare = p_valeur.CompareTo(p_noeud.Valeur);
            if (compare == 0)
            {
                return true;
            }
            else if (compare < 0)
            {
                return Rechercher_rec(p_valeur, p_noeud.Gauche);
            }
            else
            {
                return Rechercher_rec(p_valeur, p_noeud.Droit);
            }

        }
    }
}

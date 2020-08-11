using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module08_ArbreBinaire
{
    public class ArbreBinaire<TypeElement>
    {
        public NoeudArbreBinaire<TypeElement> Racine { get; set; }

        // Méthodes de l'arbre

        public int Hauteur
        {
            get
            {
                return Hauteur_rec(this.Racine);
            }
        }

        private int Hauteur_rec(NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud is null)
            {
                return 0;
            }

            return 1 + Math.Max(Hauteur_rec(p_noeud.Gauche), Hauteur_rec(p_noeud.Droit));
        }

        public void ParcoursPrefixe(Action<TypeElement> p_traitement)
        {
            if (p_traitement is null)
            {
                throw new ArgumentNullException(nameof(p_traitement));
            }

            ParcoursPrefixe_rec(p_traitement, this.Racine);
        }

        private void ParcoursPrefixe_rec(Action<TypeElement> p_traitement, NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud != null)
            {
                p_traitement(p_noeud.Valeur);

                ParcoursPrefixe_rec(p_traitement, p_noeud.Gauche);
                ParcoursPrefixe_rec(p_traitement, p_noeud.Droit);
            }
        }

        public void ParcoursInfixe(Action<TypeElement> p_traitement)
        {
            if (p_traitement is null)
            {
                throw new ArgumentNullException(nameof(p_traitement));
            }

            ParcoursInfixe_rec(p_traitement, this.Racine);
        }

        private void ParcoursInfixe_rec(Action<TypeElement> p_traitement, NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud != null)
            {
                ParcoursInfixe_rec(p_traitement, p_noeud.Gauche);

                p_traitement(p_noeud.Valeur);

                ParcoursInfixe_rec(p_traitement, p_noeud.Droit);
            }
        }

        public void ParcoursPostfixe(Action<TypeElement> p_traitement)
        {
            if (p_traitement is null)
            {
                throw new ArgumentNullException(nameof(p_traitement));
            }

            ParcoursPostfixe_rec(p_traitement, this.Racine);
        }

        private void ParcoursPostfixe_rec(Action<TypeElement> p_traitement, NoeudArbreBinaire<TypeElement> p_noeud)
        {
            if (p_noeud != null)
            {
                ParcoursPostfixe_rec(p_traitement, p_noeud.Gauche);
                ParcoursPostfixe_rec(p_traitement, p_noeud.Droit);

                p_traitement(p_noeud.Valeur);
            }
        }
    }
}

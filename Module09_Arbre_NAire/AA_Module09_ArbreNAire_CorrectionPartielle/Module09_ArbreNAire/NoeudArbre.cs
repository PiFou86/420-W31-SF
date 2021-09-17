using System;
using System.Collections.Generic;
using System.Text;

namespace Module09_ArbreNAire
{
    public class NoeudArbre<TypeDonnee>
    {
        public NoeudArbre(TypeDonnee p_valeur)
        {
            this.Enfants = new List<NoeudArbre<TypeDonnee>>();
            this.Valeur = p_valeur;
        }

        public List<NoeudArbre<TypeDonnee>> Enfants { get; set; }
        public TypeDonnee Valeur { get; set; }
    }
}

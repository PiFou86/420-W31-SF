using System;
using System.Collections.Generic;
using System.Text;

namespace Module04_ListesChainees
{
    public class NoeudListeChainee<TypeElement>
    {
        public NoeudListeChainee(TypeElement p_element)
        {
            this.Valeur = p_element;
        }

        public TypeElement Valeur { get; set; }
        public NoeudListeChainee<TypeElement> Suivant { get; set; }
    }
}

using System;

namespace Module04_ListesChainees
{
    public class NoeudListeDoublementChainee<TypeElement>
    {
        public NoeudListeDoublementChainee(TypeElement p_element)
        {
            this.Valeur = p_element;
        }

        public TypeElement Valeur { get; set; }
        public NoeudListeDoublementChainee<TypeElement> Precedent { get; set; }
        public NoeudListeDoublementChainee<TypeElement> Suivant { get; set; }
    }
}

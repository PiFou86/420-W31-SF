using System.Collections;
using System.Collections.Generic;

namespace Module04_ListesChainees
{
    public class ReverseEnumeratorListeDoublementChainee<TypeElement> : IEnumerator<TypeElement>
    { 
        private NoeudListeDoublementChainee<TypeElement> m_noeudCourant = null;
        private ListeDoublementChainee<TypeElement> m_listeChainee;
        private TypeElement m_current;

        internal ReverseEnumeratorListeDoublementChainee(ListeDoublementChainee<TypeElement> p_listeChainee)
        {
            this.m_listeChainee = p_listeChainee;
            this.Reset();
        }

        public TypeElement Current
        {
            get
            {
                return this.m_current;
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            ;
        }

        public bool MoveNext()
        {
            bool continuer = this.m_noeudCourant != null;
            if (continuer)
            {
                this.m_current = this.m_noeudCourant.Valeur;
                this.m_noeudCourant = this.m_noeudCourant.Precedent;
            }

            return continuer;
        }

        public void Reset()
        {
            this.m_noeudCourant = this.m_listeChainee.DernierNoeud;
            this.m_current = default;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Module04_ListesChainees
{
    public class EnumeratorListeChainee<TypeElement> : IEnumerator<TypeElement>
    {
        private NoeudListeChainee<TypeElement> m_noeudCourant = null;
        private ListeChainee<TypeElement> m_listeChainee;
        private TypeElement m_current;

        internal EnumeratorListeChainee(ListeChainee<TypeElement> p_listeChainee)
        {
            this.m_listeChainee = p_listeChainee;
            this.Reset();
        }

        public TypeElement Current
        {
            get
            {
                return this.m_current;
            }
        }

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
            ;
        }

        public bool MoveNext()
        {
            bool continuer = this.m_noeudCourant != null;
            if (continuer)
            {
                this.m_current = this.m_noeudCourant.Valeur;
                this.m_noeudCourant = this.m_noeudCourant.Suivant;
            }

            return continuer;
        }

        public void Reset()
        {
            this.m_noeudCourant = this.m_listeChainee.PremierNoeud;
            this.m_current = default;
        }
    }
}

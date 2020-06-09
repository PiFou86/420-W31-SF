using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Module04_ListesChainees
{
    public class ListeDoublementChainee<TypeElement> : IList<TypeElement>, IEnumerable<TypeElement>
    {
        public int Count { get; private set; }
        public NoeudListeDoublementChainee<TypeElement> PremierNoeud { get; private set; }
        public NoeudListeDoublementChainee<TypeElement> DernierNoeud { get; private set; }

        public bool IsReadOnly => false;

        public TypeElement this[int p_indice]
        {
            get
            {
                if (p_indice < 0 || p_indice >= this.Count)
                {
                    throw new IndexOutOfRangeException(nameof(p_indice));
                }

                NoeudListeDoublementChainee<TypeElement> noeudCourant = this.PremierNoeud;
                for (int indiceCourant = 0; indiceCourant < p_indice; indiceCourant++)
                {
                    noeudCourant = noeudCourant.Suivant;
                }

                return noeudCourant.Valeur;
            }
            set
            {
                if (p_indice < 0 || p_indice >= this.Count)
                {
                    throw new IndexOutOfRangeException(nameof(p_indice));
                }

                NoeudListeDoublementChainee<TypeElement> noeudCourant = this.PremierNoeud;
                for (int indiceCourant = 0; indiceCourant < p_indice; indiceCourant++)
                {
                    noeudCourant = noeudCourant.Suivant;
                }

                noeudCourant.Valeur = value;
            }
        }

        public ListeDoublementChainee()
        {
            this.Clear();
        }

        public ListeDoublementChainee(IEnumerable<TypeElement> p_elements)
        {
            this.Clear();

            foreach (TypeElement element in p_elements)
            {
                this.Add(element);
            }
        }

        public int IndexOf(TypeElement p_element)
        {
            NoeudListeDoublementChainee<TypeElement> noeudCourant = this.PremierNoeud;
            int indexElement = -1;
            int indexCourant = 0;

            while (indexElement == -1 && noeudCourant != null)
            {
                if ((p_element == null && noeudCourant.Valeur == null)
                    || (p_element != null && p_element.Equals(noeudCourant.Valeur)))
                {
                    indexElement = indexCourant;
                }
                noeudCourant = noeudCourant.Suivant;
                indexCourant++;
            }

            return indexElement;
        }

        public void Insert(int p_indice, TypeElement p_element)
        {
            if (p_indice < 0 || p_indice > this.Count)
            {
                throw new IndexOutOfRangeException(nameof(p_indice));
            }

            if (p_indice == 0)
            {
                this.AddFirst(p_element);
            }
            else if (p_indice == this.Count)
            {
                this.Add(p_element);
            }
            else
            {
                this.InsertionReelle(p_indice, p_element);
            }
        }

        private void InsertionReelle(int p_indice, TypeElement p_element)
        {
            NoeudListeDoublementChainee<TypeElement> nouveauNoeud = new NoeudListeDoublementChainee<TypeElement>(p_element);

            NoeudListeDoublementChainee<TypeElement> noeudCourant = this.PremierNoeud;
            for (int indiceCourant = 0; indiceCourant < p_indice - 1; indiceCourant++)
            {
                noeudCourant = noeudCourant.Suivant;
            }

            nouveauNoeud.Precedent = noeudCourant;
            nouveauNoeud.Suivant = noeudCourant.Suivant;
            noeudCourant.Suivant = nouveauNoeud;

            if (nouveauNoeud.Suivant != null)
            {
                nouveauNoeud.Suivant.Precedent = nouveauNoeud;
            }

            this.Count++;
        }

        public void RemoveAt(int p_indice)
        {
            if (p_indice < 0 || p_indice >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(p_indice));
            }

            NoeudListeDoublementChainee<TypeElement> noeudCourant = this.PremierNoeud;
            for (int indiceCourant = 0; indiceCourant < p_indice; indiceCourant++)
            {
                noeudCourant = noeudCourant.Suivant;
            }

            if (noeudCourant.Precedent is null)
            {
                this.PremierNoeud = noeudCourant.Suivant;
            }
            else
            {
                noeudCourant.Precedent.Suivant = noeudCourant.Suivant;
            }

            if (noeudCourant.Suivant is null)
            {
                this.DernierNoeud = noeudCourant.Precedent;
            }
            else
            {
                noeudCourant.Suivant.Precedent = noeudCourant.Precedent;
            }

            this.Count--;
        }

        public void AddFirst(TypeElement p_element)
        {
            NoeudListeDoublementChainee<TypeElement> nouveauNoeud = new NoeudListeDoublementChainee<TypeElement>(p_element);

            nouveauNoeud.Suivant = this.PremierNoeud;
            this.PremierNoeud = nouveauNoeud;
            if (nouveauNoeud.Suivant != null)
            {
                nouveauNoeud.Suivant.Precedent = nouveauNoeud;
            }

            if (this.DernierNoeud is null)
            {
                this.DernierNoeud = nouveauNoeud;
            }

            this.Count++;
        }

        public void Add(TypeElement p_element)
        {
            NoeudListeDoublementChainee<TypeElement> nouveauNoeud = new NoeudListeDoublementChainee<TypeElement>(p_element);

            nouveauNoeud.Precedent = this.DernierNoeud;
            nouveauNoeud.Suivant = null;
            this.DernierNoeud = nouveauNoeud;

            if (nouveauNoeud.Precedent != null)
            {
                nouveauNoeud.Precedent.Suivant = nouveauNoeud;
            }

            if (this.PremierNoeud is null)
            {
                this.PremierNoeud = nouveauNoeud;
            }

            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
            this.PremierNoeud = null;
            this.DernierNoeud = null;
        }

        public bool Contains(TypeElement p_element)
        {
            return this.IndexOf(p_element) >= 0;
        }

        public void CopyTo(TypeElement[] p_destination, int p_indiceDebut)
        {
            if (p_destination is null)
            {
                throw new ArgumentNullException(nameof(p_indiceDebut));
            }

            if (p_indiceDebut < 0)
            {
                throw new IndexOutOfRangeException(nameof(p_indiceDebut));
            }

            if (p_destination.Length < this.Count + p_indiceDebut)
            {
                throw new ArgumentOutOfRangeException(nameof(p_indiceDebut));
            }

            NoeudListeDoublementChainee<TypeElement> noeudCourant = this.PremierNoeud;
            for (int indiceCourante = 0;
                noeudCourant != null && indiceCourante < this.Count;
                indiceCourante++)
            {
                p_destination[indiceCourante + p_indiceDebut] = noeudCourant.Valeur;

                noeudCourant = noeudCourant.Suivant;
            }
        }

        public bool Remove(TypeElement p_element)
        {
            int index = this.IndexOf(p_element);

            if (index >= 0)
            {
                this.RemoveAt(index);
            }

            return index >= 0;
        }

        public IEnumerator<TypeElement> GetEnumerator()
        {
            return new EnumeratorListeDoublementChainee<TypeElement>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<TypeElement> GetReverseEnumerator()
        {
            return new ReverseEnumeratorListeDoublementChainee<TypeElement>(this);
        }

        public ListeDoublementChainee<TypeElement> Reverse()
        {
            IEnumerator<TypeElement> reverseEnumeratorListeDoublementChainee = this.GetReverseEnumerator();
            ListeDoublementChainee<TypeElement> listeInversee = new ListeDoublementChainee<TypeElement>();

            while (reverseEnumeratorListeDoublementChainee.MoveNext())
            {
                listeInversee.Add(reverseEnumeratorListeDoublementChainee.Current);
            }

            return listeInversee;
        }
    }
}

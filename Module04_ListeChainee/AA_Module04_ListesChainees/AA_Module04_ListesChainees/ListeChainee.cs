using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Module04_ListesChainees
{
    public class ListeChainee<TypeElement> : IList<TypeElement>, IEnumerable<TypeElement>
    {
        public int Count { get; private set; }
        public NoeudListeChainee<TypeElement> PremierNoeud { get; private set; }
        public NoeudListeChainee<TypeElement> DernierNoeud { get; private set; }

        public bool IsReadOnly => false;

        public TypeElement this[int p_indice]
        {
            get
            {
                if (p_indice < 0 || p_indice >= this.Count)
                {
                    throw new IndexOutOfRangeException(nameof(p_indice));
                }

                NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
                for (int indiceCourant = 0; indiceCourant < p_indice; indiceCourant++)
                {
                    noeudCourant = noeudCourant.Suivant;
                }

                return noeudCourant.Valeur;
            }
            set
            {
                if (p_indice < 0 || p_indice >= this.Count)
                {
                    throw new IndexOutOfRangeException(nameof(p_indice));
                }

                NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
                for (int indiceCourant = 0; indiceCourant < p_indice; indiceCourant++)
                {
                    noeudCourant = noeudCourant.Suivant;
                }

                noeudCourant.Valeur = value;
            }
        }

        public ListeChainee()
        {
            this.Clear();
        }

        public ListeChainee(IEnumerable<TypeElement> p_elements)
        {
            this.Clear();

            foreach (TypeElement element in p_elements)
            {
                this.Add(element);
            }
        }

        public int IndexOf(TypeElement p_element)
        {
            NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
            int indexElement = -1;
            int indexCourant = 0;

            while (indexElement == -1 && noeudCourant != null)
            {
                if ((p_element == null && noeudCourant.Valeur == null)
                    || (p_element != null && p_element.Equals(noeudCourant.Valeur)))
                {
                    indexElement = indexCourant;
                }
                noeudCourant = noeudCourant.Suivant;
                indexCourant++;
            }

            return indexElement;
        }

        public void Insert(int p_indice, TypeElement p_element)
        {
            if (p_indice < 0 || p_indice > this.Count)
            {
                throw new IndexOutOfRangeException(nameof(p_indice));
            }

            if (p_indice == 0)
            {
                this.AddFirst(p_element);
            }
            else if (p_indice == this.Count)
            {
                this.Add(p_element);
            }
            else
            {
                this.InsertionReelle(p_indice, p_element);
            }
        }

        private void InsertionReelle(int p_indice, TypeElement p_element)
        {
            NoeudListeChainee<TypeElement> nouveauNoeud = new NoeudListeChainee<TypeElement>(p_element);

            NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
            for (int indiceCourant = 0; indiceCourant < p_indice - 1; indiceCourant++)
            {
                noeudCourant = noeudCourant.Suivant;
            }

            nouveauNoeud.Suivant = noeudCourant.Suivant;
            noeudCourant.Suivant = nouveauNoeud;

            this.Count++;
        }

        public void RemoveAt(int p_indice)
        {
            if (p_indice < 0 || p_indice >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(p_indice));
            }

            if (p_indice == 0)
            {
                this.PremierNoeud = this.PremierNoeud.Suivant;
                if (this.PremierNoeud is null)
                {
                    this.DernierNoeud = null;
                }
            }
            else
            {
                NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
                for (int indiceCourant = 0; indiceCourant < p_indice - 1; indiceCourant++)
                {
                    noeudCourant = noeudCourant.Suivant;
                }

                if (p_indice == this.Count - 1)
                {
                    this.DernierNoeud = noeudCourant;
                }

                noeudCourant.Suivant = noeudCourant.Suivant.Suivant;
            }

            this.Count--;
        }

        public void AddFirst(TypeElement p_element)
        {
            NoeudListeChainee<TypeElement> nouveauNoeud = new NoeudListeChainee<TypeElement>(p_element);

            nouveauNoeud.Suivant = this.PremierNoeud;
            this.PremierNoeud = nouveauNoeud;

            if (this.DernierNoeud is null)
            {
                this.DernierNoeud = nouveauNoeud;
            }

            this.Count++;
        }

        public void Add(TypeElement p_element)
        {
            NoeudListeChainee<TypeElement> nouveauNoeud = new NoeudListeChainee<TypeElement>(p_element);

            if (this.DernierNoeud != null)
            {
                this.DernierNoeud.Suivant = nouveauNoeud;
            }

            this.DernierNoeud = nouveauNoeud;

            if (this.PremierNoeud is null)
            {
                this.PremierNoeud = nouveauNoeud;
            }

            // Version sans référence sur le dernier noeud
            //if (this.PremierNoeud == null)
            //{
            //    this.PremierNoeud = noeud;
            //}
            //else
            //{
            //    NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
            //    while (noeudCourant.Suivant != null)
            //    {
            //        noeudCourant = noeudCourant.Suivant;
            //    }

            //    NoeudListeChainee<TypeElement> dernierNoeud = noeudCourant;
            //    dernierNoeud.Suivant = noeud;
            //}

            this.Count++;
        }

        public void Clear()
        {
            this.Count = 0;
            this.PremierNoeud = null;
            this.DernierNoeud = null;
        }

        public bool Contains(TypeElement p_element)
        {
            return this.IndexOf(p_element) >= 0;
        }

        public void CopyTo(TypeElement[] p_destination, int p_indiceDebut)
        {
            if (p_destination is null)
            {
                throw new ArgumentNullException(nameof(p_indiceDebut));
            }

            if (p_indiceDebut < 0)
            {
                throw new IndexOutOfRangeException(nameof(p_indiceDebut));
            }

            if (p_destination.Length < this.Count + p_indiceDebut)
            {
                throw new ArgumentOutOfRangeException(nameof(p_indiceDebut));
            }

            NoeudListeChainee<TypeElement> noeudCourant = this.PremierNoeud;
            for (int indiceCourante = 0;
                noeudCourant != null && indiceCourante < this.Count;
                indiceCourante++)
            {
                p_destination[indiceCourante + p_indiceDebut] = noeudCourant.Valeur;

                noeudCourant = noeudCourant.Suivant;
            }
        }

        public bool Remove(TypeElement p_element)
        {
            int index = this.IndexOf(p_element);

            if (index >= 0)
            {
                this.RemoveAt(index);
            }

            return index >= 0;
        }

        public IEnumerator<TypeElement> GetEnumerator()
        {
            return new EnumeratorListeChainee<TypeElement>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

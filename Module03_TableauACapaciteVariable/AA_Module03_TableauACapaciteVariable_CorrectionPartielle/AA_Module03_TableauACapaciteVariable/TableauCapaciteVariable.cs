using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AA_Module03_TableauACapaciteVariable
{
    public class TableauCapaciteVariable<TypeElement> : IEnumerable<TypeElement>, IList<TypeElement>
    {
        private TypeElement[] m_donnees;
        private const int CapaciteParDefaut = 1;

        public int Capacity
        {
            get
            {
                return this.m_donnees.Length;  
            }
            private set
            {
                if (this.Count > value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                TypeElement[] nouvellesDonnees = new TypeElement[value];
                if (this.Count > 0)
                {
                    Array.Copy(this.m_donnees, nouvellesDonnees, this.Count);
                }

                this.m_donnees = nouvellesDonnees;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public TableauCapaciteVariable(int p_capacite = CapaciteParDefaut)
        {
            if (p_capacite < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(p_capacite));
            }

            this.Capacity = p_capacite;
        }

        public TableauCapaciteVariable(IEnumerable<TypeElement> p_elements)
        {
            if (p_elements is null)
            {
                throw new ArgumentNullException(nameof(p_elements));
            }

            int nbElements = p_elements.Count();

            this.Capacity = nbElements;

            Array.Copy(p_elements.ToArray(), this.m_donnees, nbElements);

            this.Count = nbElements;
        }

        private void AugmenterCapacite()
        {
            int prochaineCapacite = this.Capacity * 2;
            if (prochaineCapacite == 0)
            {
                prochaineCapacite = CapaciteParDefaut;
            }

            this.Capacity = prochaineCapacite;
        }

        public TypeElement this[int p_indice]
        {
            get
            {
                if (p_indice < 0 || p_indice >= this.Count)
                {
                    throw new IndexOutOfRangeException(nameof(p_indice));
                }

                return this.m_donnees[p_indice];
            }
            set
            {
                if (p_indice < 0 || p_indice >= this.Count)
                {
                    throw new IndexOutOfRangeException(nameof(p_indice));
                }

                this.m_donnees[p_indice] = value;
            }
        }

        public IEnumerator<TypeElement> GetEnumerator()
        {
            return new EnumeratorTableauCapaciteVariable<TypeElement>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int IndexOf(TypeElement p_element)
        {
            int position = -1;
            for (int indiceCourant = 0; position == -1 && indiceCourant < this.Count; indiceCourant++)
            {
                TypeElement elementCourant = this.m_donnees[indiceCourant];

                if (   (p_element == null && elementCourant == null)
                    || (p_element != null && p_element.Equals(elementCourant)))
                {
                    position = indiceCourant;
                }
            }

            return position;
        }

        public void Insert(int p_indice, TypeElement p_element)
        {
            if (p_indice < 0 || p_indice > this.Count)
            {
                throw new IndexOutOfRangeException(nameof(p_indice));
            }

            if (this.Capacity == this.Count)
            {
                this.AugmenterCapacite();
            }

            for (int indiceElement = this.Count; indiceElement > p_indice; indiceElement--)
            {
                this.m_donnees[indiceElement] = this.m_donnees[indiceElement - 1];
            }

            this.m_donnees[p_indice] = p_element;
            this.Count++;
        }

        public void RemoveAt(int p_indice)
        {
            if (p_indice < 0 || p_indice >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(p_indice));
            }

            for (int indiceValeur = p_indice; indiceValeur < this.Count - 1; indiceValeur++)
            {
                this.m_donnees[indiceValeur] = this.m_donnees[indiceValeur + 1];
            }

            this.Count--;
        }

        public void Add(TypeElement p_element)
        {
            if (this.Capacity == this.Count)
            {
                this.AugmenterCapacite();
            }

            this.m_donnees[this.Count++] = p_element;
        }

        public void Clear()
        {
            this.Count = 0;
            this.Capacity = this.Capacity;
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

            for (int indiceCourante = 0; indiceCourante < this.Count; indiceCourante++)
            {
                p_destination[indiceCourante + p_indiceDebut] = this.m_donnees[indiceCourante];
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
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace AA_Module06_TableHachage_PreparationCours
{
    public class Dictionnaire<TypeClef, TypeValeur> : IDictionary<TypeClef, TypeValeur>
    {
        //
        private LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[] m_alveoles;
        //
        public TypeValeur this[TypeClef p_clef]
        {
            get
            {
                if (p_clef == null)
                {
                    throw new ArgumentNullException(nameof(p_clef));
                }

                CoupleClefValeur<TypeClef, TypeValeur> clefValeur = RechercherClefValeur(p_clef);

                if (clefValeur == null)
                {
                    throw new ClefNonTrouveeException();
                }

                return clefValeur.Valeur;
            }
            set
            {
                if (p_clef == null)
                {
                    throw new ArgumentNullException(nameof(p_clef));
                }

                CoupleClefValeur<TypeClef, TypeValeur> clefValeur = RechercherClefValeur(p_clef);

                if (clefValeur == null)
                {
                    throw new ClefNonTrouveeException();
                }

                clefValeur.Valeur = value;
            }
        }

        //
        public Dictionnaire()
        {
            this.m_alveoles = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[1];
            this.Count = 0;
        }

        //
        public Dictionnaire(IEnumerable<KeyValuePair<TypeClef, TypeValeur>> p_keyValuePairs)
        {
            if (p_keyValuePairs is null)
            {
                throw new ArgumentNullException();
            }

            this.m_alveoles = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[p_keyValuePairs.Count()];
            this.Count = 0;

            foreach (KeyValuePair<TypeClef, TypeValeur> keyValue in p_keyValuePairs)
            {
                this.Add(keyValue);
            }
        }

        //
        private int CalculerNumeroAlveole(int p_valeurHachage, int p_nombreAlveoles)
        {
            return Math.Abs(p_valeurHachage) % p_nombreAlveoles;
        }

        //
        private int CalculerNumeroAlveole(int p_valeurHachage)
        {
            int nombreAlveoles = this.m_alveoles.Length;

            return this.CalculerNumeroAlveole(p_valeurHachage, nombreAlveoles);
        }

        private CoupleClefValeur<TypeClef, TypeValeur> RechercherClefValeur(TypeClef p_clef)
        {
            int valeurHachage = p_clef.GetHashCode();
            int numeroAlveole = CalculerNumeroAlveole(valeurHachage);

            LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> alveole = this.m_alveoles[numeroAlveole];
            CoupleClefValeur<TypeClef, TypeValeur> clefValeur = alveole?.Where(couple => couple.ValeurHachage == valeurHachage && p_clef.Equals(couple.Clef)).SingleOrDefault();

            return clefValeur;
        }
        //
        public ICollection<TypeClef> Keys
        {
            get
            {
                return this.m_alveoles.Where(cvs => cvs != null).SelectMany(cvs => cvs?.Select(cv => cv.Clef)).ToList();
            }
        }
        //
        public ICollection<TypeValeur> Values
        {
            get
            {
                return this.m_alveoles.Where(cvs => cvs != null).SelectMany(cvs => cvs?.Select(cv => cv.Valeur)).ToList();
            }
        }

        //
        public int Count { get; private set; }
        //
        public bool IsReadOnly => false;

        //
        public void Add(TypeClef p_clef, TypeValeur p_valeur)
        {
            if (p_clef == null)
            {
                throw new ArgumentNullException(nameof(p_clef));
            }

            this.Add(new KeyValuePair<TypeClef, TypeValeur>(p_clef, p_valeur));
        }

        private void RedimensionnerDictionnaire(int p_nouvelleCapacite)
        {
            LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[] futuresAlveoles = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[p_nouvelleCapacite];

            foreach (CoupleClefValeur<TypeClef, TypeValeur> clefValeur in this.m_alveoles.Where(cvs => cvs != null).SelectMany(cvs => cvs))
            {
                int alveole = CalculerNumeroAlveole(clefValeur.Clef.GetHashCode(), p_nouvelleCapacite);
                AjouterClefValeurDansAlveole(clefValeur, futuresAlveoles, alveole);
            }

            this.m_alveoles = futuresAlveoles;
        }

        private static void AjouterClefValeurDansAlveole(CoupleClefValeur<TypeClef, TypeValeur> clefValeur, LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[] p_alveoles, int p_numeroAlveole)
        {
            if (p_alveoles[p_numeroAlveole] == null)
            {
                p_alveoles[p_numeroAlveole] = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>();
            }
            p_alveoles[p_numeroAlveole].AddLast(clefValeur);
        }

        //
        public void Add(KeyValuePair<TypeClef, TypeValeur> p_kv)
        {
            if (p_kv.Key == null)
            {
                throw new ArgumentOutOfRangeException(nameof(p_kv));
            }

            if (this.RechercherClefValeur(p_kv.Key) != null)
            {
                throw new ClefDejaPresenteException();
            }

            if (this.Count >= this.m_alveoles.Length)
            {
                this.RedimensionnerDictionnaire(this.m_alveoles.Length * 2);
            }

            int valeurHachage = p_kv.Key.GetHashCode();
            int numeroAlveole = CalculerNumeroAlveole(valeurHachage);
            CoupleClefValeur<TypeClef, TypeValeur> clefValeur = new CoupleClefValeur<TypeClef, TypeValeur>()
            {
                Clef = p_kv.Key,
                ValeurHachage = valeurHachage,
                Valeur = p_kv.Value
            };
            AjouterClefValeurDansAlveole(clefValeur, this.m_alveoles, numeroAlveole);
            this.Count++;
        }

        //
        public void Clear()
        {
            this.m_alveoles = new LinkedList<CoupleClefValeur<TypeClef, TypeValeur>>[1];
            this.Count = 0;
        }
        //
        public bool Contains(KeyValuePair<TypeClef, TypeValeur> p_kv)
        {
            int valeurHachage = p_kv.Key.GetHashCode();
            int numeroAlveole = CalculerNumeroAlveole(valeurHachage);

            LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> clefValeurs = this.m_alveoles[numeroAlveole];

            return clefValeurs?.Where(cv => valeurHachage == cv.ValeurHachage
                                            && p_kv.Key.Equals(cv.Clef)
                                            && ((p_kv.Value == null && cv.Valeur == null)
                                                 || (p_kv.Value != null && p_kv.Value.Equals(cv.Valeur))
                                               )
                                    ).FirstOrDefault() != null;
        }
        //
        public bool ContainsKey(TypeClef p_clef)
        {
            int valeurHachage = p_clef.GetHashCode();
            int numeroAlveole = CalculerNumeroAlveole(valeurHachage);

            LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> clefValeurs = this.m_alveoles[numeroAlveole];

            return clefValeurs?.Where(cv => valeurHachage == cv.ValeurHachage && p_clef.Equals(cv.Clef)).FirstOrDefault() != null;
        }

        public void CopyTo(KeyValuePair<TypeClef, TypeValeur>[] p_tableauClefValeur, int p_positionDepart)
        {
            if (this.Count > p_tableauClefValeur.Length - p_positionDepart)
            {
                throw new ArgumentException("Tableau trop petit");
            }

            int indiceDestination = p_positionDepart;
            IEnumerator<KeyValuePair<TypeClef, TypeValeur>> enumerator = this.GetEnumerator();
            while (enumerator.MoveNext())
            {
                p_tableauClefValeur[indiceDestination] = enumerator.Current;
                indiceDestination++;
            }
        }
        //
        public IEnumerator<KeyValuePair<TypeClef, TypeValeur>> GetEnumerator()
        {
            return this.m_alveoles.Where(cvs => cvs != null).SelectMany(cvs => cvs.Select(cv => new KeyValuePair<TypeClef, TypeValeur>(cv.Clef, cv.Valeur))).GetEnumerator();
        }
        //
        public bool Remove(TypeClef p_clef)
        {
            int valeurHachage = p_clef.GetHashCode();
            int numeroAlveole = CalculerNumeroAlveole(valeurHachage);

            LinkedList<CoupleClefValeur<TypeClef, TypeValeur>> clefValeurs = this.m_alveoles[numeroAlveole];

            CoupleClefValeur<TypeClef, TypeValeur> cv = clefValeurs?.Where(cvi => valeurHachage == cvi.ValeurHachage
                                                                          && p_clef.Equals(cvi.Clef)).FirstOrDefault();

            if (cv != null)
            {
                clefValeurs.Remove(cv);
                this.Count--;

                if (this.Count < this.m_alveoles.Length / 4)
                {
                    this.RedimensionnerDictionnaire(Math.Max(this.m_alveoles.Length / 2, 1));
                }
            }

            return cv != null;
        }
        //
        public bool Remove(KeyValuePair<TypeClef, TypeValeur> p_kv)
        {
            if (p_kv.Key == null)
            {
                throw new ArgumentOutOfRangeException(nameof(p_kv));
            }
            return this.Remove(p_kv.Key);
        }

        public bool TryGetValue(TypeClef p_clef, out TypeValeur p_valeurSortie)
        {
            p_valeurSortie = default;
            bool reussi = false;

            try
            {
                p_valeurSortie = this[p_clef];
            }
            catch (Exception)
            {
                ;
            }

            return reussi;
        }
        //
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

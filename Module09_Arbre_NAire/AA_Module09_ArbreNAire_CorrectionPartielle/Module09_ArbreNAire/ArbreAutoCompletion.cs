using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Module09_ArbreNAire
{
    public class ArbreAutoCompletion : Arbre<DonneeNoeudTrie>
    {
        public ArbreAutoCompletion()
        {
            this.Racine = new NoeudArbre<DonneeNoeudTrie>(new DonneeNoeudTrie(' ', "", false));
        }

        public void AjouterMot(string p_mot)
        {
            if (string.IsNullOrWhiteSpace(p_mot))
            {
                throw new ArgumentException(nameof(p_mot));
            }

            p_mot = p_mot.ToLower();

            AjouterMot_rec(p_mot, this.Racine);
        }

        private void AjouterMot_rec(string p_resteMot, NoeudArbre<DonneeNoeudTrie> p_noeudCourant)
        {
            char premiereLettre = p_resteMot[0];
            string autresLettres = p_resteMot.Substring(1);

            NoeudArbre<DonneeNoeudTrie> noeudDepart = TrouverNoeudEnfantPour(p_noeudCourant, premiereLettre);

            if (noeudDepart == null)
            {
                noeudDepart = new NoeudArbre<DonneeNoeudTrie>(
                    new DonneeNoeudTrie(premiereLettre,
                                        p_noeudCourant.Valeur.Prefixe + premiereLettre.ToString(),
                                        p_resteMot.Length == 1
                                       )
                    );
                p_noeudCourant.Enfants.Add(noeudDepart);
            }

            if (p_resteMot.Length > 1)
            {
                AjouterMot_rec(autresLettres, noeudDepart);
            }
            else
            {
                noeudDepart.Valeur.EstMotValide = true;
            }
        }

        private NoeudArbre<DonneeNoeudTrie> TrouverNoeudEnfantPour(NoeudArbre<DonneeNoeudTrie> p_noeudCourant, char p_lettre)
        {
            return p_noeudCourant
                .Enfants
                .Where(n => n.Valeur.Lettre == p_lettre)
                .SingleOrDefault();
        }

        public List<string> CompleterPrefixe(string p_prefixe)
        {
            if (string.IsNullOrWhiteSpace(p_prefixe))
            {
                throw new ArgumentException(nameof(p_prefixe));
            }

            p_prefixe = p_prefixe.ToLower();

            NoeudArbre<DonneeNoeudTrie> noeudPrefixe = RechercherNoeudPrefixe(p_prefixe, this.Racine);

            if (noeudPrefixe != null)
            {
                return CollecterMots_rec(noeudPrefixe);
            }

            return new List<string>();
        }

        private List<string> CollecterMots_rec(NoeudArbre<DonneeNoeudTrie> p_noeudPrefixe)
        {
            List<string> res = new List<string>();

            if (p_noeudPrefixe.Valeur.EstMotValide)
            {
                res.Add(p_noeudPrefixe.Valeur.Prefixe);
            }

            foreach (var enfant in p_noeudPrefixe.Enfants)
            {
                res.AddRange(CollecterMots_rec(enfant));
            }
            return res;
        }

        private NoeudArbre<DonneeNoeudTrie> RechercherNoeudPrefixe(string p_prefixe, NoeudArbre<DonneeNoeudTrie> p_noeudCourant)
        {
            char premiereLettre = p_prefixe[0];
            NoeudArbre<DonneeNoeudTrie> noeudDepart = TrouverNoeudEnfantPour(p_noeudCourant, premiereLettre);

            if (noeudDepart == null)
            {
                return null;
            }

            if (p_prefixe.Length == 1)
            {
                return noeudDepart;
            }

            return RechercherNoeudPrefixe(p_prefixe.Substring(1), noeudDepart);
        }
    }
}

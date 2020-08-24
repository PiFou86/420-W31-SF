using System;
using System.Collections.Generic;
using System.Text;

namespace Module09_ArbreNAire
{
    public class DonneeNoeudTrie
    {
        public bool EstMotValide { get; set; }
        public char Lettre { get; set; }
        public string Prefixe { get; set; }

        public DonneeNoeudTrie(char p_lettre, string p_prefixe, bool p_estMotValide)
        {
            this.EstMotValide = p_estMotValide;
            this.Lettre = p_lettre;
            this.Prefixe = p_prefixe;
        }
    }


}

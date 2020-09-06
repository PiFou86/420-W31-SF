using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace AA_Module09_Expressions.Expressions
{
    public class Entier : Expression
    {
        public int Valeur { get; set; }

        public Entier(int p_valeur)
        {
            this.Valeur = p_valeur;
        }

        public int Calculer()
        {
            return this.Valeur;
        }

        public string ToStringPrefixe()
        {
            return this.ToString();
        }

        public string ToStringInfixe()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return this.Valeur.ToString();
        }
    }
}

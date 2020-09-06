using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module09_Expressions.Expressions
{
    public class ArbreExpression
    {
        public Expression Racine { get; set; }

        public string ChainePrefixe()
        {
            return this.Racine.ToStringPrefixe();
        }

        public string ChaineInfixe()
        {
            return this.Racine.ToStringInfixe();
        }
    }
}

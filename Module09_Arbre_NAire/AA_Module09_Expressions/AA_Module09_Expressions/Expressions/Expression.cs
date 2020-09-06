using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module09_Expressions.Expressions
{
    public interface Expression
    {
        public int Calculer();
        public string ToStringPrefixe();
        public string ToStringInfixe();
    }
}

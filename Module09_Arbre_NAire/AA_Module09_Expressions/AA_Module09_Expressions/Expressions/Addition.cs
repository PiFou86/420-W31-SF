using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module09_Expressions.Expressions
{
    public class Addition : ExpressionBinaire
    {
        public Addition(Expression p_operande1, Expression p_operande2) : base(p_operande1, p_operande2)
        {
            ;
        }

        public override int Calculer()
        {
            return this.ValeurOperandeGauche + this.ValeurOperandeDroit;
        }

        public override string ToString()
        {
            return "+";
        }
    }
}

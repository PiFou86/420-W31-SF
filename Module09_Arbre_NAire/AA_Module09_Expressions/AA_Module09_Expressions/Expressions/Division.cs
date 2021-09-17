using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module09_Expressions.Expressions
{
    public class Division : ExpressionBinaire
    {
        public Division(Expression p_operande1, Expression p_operande2) : base(p_operande1, p_operande2)
        {
            ;
        }

        public override int Calculer()
        {
            int valeurDroit = this.ValeurOperandeDroit;

            if (valeurDroit == 0)
            {
                throw new DivideByZeroException();
            }

            return this.ValeurOperandeGauche / valeurDroit;
        }

        public override string ToString()
        {
            return "/";
        }

    }
}

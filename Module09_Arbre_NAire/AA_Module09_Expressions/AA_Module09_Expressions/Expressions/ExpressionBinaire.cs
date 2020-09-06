using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module09_Expressions.Expressions
{
    public abstract class ExpressionBinaire : Expression
    {
        public Expression OperandeGauche { get; set; }
        public Expression OperandeDroit { get; set; }
        public int ValeurOperandeGauche => (this.OperandeGauche is null) ? throw new InvalidOperationException() : this.OperandeGauche.Calculer();
        public int ValeurOperandeDroit => (this.OperandeDroit is null) ? throw new InvalidOperationException() : this.OperandeDroit.Calculer();

        public ExpressionBinaire(Expression p_operande1, Expression p_operande2)
        {
            this.OperandeGauche = p_operande1;
            this.OperandeDroit = p_operande2;
        }

        public abstract int Calculer();

        public string ToStringPrefixe()
        {
            return $"{this} {this.OperandeGauche.ToStringPrefixe()} {this.OperandeDroit.ToStringPrefixe()}";
        }

        public string ToStringInfixe()
        {
            return $"{this.OperandeGauche.ToStringInfixe()} {this} {this.OperandeDroit.ToStringInfixe()}";
        }
    }
}

using AA_Module09_Expressions.Expressions;
using AA_Module09_Expressions.Expressions.Analyseur;
using System;

namespace AA_Module09_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            string expressionString1 = "+ 1 2";
            Expression expression1 = AnalyseurSimpleExpression.AnalyserChaine(expressionString1);
            Console.Out.WriteLine($"{expression1.ToStringPrefixe()} = {expression1.Calculer()}");
            Console.Out.WriteLine($"{expression1.ToStringInfixe()} = {expression1.Calculer()}");

            string expressionString2 = "+ * 2 4 / 24 3";
            Expression expression2 = AnalyseurSimpleExpression.AnalyserChaine(expressionString2);
            Console.Out.WriteLine($"{expression2.ToStringPrefixe()} = {expression2.Calculer()}");
            Console.Out.WriteLine($"{expression2.ToStringInfixe()} = {expression2.Calculer()}");

        }
    }
}

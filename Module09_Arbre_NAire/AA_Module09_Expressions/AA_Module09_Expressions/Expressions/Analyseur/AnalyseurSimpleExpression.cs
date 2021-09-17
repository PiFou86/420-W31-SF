using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AA_Module09_Expressions.Expressions.Analyseur
{
    public static class AnalyseurSimpleExpression
    {
        public static Expression AnalyserChaine(string p_expression)
        {
            if (string.IsNullOrWhiteSpace(p_expression))
            {
                throw new ArgumentOutOfRangeException(nameof(p_expression));
            }

            // validations minimales
            if (!Regex.IsMatch(p_expression, "^[+-/*0-9 ]+$"))
            {
                throw new InvalidOperationException();
            }

            return AnalyserChain_rec(p_expression).DerniereExpressionGeneree;
        }

        private static AnalyseurExpressionResultat AnalyserChain_rec(string p_expression)
        {
            string expression = p_expression.Trim();
            char premierCaractere = expression[0];
            AnalyseurExpressionResultat analyseurExpressionResultat = new AnalyseurExpressionResultat();

            if (EstOperation(premierCaractere))
            {
                AnalyseurExpressionResultat analyseurExpressionResultatGauche = AnalyserChain_rec(expression.Substring(1));
                AnalyseurExpressionResultat analyseurExpressionResultatDroit = AnalyserChain_rec(analyseurExpressionResultatGauche.ExpressionRestanteAAnalyser);
                analyseurExpressionResultat.DerniereExpressionGeneree =
                    ObtenierOperation(
                        premierCaractere,
                        analyseurExpressionResultatGauche.DerniereExpressionGeneree,
                        analyseurExpressionResultatDroit.DerniereExpressionGeneree
                    );
                analyseurExpressionResultat.ExpressionRestanteAAnalyser = analyseurExpressionResultatDroit.ExpressionRestanteAAnalyser;
            }
            else
            {
                int longueurNombre = 0;
                while (longueurNombre < expression.Length && EstChiffre(expression[longueurNombre]))
                {
                    longueurNombre++;
                }
                string entierChaine = expression.Substring(0, longueurNombre);
                int valeurEntiere = int.Parse(entierChaine);
                analyseurExpressionResultat.ExpressionRestanteAAnalyser = expression.Substring(longueurNombre);
                analyseurExpressionResultat.DerniereExpressionGeneree = new Entier(valeurEntiere);
            }

            return analyseurExpressionResultat;
        }

        private static Expression ObtenierOperation(char p_operation, Expression p_operande1, Expression p_operande2)
        {
            Expression operation = null;
            switch (p_operation)
            {
                case '+':
                    operation = new Addition(p_operande1, p_operande2);
                    break;
                case '-':
                    operation = new Soustraction(p_operande1, p_operande2);
                    break;
                case '*':
                    operation = new Multiplication(p_operande1, p_operande2);
                    break;
                case '/':
                    operation = new Division(p_operande1, p_operande2);
                    break;
                default:
                    break;
            }

            return operation;
        }

        private static bool EstOperation(char p_valeur)
        {
            return "+/-*".Contains(p_valeur);
        }

        private static bool EstChiffre(char p_valeur)
        {
            return char.IsDigit(p_valeur);
        }
    }
}

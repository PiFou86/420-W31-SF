using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AA_Module01_Preparation_Cours
{
    public class Program
    {
        static void Main(string[] args)
        {
            DemoRecherche();

            DemoEchangerValeurs();

            DemoVecteur2D();

            DemoCompareTo();

            DemoLambda();

            FonctionAvecExpression(a => a == 12);

            DemoReecrireWhere();

        }

        #region "Rechercher"
        public static void DemoRecherche()
        {
            int[] valeursEntieres = new int[] { 13, 23, 42, 225 };

            Console.Out.WriteLine(string.Join(", ", valeursEntieres));
            int positionTrouveePour23 = Rechercher(valeursEntieres, 23);
            Console.Out.WriteLine($"Position de 23 : {positionTrouveePour23}");
            int positionTrouveePour42 = Rechercher<int>(valeursEntieres, 42);
            Console.Out.WriteLine($"Position de 42 : {positionTrouveePour42}");
        }

        //public static int Rechercher(int[] p_valeurs, int p_valeurARechercher)
        //{
        //    if (p_valeurs == null)
        //    {
        //        throw new ArgumentNullException(nameof(p_valeurs));
        //    }

        //    const int positionNonTrouvee = -1;
        //    int positionValeurARechercher = positionNonTrouvee;

        //    for (int indiceValeurCourante = 0;
        //        positionValeurARechercher == positionNonTrouvee && indiceValeurCourante < p_valeurs.Length;
        //        indiceValeurCourante++)
        //    {
        //        if (p_valeurs[indiceValeurCourante] == p_valeurARechercher)
        //        {
        //            positionValeurARechercher = indiceValeurCourante;
        //        }
        //    }

        //    return positionValeurARechercher;
        //}

        //public static float Rechercher(float[] p_valeurs, float p_valeurARechercher)
        //{
        //    if (p_valeurs == null)
        //    {
        //        throw new ArgumentNullException(nameof(p_valeurs));
        //    }

        //    const int positionNonTrouvee = -1;
        //    int positionValeurARechercher = positionNonTrouvee;

        //    for (int indiceValeurCourante = 0;
        //        positionValeurARechercher == positionNonTrouvee && indiceValeurCourante < p_valeurs.Length;
        //        indiceValeurCourante++)
        //    {
        //        if (p_valeurs[indiceValeurCourante] == p_valeurARechercher)
        //        {
        //            positionValeurARechercher = indiceValeurCourante;
        //        }
        //    }

        //    return positionValeurARechercher;
        //}

        public static int Rechercher<TypeElement>(TypeElement[] p_valeurs, TypeElement p_valeurARechercher)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }

            const int positionNonTrouvee = -1;
            int positionValeurARechercher = positionNonTrouvee;

            for (int indiceValeurCourante = 0;
                positionValeurARechercher == positionNonTrouvee && indiceValeurCourante < p_valeurs.Length;
                indiceValeurCourante++)
            {
                if (p_valeurs[indiceValeurCourante].Equals(p_valeurARechercher))
                {
                    positionValeurARechercher = indiceValeurCourante;
                }
            }

            return positionValeurARechercher;
        }
        #endregion

        #region "EchangerValeurs"
        public static void DemoEchangerValeurs()
        {
            int[] valeursEntieres = new int[] { 13, 23, 42, 225 };

            Console.Out.WriteLine(string.Join(", ", valeursEntieres));
            EchangerValeurs(valeursEntieres, 0, valeursEntieres.Length - 1);
            Console.Out.WriteLine(string.Join(", ", valeursEntieres));
        }

        public static void EchangerValeurs<TypeElement>(TypeElement[] p_valeurs, int p_position1, int p_position2)
        {
            if (p_valeurs == null)
            {
                throw new ArgumentNullException(nameof(p_valeurs));
            }
            if (p_position1 < 0 || p_position1 >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(p_position1));
            }
            if (p_position2 < 0 || p_position2 >= p_valeurs.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(p_position2));
            }

            TypeElement temp = p_valeurs[p_position1];
            p_valeurs[p_position1] = p_valeurs[p_position2];
            p_valeurs[p_position2] = temp;
        }
        #endregion

        #region "Vecteur2D"
        public static void DemoVecteur2D()
        {
            Vecteur2D<int> vecteurXEntier = new Vecteur2D<int>() { X = 1, Y = 0 };
            Vecteur2D<int> vecteurYEntier = new Vecteur2D<int>() { X = 0, Y = 1 };
            Vecteur2D<int> sommeVecteursEntiers = vecteurXEntier + vecteurYEntier;
            Console.Out.WriteLine($"{vecteurXEntier} + {vecteurYEntier} = {sommeVecteursEntiers}");

            Vecteur2D<float> vecteurXFloat = new Vecteur2D<float>() { X = 1.1f, Y = 0 };
            Vecteur2D<float> vecteurYFloat = new Vecteur2D<float>() { X = 0, Y = 1.1f };
            Vecteur2D<float> sommeVecteursFloats = vecteurXFloat + vecteurYFloat;
            Console.Out.WriteLine($"{vecteurXFloat} + {vecteurYFloat} = {sommeVecteursFloats}");

            //Erreur : Vecteur2D<float> sommeVecteursEntierFloat = vecteurXEntier + vecteurYFloat;
        }
        #endregion

        #region "CompareTo"
        public static void DemoCompareTo()
        {

        }

        public static TypeElement CalculerMinimum<TypeElement>(TypeElement p_valeur1, TypeElement p_valeur2) where TypeElement : IComparable<TypeElement>
        {
            TypeElement minimum = p_valeur1;

            if (p_valeur2.CompareTo(minimum) < 0)
            {
                minimum = p_valeur2;
            }

            return minimum;
        }
        #endregion

        #region "Lambda"
        public static void DemoLambda()
        {
            //v => v;
            //(v) => v;
            //v => { return v; };

            //n => n * n;

            //(valeur1, valeur2) => valeur1 + valeur2;

            //(valeur1, valeur2) => valeur1 <= valeur2;


            Func<double, double> varRefFunc1 = v => v;
            Func<double, double> varRefFunc2 = (v) => v;
            Func<double, double> varRefFunc3 = v => { return v; };

            Func<double, double> varRefFunc4 = n => n * n;

            Func<double, double, double> varRefFunc5 = (valeur1, valeur2) => valeur1 + valeur2;

            Func<double, double, bool> varRefFunc6 = (valeur1, valeur2) => valeur1 <= valeur2;

            Action<int> varRefAction1 = v => Console.Out.WriteLine(v);

            Func<double, double> varRefFuncCarre = n => n * n;
            double valeurCarre1 = varRefFuncCarre(42.0);
            Console.Out.WriteLine($"valeurCarre1 = {valeurCarre1}");
            double valeurCarre2 = ExecuterTraitement(varRefFuncCarre, 42.0);
            Console.Out.WriteLine($"valeurCarre2 = {valeurCarre2}");
            double valeurCarre3 = ExecuterTraitement(n => n * n, 42.0);
            Console.Out.WriteLine($"valeurCarre3 = {valeurCarre3}");
        }

        public static TypeResultat ExecuterTraitement<TypeDonnee, TypeResultat>(Func<TypeDonnee, TypeResultat> p_traitement,
                                                                                TypeDonnee p_donnee)
        {
            if (p_traitement == null) { throw new ArgumentNullException(nameof(p_traitement)); }

            return p_traitement(p_donnee);
        }

        #endregion

        #region "ReecrireWhere"
        public static void DemoReecrireWhere()
        {
            List<int> listeEntiersAFiltrer = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            List<int> listeEntiersMultiples3 = listeEntiersAFiltrer.Filtrer(n => n % 3 == 0);

            Console.Out.WriteLine($"listeEntiersAFiltrer : {string.Join(", ", listeEntiersAFiltrer)}");
            Console.Out.WriteLine($"listeEntiersMultiples3 : {string.Join(", ", listeEntiersMultiples3)}");
        }
        #endregion

        public static void FonctionAvecExpression(Expression<Func<int, bool>> expression)
        {

        }



    }
}

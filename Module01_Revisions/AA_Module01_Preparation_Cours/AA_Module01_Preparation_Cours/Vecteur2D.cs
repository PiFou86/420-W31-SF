using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module01_Preparation_Cours
{
    public class Vecteur2D<TypeCoordonnee>
    {
        public TypeCoordonnee X { get; set; }
        public TypeCoordonnee Y { get; set; }

        public static Vecteur2D<TypeCoordonnee> operator +(Vecteur2D<TypeCoordonnee> p_vecteur1, Vecteur2D<TypeCoordonnee> p_vecteur2)
        {
            return new Vecteur2D<TypeCoordonnee>()
            {
                X = (dynamic)p_vecteur1.X + (dynamic)p_vecteur2.X,
                Y = (dynamic)p_vecteur1.Y + (dynamic)p_vecteur2.Y
            };
        }

        public override string ToString()
        {
            return $"Vecteur2D({this.X}, {this.Y})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AA_Module08_ArbreBinaire
{
    public class NoeudArbreBinaire<TypeElement>
    {
        public NoeudArbreBinaire<TypeElement> Gauche { get; set; }
        public NoeudArbreBinaire<TypeElement> Droit { get; set; }
        public TypeElement Valeur { get; set; }
    }
}

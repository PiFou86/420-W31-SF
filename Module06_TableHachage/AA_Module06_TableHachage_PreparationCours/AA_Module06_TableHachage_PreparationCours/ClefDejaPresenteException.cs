using System;
using System.Runtime.Serialization;

namespace AA_Module06_TableHachage_PreparationCours
{
    [Serializable]
    internal class ClefDejaPresenteException : ArgumentException
    {
        public ClefDejaPresenteException()
        {
        }
    }
}
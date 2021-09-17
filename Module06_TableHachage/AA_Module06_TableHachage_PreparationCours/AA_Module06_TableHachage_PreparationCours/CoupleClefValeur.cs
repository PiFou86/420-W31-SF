namespace AA_Module06_TableHachage_PreparationCours
{
    public class CoupleClefValeur<TypeClef, TypeValeur>
    {
        public TypeClef Clef { get; set; }
        public TypeValeur Valeur { get; set; }
        public int ValeurHachage { get; set; }
    }
}
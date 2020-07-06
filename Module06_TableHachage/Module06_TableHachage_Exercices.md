# Module 06 - Table de hachage

N'oubliez pas vos tests unitaires !

## Exercice 1 - Implantation de la table de hachage

Vous allez implanter un dictionnaire qui associe à une clef de type TypeClef, une valeur de type TypeValeur.

Remarque : comme tout est basé sur la valeur d'hachage de la clef, aucune clef ne peut être nulle.

Pour cela :

1. Créez les classes d'exceptions suivantes :
   - "ClefNonTrouveeException" : dérive d'"ArgumentOutOfRangeException"
   - "ClefDejaPresenteException" : dérive d'"ArgumentException"
2. Créez la classe générique "CoupleClefValeur<TypeClef, TypeValeur>" avec les propriétés suivantes (attention, ici on parle de "CoupleClefValeur" qui est un type interne à notre structure. Pour les méthodes externes, vous allez utiliser "IDictionary<TypeClef, TypeValeur>") :
   - Clef (get / set) : de type TypeClef
   - Valeur (get / set) : de type TypeValeur
   - ValeurHachage (get / set) : de type int
3. Créez la classe générique "Dictionnaire<TypeClef, TypeValeur>" et indiquez qu'elle implante l'interface "IDictionary<TypeClef, TypeValeur>"
4. Ajoutez les méthodes utilitaires suivantes (le modulo de C# n'est pas le modulo mathématique mais le reste de la division entière, ici j'ai simplifié la résolution du problème en prenant la valeur absolue de la valeur de hachage) :
  
```csharp
private int CalculerNumeroAlveole(int p_valeurHachage, int p_nombreAlveoles)
{
    return Math.Abs(p_valeurHachage) % p_nombreAlveoles;
}

private int CalculerNumeroAlveole(int p_valeurHachage)
{
    int nombreAlveoles = this.m_alveoles.Length;

    return this.CalculerNumeroAlveole(p_valeurHachage, nombreAlveoles);
}
```

5. Dans cette classe, implantez les membres dans l'ordre suivant :
   - NB_ALVEOLES : constante entière définie à 10
   - m_alveoles : tableau de listes chaines de CoupleCleValeur. Pour représenter les listes chainées, vous allez utiliser la classe du cadriciel "LinkedList"
   - Count (get/private set) : auto-propriété qui contient le nombre de couples contenus dans la table de hachage
   - Constructeur par défaut : initialise le tableau d'alvéoles à NB_ALVEOLES
   - Constructeur par initialisation : prend une collection de "KeyValeuPair<TypeClef, TypeValeur>", initialise le tableau d'alvéoles à NB_ALVEOLES et y ajoute l'ensemble des couples de la collecion
   - Les méthodes Add
   - IsReadOnly (get) : renvoie faux
   - Keys et Values (get) : renvoient respectivement l'ensemble des clefs et l'ensemble des valeurs. Vous pouvez utiliser la méthode d'extension LINQ "SelectMany" qui permet d'applatir une liste de liste. Cette méthode ne fonctionne pas en présence de liste "null", il faut donc les filtrer avant de l'appliquer.
   - La propriété this qui prend en paramètres la clef :
      - Get : renvoie la valeur associée à une clef. Si la clef n'existe pas, levez l'exception "ClefNonTroueeException"
      - Set : écrase la valeur associée à une clef. Si la clef n'existe pas, levez l'exception "ClefNonTrouveeException"
   - La méthode Clear : affecte un nouveau tableau d'alvéoles à la structure et réinitialise le nombre d'éléments de la liste.
   - Les méthodes "Contains" et "ContainsKey"
   - Les méthodes "Remove"
   - Les méthodes "GetEnumerator" : la méthode générique renvoyez un énumérateur sur une liste de "KeyValuePair" que vous créez à partir de vos données. Pour la créer, je vous conseille d'utiliser "SelectMany" comme précédemment. La méthode non générique renvoie simplement l'itérateur généré dans la méthode générique

## Exercice 2 - Diminution du nombre de collisions (Optionnel)

Reprenez le code de l'exercice 1. Modifiez les méthodes d'ajout et de suppression d'un élément dans le dictionnaire, vous devez maintenant intervenir dans les cas suivants :

- le nombre d'alvéoles est inférieur ou égale au nombre de couples : vous allez devoir augmenter le nombre d'alvéoles par deux et transférer le contenu des anciennes alvéoles dans les nouvelles.
- le nombre d'alvéoles est supérieur à 4 fois le nombre de couples : vous devez diminuer le nombre d'alvéoles par deux et transférer le contenu des anciennes alvéoles dans les nouvelles.

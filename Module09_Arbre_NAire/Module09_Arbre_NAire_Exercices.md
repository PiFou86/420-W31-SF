# Module 09 - Arbre n-aire

## Exercice 1 - Structure arbre n-aire

- Écrivez la classe « NoeudArbre » qui permet de représenter les liens vers les différents enfants et qui permet de stocker une valeur d’un type paramétré

- Écrivez la classe « Arbre » qui contient simplement le nœud racine

<details>
    <summary>Proposition de correction pour la classe "NoeudArbre"</summary>

```csharp
public class NoeudArbre<TypeDonnee>
{
    public NoeudArbre(TypeDonnee p_valeur)
    {
        this.Enfants = new List<NoeudArbre<TypeDonnee>>();
        this.Valeur = p_valeur;
    }

    public List<NoeudArbre<TypeDonnee>> Enfants { get; set; }
    public TypeDonnee Valeur { get; set; }
}
```

</details>

<details>
    <summary>Proposition de correction pour la classe "Arbre"</summary>

```csharp
public class Arbre<TypeDonnee>
{
    public NoeudArbre<TypeDonnee> Racine { get; protected set; }

}
```

</details>

## Exercice 2 - Arbre d'auto-complétion

- Sur papier :
  - Déterminez la structure « DonneeNoeudTrie » qui permet de représenter l’ensemble des informations que nous avons besoin par nœud
  - À partir des structures précédentes, déterminez la classe « ArbreAutoCompletion » qui permet de représenter de tels arbres
  - Déterminez l’algorithme d’ajout d’un mot à partir de la racine
- Sur machine :
  - Implantez les classe « DonneeNoeudTrie » et « ArbreAutoCompletion »
  - Implantez l’algorithme d’ajout d’un mot dans la méthode « AjouterMot » dans une version publique qui ne prend que le mot à ajouter en paramètre et une privé qui prend tous les paramètres nécessaires à votre algorithme
  - À partir d’une fonction dans la classe « Program », essayez d’insérer des mots dedans pour tester votre méthode
  - Faites une fonction qui charge les mots du dictionnaire contenu dans le [fichier donné avec le cours](liste.de.mots.francais.frgut.txt) (N'oubliez pas d'indiquer à Visual Studio que vous voulez copier le fichier contenant les mots dans le répertoire de la sortie).

Pour découper une chaine, allez voir la [méthode SubString de la classe "String"](https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=netcore-3.1)

<details>
    <summary>Proposition de correction pour la classe "ArbreAutoCompletion"</summary>

```csharp
public class ArbreAutoCompletion : Arbre<DonneeNoeudTrie>
{
    public ArbreAutoCompletion()
    {
        this.Racine = new NoeudArbre<DonneeNoeudTrie>(new DonneeNoeudTrie('.', "", false));
    }
}
```

</details>

<details>
    <summary>Proposition de correction pour la méthode "TrouverNoeudEnfantPour"</summary>

```csharp
private NoeudArbre<DonneeNoeudTrie> TrouverNoeudEnfantPour(NoeudArbre<DonneeNoeudTrie> p_noeudCourant, char p_lettre)
{
    return p_noeudCourant
        .Enfants
        .Where(n => n.Valeur.Lettre == p_lettre)
        .SingleOrDefault();
}
```

</details>

<details>
    <summary>Proposition de correction pour charger le fichier et ajouter chaque mot à l'arbre</summary>

```csharp
static ArbreAutoCompletion Charger(string p_nomFichierDictionnaire)
{
    if (string.IsNullOrWhiteSpace(p_nomFichierDictionnaire))
    {
        throw new ArgumentException("p_nomFichierDictionnaire");
    }

    ArbreAutoCompletion trie = new ArbreAutoCompletion();

    using (StreamReader sr = new StreamReader(p_nomFichierDictionnaire))
    {
        while (!sr.EndOfStream)
        {
            string mot = sr.ReadLine();
            mot = mot.Trim();
            if (!string.IsNullOrWhiteSpace(mot))
            {
                trie.AjouterMot(mot);
            }
        }

        sr.Close();
    }

    return trie;
}
```

</details>

## Exercice 3 - Compléter un préfixe

- Sur papier :
  - Écrire l’algorithme « CompleterPrefixe » permettant, à partir de l’arbre et d’un mot, de trouver tous les mots possibles à partir de ce préfixe
- Sur machine, implantez cet algorithme au travers :
  - D’une méthode publique qui ne prend que le préfixe à compléter en paramètre et qui retourne la liste des mots possibles
  - Des méthodes privées qui prennent tous les paramètres nécessaires à votre algorithme. Conseils, faites au moins deux méthodes :
  - Une pour trouver le nœud (s’il existe) qui correspond au préfixe
  - Une autre pour collecter tous les mots valides à partir d’un nœud

Pour ajouter tous les éléments d'une collection dans une autre, vous pouvez utiliser la [méthode "AddRange" de la classe "List"](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange?view=netcore-3.1). Vous pouvez aussi utiliser la [méthode "Concat" de la classe "Enumerable"](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.concat?view=netcore-3.1).


## Exercice 4 - Arbre d'expressions

Dans cet exercice, on se propose d'avoir deux types de noeuds : soit une valeur entière, soit un opérateur binaire de type +, -, *, /. Ici une valeur entière est une feuille et inversement. Les noeuds qui ne sont pas des feuilles sont alors des opérateur binaires.

L'expression "2 + 3 * 4 + 5" peut être représentée avec l'arbre suivant :

```bash
     +
    / \
   +   5
  / \
 2   *
    / \
   3   4
```

- Sur le papier, effectuez un parcours infixe et écrivez le résultat. Avez-vous la même expression ?
- Proposez une structure afin de représenter un tel arbre
- Codez votre structure
- Dans la classe « GenerateurArbreExpression », écrivez la méthode statique « ExempleExpression1 » qui renvoie un arbre d'expressions qui permet de représenter l'expression "2 + 3 * 4 + 5"
- Dans la classe « GenerateurArbreExpression », écrivez la méthode statique « ExempleExpression2 » qui renvoie un arbre d'expressions qui permet de représenter l'expression "42 * 3 + 17 - 23 / 7"
- Ajoutez la méthode "Calculer()" dans les classes qui représentent les noeuds. Cette méthode renvoie un entier et ne prend pas de paramètre. Elle se base sur la valeur du noeud pour un entier ou sur l'opération binaire du noeud réalisée sur les fils gauche et droit.
- La première expression peut être représentée avec la notation préfixe qui est non ambigue : "+ + 2 * 3 4 5"
- À partir de l'arbre de la deuxième expression, trouvez son écriture en notation préfixe.
- Écrivez un algorithme qui à partir d'une expression au format préfixe valide, génère l'arbre d'expressions.

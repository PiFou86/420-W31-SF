# Module 04 - Liste chaînée

Tout au long des l'exercices :

- écrire les préconditions.
- dessiner / écrire les algorithmes (comme dans le cours).
- écrire les cas de tests.
- faites un tableau récapitulatif des complexités de chaque méthode.

## Exercice 1 - Liste simplement chaînée

### Préparation de la solution

1. Créez un projet Visual Studio avec le nom "AA_Module04_ListesChainees" et de type "Bibliothèque de classes.
2. Dans la solution associée, ajoutez un projet de tests xUnit avec le nom "TestsAA_Module04_ListesChainees" et liez-le au projet précédent.
3. Ajoutez un autre projet de type "Application console" nommé "AA_Module04_ListesChainees_Console" qui contiendra votre "Program.cs".
4. Créez la classe "ListeChainee" dans la classe "AA_Module04_ListesChainees" qui prend le type d'éléments en paramètres.
5. Créez la classe "NoeudListeChainee" dans la classe "AA_Module04_ListesChainees" qui prend le type d'éléments en paramètres.
6. Dans la classe "ListeChainee", ajoutez les propriétés suivantes :
   1. PremierNoeud

     - Get : renvoie la référence du premier noeud de la liste
     - Private set : définit la référence du premier noeud de la liste

   2. DernierNoeud

     - Get : renvoie la référence du dernier noeud de la liste
     - Private set : définit la référence du dernier noeud de la liste

7. Dans la classe "ListeChainee", ajoutez les propriétés suivantes :
   1. Suivant

     - Get : renvoie la référence du noeud suivant
     - Private set : définit la référence du noeud suivant

   2. Precedent

     - Get : renvoie la référence du noeud précédent
     - Private set : définit la référence du noeud précédent

8. Indiquez à la classe que vous implantez ```IEnumerable<TypeElement>``` et ```IList<TypeElement>```.
9. Utilisez les actions rapides pour implanter les interfaces : les méthodes et propriétés contiendront le code :

   ```csharp
   throw new NotImplementedException();
   ```

10. Créez la classe "EnumeratorListeChainee"
11. Modifiez le code de la classe pour :

```csharp
public class EnumeratorListeChainee<TypeElement> : IEnumerator<TypeElement>
{
    private NoeudListeChainee<TypeElement> m_noeudCourant = null;
    private ListeChainee<TypeElement> m_listeChainee;
    private TypeElement m_current;

    internal EnumeratorListeChainee(ListeChainee<TypeElement> p_listeChainee)
    {
        this.m_listeChainee = p_listeChainee;
        this.Reset();
    }

    public TypeElement Current
    {
        get
        {
            return this.m_current;
        }
    }

    object IEnumerator.Current => this.Current;

    public void Dispose()
    {
        ;
    }

    public bool MoveNext()
    {
        bool continuer = this.m_noeudCourant != null;
        if (continuer)
        {
            this.m_current = this.m_noeudCourant.Valeur;
            this.m_noeudCourant = this.m_noeudCourant.Suivant;
        }

        return continuer;
    }

    public void Reset()
    {
        this.m_noeudCourant = this.m_listeChainee.PremierNoeud;
        this.m_current = default;
    }
}
```

12. Modifiez recopiez le code des suivants dans les méthodes appropriées de la classe "ListeChainee"

```csharp
public IEnumerator<TypeElement> GetEnumerator()
{
    return new EnumeratorListeChainee<TypeElement>(this);
}

IEnumerator IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}
```

### Création de la structure de données

Implantez les données membres, méthodes et propriétés dans l'ordre suivant :

1. Count (propriété) : entier
   - Get : renvoie le nombre d'éléments de la collection
   - Private set : modifie le nombre d'éléments de la collection
2. IsReadOnly (propriété) :
   - Get : renvoie faux
3. Constructeurs :
   - ```public ListeChainee()``` : crée une collection vide.
   - ```public ListeChainee(IEnumerable<TypeElement> p_elements)``` : crée une collection avec comme éléments les mêmes éléments que ceux passés en paramètres. Vous pouvez itérer sur la collection avec "foreach". La capacité et le nombre d'éléments sont égaux au nombre d'éléments passés en paramètres.
4. Opérateur crochet (```public TypeElement this[int p_indice]```) :
   - Get : renvoie la valeur présente à l'indice p_indice (si cohérent par rapport au nombre d'éléments)
   - Set : affecte la valeur à l'indice p_indice (si cohérent par rapport au nombre d'éléments)
5. Add : ajoute un élément à la fin de la collection.
6. AddFirst : ajoute un élément au début de la collection.
7. Insert : insère un élément à la collection. Si l'indice est égal au nombre d'éléments, insérer la valeur à la fin (équivalent à Add).
8. IndexOf : recherche si une valeur est dans la collection. Renvoie l'indice de la première position trouvée ou -1 si non trouvé. Attention, la valeur recherchée peut être nulle. Dans ce dernier cas, renvoie la première position d'une valeur nulle.
9. Contains : renvoie vrai si l'élément passé en paramètre est présent dans la liste, faux sinon.
10. Clear : supprime les éléments de la collection. La capacité doit être inchangé. Les éléments de la collection doivent pouvoir être collectés par le ramasse miettes.
11. RemoveAt : supprime l'élément se trouvant à un indice donné.
12. Remove : supprimer la première occurrence de l'élément passé en paramètres
13. CopyTo : copie les éléments de la collection dans le tableau passé en paramètres à partir de l'indice indiqué pour le tableau destination (sert par exemple à concaténer deux collection).

### Tableau récapitulatif des complexités

Mettez une méthode par ligne et donnez la complexité algorithmique dans le meilleur des cas et dans le pire des cas :

|Algorithme|Meilleur des cas|Pire des cas|
|---|:-:|:-:|
|NombreElements|O(1)|O(n)|

### Questions en vrac

1. Quelle serait la complexité de la méthode "Add" si vous n'aviez pas la référence du dernier élément ?
2. Quelle serait la complexité de la méthode "get" de la propriété "Count" si vous n'aviez pas utilisé une variable pour garder la valeur ?
3. Quelle serait la complexité d'un parcours naïf de l'indice 0 à "Count - 1 " ou de l'inverse de "Count - 1" à 0 ?
4. Que pouvez-vous voir en comparant les deux ?

## Exercice 2 - Liste doublement chaînée (Optionnel)

Refaites le même exercice que précédemment mais avec une liste doublement chaînée.

L'énumérateur contiendra le même code mais en y adaptant les types.

Essayez d'écrire un énumérateur qui parcours la collection à partir de la fin.

Déduisez-en la méthode "Reverse" qui crée une nouvelle liste doublement chaînée contenant les données en sens inverse.

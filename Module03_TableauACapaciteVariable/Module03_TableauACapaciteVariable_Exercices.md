# Tableau à capacité variable

Tout au long des l'exercices :

- écrire les préconditions.
- dessiner / écrire les algorithmes (comme dans le cours).
- écrire les cas de tests.
- faites un tableau récapitulatif des complexités de chaque méthode.

## Exercice 1 - Tableau à capacité variable

### Préparation de la solution

1. Créez un projet Visual Studio avec le nom "AA_Module03_TableauACapaciteVariable" et de type "Bibliothèque de classes.
2. Dans la solution associée, ajoutez un projet de tests xUnit avec le nom "TestsAA_Module03_TableauACapaciteVariable" et liez-le au projet précédent.
3. Ajoutez un autre projet de type "Application console" nommé "AA_Module03_TableauACapaciteVariable_Console" qui contiendra votre "Program.cs".
4. Créez la classe "TableauCapaciteVariable" dans la classe "AA_Module03_TableauACapaciteVariable" qui prend le type d'éléments en paramètres.
5. Indiquez à la classe que vous implantez ```IEnumerable<TypeElement>``` et ```IList<TypeElement>```.
6. Utilisez les actions rapides pour implanter les interfaces : les méthodes et propriétés contiendront le code :

   ```csharp
   throw new NotImplementedException();
   ```

7. Créez la classe "EnumeratorTableauCapaciteVariable"
8. Modifiez le code de la classe pour :

```csharp
public class EnumeratorTableauCapaciteVariable<TypeElement> : IEnumerator<TypeElement>
{
    private int m_indiceCourante = 0;
    private TableauCapaciteVariable<TypeElement> m_tcv;
    private TypeElement m_current;

    internal EnumeratorTableauCapaciteVariable(TableauCapaciteVariable<TypeElement> p_tableauCapaciteVariable)
    {
        this.m_tcv = p_tableauCapaciteVariable;
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
        bool continuer = this.m_indiceCourante < this.m_tcv.Count;
        if (continuer)
        {
            this.m_current = this.m_tcv[this.m_indiceCourante];
            ++this.m_indiceCourante;
        }

        return continuer;
    }

    public void Reset()
    {
        this.m_indiceCourante = 0;
        this.m_current = default;
    }
}
```

9. Modifiez recopiez le code des suivants dans les méthodes appropriées de la classe "TableauCapaciteVariable"

```csharp
public IEnumerator<TypeElement> GetEnumerator()
{
    return new EnumeratorTableauCapaciteVariable<TypeElement>(this);
}

IEnumerator IEnumerable.GetEnumerator()
{
    return this.GetEnumerator();
}
```

### Création de la structure de données

Implantez les données membres, méthodes et propriétés dans l'ordre suivant :

1. m_donnees : tableau de capacité éléments, contient les données de la collection
2. Capacite_Par_Defaut : entier, contient la capacité par défaut d'une collection. La donnée est constante et de valeur 1.
3. Count (propriété) : entier
   - Get : renvoie le nombre d'éléments de la collection
   - Private set : modifie le nombre d'éléments de la collection
4. Capacity (propriété) :
   - Get : renvoie la capacité actuelle (et donc la valeur correspondante à la propriété Lenght du tableau de données)
   - Private set : modifie m_donnee afin qu'il corresponde à la capacité demandé (value)
5. IsReadOnly (propriété) :
   - Get : renvoie faux
6. Constructeurs :
   - ```public TableauCapaciteVariable(int p_capacite = CapaciteParDefaut)``` : crée une collection avec une capacité de départ de p_capacite éléments avec p_capacite >= 0.
   - ```public TableauCapaciteVariable(IEnumerable<TypeElement> p_elements)``` : crée une collection avec comme éléments les mêmes éléments que ceux passés en paramètres. Vous pouvez itérer sur la collection avec "foreach". La capacité et le nombre d'éléments sont égaux au nombre d'éléments passés en paramètres.
7. ```private void AugmenterCapacite()``` : à chaque appel, augmente la capacité par deux.
8. Opérateur crochet (```public TypeElement this[int p_indice]```) :
   - Get : renvoie la valeur présente à l'indice p_indice (si cohérent par rapport au nombre d'éléments)
   - Set : affecte la valeur à l'indice p_indice (si cohérent par rapport au nombre d'éléments)
9. Add : ajoute un élément à la fin de la collection.
10. Insert : insère un élément à la collection. Si l'indice est égal au nombre d'éléments, insérer la valeur à la fin (équivalent à Add).
11. IndexOf : recherche si une valeur est dans la collection. Renvoie l'indice de la première position trouvée ou -1 si non trouvé. Attention, la valeur recherchée peut être nulle. Dans ce dernier cas, renvoie la première position d'une valeur nulle.
12. Contains : renvoie vrai si l'élément passé en paramètre est présent dans la liste, faux sinon.
13. Clear : supprime les éléments de la collection. La capacité doit être inchangé. Les éléments de la collection doivent pouvoir être collectés par le ramasse miettes.
14. RemoveAt : supprime l'élément se trouvant à un indice donné.
15. Remove : supprimer la première occurrence de l'élément passé en paramètres
16. CopyTo : copie les éléments de la collection dans le tableau passé en paramètres à partir de l'indice indiqué pour le tableau destination (sert par exemple à concaténer deux collection).

### Tableau récapitulatif des complexités

Mettez une méthode par ligne et donnez la complexité algorithmique dans le meilleur des cas et dans le pire des cas :

|Algorithme|Meilleur des cas|Pire des cas|
|---|:-:|:-:|
|NombreElements|O(1)|O(1)|

# Module 07 - Récursivité

## Exercice 1 - Compter en négatif

- Écrivez une première fonction récursive qui affiche les nombres de -n à 0 sur la console.
- Écrivez une seconde fonction récursive qui affiche les nombres de 0 à -n.
- Si vous avez utilisé plus d'une paramètre pour la seconde méthode, écrivez une variante à un paramètre.

## Exercice 2 - Division entière

Écrivez une fonction récursive qui calcule le reste de la division entière de deux nombres entiers sans utiliser l'opérateur modulo.

## Exercice 3 - Suite de Fibonacci

La suite est définie de la façon suivante :

```
- Fibonacci(0) = 0
- Fibonacci(1) = 1
- Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2)
```

1. Écrivez la fonction ```Fibonacci``` en version récursive qui calcule une valeur de la suite de Fibonacci.
2. Avec cette fonction, calculez ```Fibonacci(10)``` et validez que vous obtenez bien la valeur ```55```.
3. Quelle est la complexité de votre fonction ? (Pour vous aider, dessinez l'arbre d'appels des fonctions)
4. Modifiez votre programme principal pour qu'il calcule les valeurs de ```Fibonacci``` de 1 à 40. Affichez les temps en Ticks et tracez la courbe sur Excel afin de valider la complexité que vous aviez trouvé.
5. Pourquoi la complexité est-elle aussi élevée ?
6. Comment pourriez-vous améliorer votre fonction ? Réécrivez une version optimisée.

## Exercice 4 - Liste chaînée

1. Écrivez la fonction récursive ```CompterNombreElements``` qui prend une liste chaînée générique (```LinkedList<TypeElement>```) et qui renvoie son nombre d'éléments en parcours tous ses noeuds (```LinkedListNode<TypeElement>```). Cette fonction est l'équivalente de la fonction ```Count``` de la classe ```LinkedList```.
2. Écrivez la fonction récursive ```CalculerMaximum``` qui prend une liste chaînée générique et qui renvoie la valeur la plus grande. Cette fonction est l'équivalente de la fonction ```Max``` de la classe ```LinkedList```. On considère ici que ```TypeElement``` implémente l'interface ```IComparable``` (Équivalent de la [méthode ```Max``` de LinkedList](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.max?view=net-6.0#System_Linq_Enumerable_Max__1_System_Collections_Generic_IEnumerable___0__).
3. Écrivez la fonction de parcours récursive ```Parcourir``` qui prend une liste chaînée générique et une fonction lambda qui ne renvoie rien (```Action<TypeElement>```) et qui applique cette fonction sur chacun des noeuds (Équivalent de la [méthode ```ForEach``` de List](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.foreach?view=net-6.0).
4. Réécrivez une nouvelle version des fonctions ```CompterNombreElements``` et ```CalculerMaximum``` en utilisant la fonction ```Parcourir```.

## Exercice 5 - Recherche

1. Écrivez la fonction ```Rechercher``` qui recherche un élément dans une collection de manière récursive (Équivalent de la [méthode ```Find``` de List](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.find?view=net-6.0#System_Collections_Generic_List_1_Find_System_Predicate__0__):
   - Elle prend un ```IEnumerable<TypeElement>``` comme collection, une fonction lambda en paramètres indiquant si c'est la valeur à rechercher
   - Elle renvoie l'élément s'il est trouvé, la valeur par défaut sinon
   - La fonction lambda prend une valeur en paramètres et renvoie vrai si c'est la valeur à trouver, faux sinon
   - Votre fonction privée doit prendre un ```IEnumerator<TypeElement>``` en paramètres ainsi que la fonction lambda.

2. Écrivez la fonction récursive ```CompterNombreOccurences``` qui permet de compter le nombre d'éléments qui correspondent au critère d'une fonction lambda passée en paramètres (Équivalent de la [méthode ```Count``` de Linq](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.count?view=net-6.0#System_Linq_Enumerable_Count__1_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Boolean__)) :
   - La fonction lambda prend une valeur en paramètres et renvoie vrai si c'est la valeur à compter, faux sinon.
   - Votre fonction privée doit prendre un ```IEnumerator<TypeElement>``` en paramètres ainsi que la fonction lambda.
   - Votre fonction renvoie le nombre d'occurrences

3. Écrivez la fonction récursive ```Filtrer``` qui permet de filtrer une collection d'éléments qui correspondent au critère d'une fonction lambda passée en paramètres (Équivalent de la [méthode ```Where``` de Linq](https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.where?view=net-6.0#System_Linq_Enumerable_Where__1_System_Collections_Generic_IEnumerable___0__System_Func___0_System_Boolean__)) :
   - La fonction lambda prend une valeur en paramètres et renvoie vrai si c'est la valeur à trouver, faux sinon.
   - Votre fonction privée doit prendre un ```IEnumerator<TypeElement>``` en paramètres ainsi que la fonction lambda.
   - Votre fonction renvoie une liste d'éléments du même type que les éléments de l'énumération.

## Exercice 6 - Recherche dichotomique

Écrivez la fonction de recherche dichotomique récursive ```RechercherDichotomiquement``` qui prend un tableau d'éléments, une fonction lambda en paramètres et qui renvoie l'élément s'il est trouvé, la valeur par défaut sinon :

- La fonction lambda prend une valeur en paramètres et renvoie un entier correspondant à sa position par rapport à la valeur cherchée.
- Votre fonction privée doit prendre un tableau, les indices de début et de fin du sous-tableau ainsi que la fonction lambda.

## Exercice 7 - On se complique la vie pour l'exercice ! (Optionnel)

Réécrivez une nouvelle version de la fonction factorielle non optimisée mais sans utiliser la récursivité mais en la simulant. Pour cela, vous devez simuler la pile d'exécution (utilisez la [classe Stack](https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-6.0)) en y mettant les paramètres sur la pile. Les appels sont simulées par une boucle "tant que".

# Pile et file

Pour les exercices suivants, il est conseillé d'écrire les tests unitaires avant d'écrire une opération / propriété (approche de type TDD).

N'oubliez pas les préconditions. Si nécessaire, ajoutez des exceptions plus adéquats et explicites (Exemple : PileVideException).

## Exercice 1 - Implantation d'une pile

Le but de l'exercice est d'implanter une pile avec les opérations classiques qui sont "Empiler" et "Depiler" une valeur.

La structure de données doit se baser sur le "TableauACapaciteVariable". Elle doit contenir seulement les opérations et propriétés suivantes :

1. EstPileVide (propriété) :
   - Get : renvoie faux si la pile a au moins un élément, vrai sinon
2. Count (propriété) :
   - Get : renvoie le nombre d'éléments de la pile
3. Empiler : empile une valeur sur la pile
4. Sommet : renvoie la valeur qui se trouve au sommet de la pile sans dépiler la valeur
5. Depiler : dépile une valeur de la pile et la renvoie

Note : le programmeur qui utilise votre pile ne doit pas savoir comment vous représentez vos données.

Quelles sont les complexités des 5 opérations / propriétés ?

## Exercice 2 - Implantation d'une file

Le but de l'exercice est d'implanter une file avec les opérations classiques qui sont "Enfiler" et "Defiler" une valeur.

La structure de données doit se baser sur le "ListeChainee". Elle doit contenir seulement les opérations et propriétés suivantes :

1. EstFileVide (propriété) :
   - Get : renvoie faux si la file a au moins un élément, vrai sinon
2. Count (propriété) :
   - Get : renvoie le nombre d'éléments de la file
3. Enfiler : enfile une valeur sur la file
4. Tete : renvoie la valeur qui se trouve en tête de la file sans défiler la valeur
5. Defiler : défile une valeur de la file et la renvoie

Note : le programmeur qui utilise votre file ne doit pas savoir comment vous représentez vos données.

Quelles sont les complexités des 5 opérations / propriétés ?

## Exercice 3 - Valider des parenthèses

Choisissez une des deux structures précédentes afin d'écrire un algorithme qui permet de valider une expression contenant des parenthèses ouvrantes et d'autres fermantes. Une expression est représentée par une chaîne de caractères. Les autres caractères sont simplement ignorés.

Afin d'être valide une expression doit avoir une parenthèse fermante qui correspond à une parenthèse ouverte.

Exemples :
```console
)()( => false (invalide)
(())())( => false (invalide)
(ab + sdf dsd (sdf)) => true (valide)
```

## Exercice 4 - Une file à partir de piles (Optionnel - pour les plus téméraires !)

Écrivez une nouvelle version d'une file générique. Cette file doit utiliser seulement une ou des piles afin de réaliser les algorithmes et stocker les données. (Combien vous faut-il de piles ?)

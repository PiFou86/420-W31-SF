# Révisions et généralisation

Pour tous les exercices de ce module et des modules suivants, il faut :

- Se demander si le problème est simple. Si ce n'est pas le cas, on ne touche pas au clavier et on teste sur le papier / tableau blanc
- Ne pas oublier les pré-conditions :
  - Pour les fonctions, simplement si vous avez des paramètres
  - Pour les méthodes, avec ou sans paramètre, il peut y avoir des préconditions sur l'état de l'objet
  - Une pré-condition par paramètre ou par état
- Effectuer des tests unitaires :
  - Pour les fonctions :
    - un seul cas si pas de paramètre
    - un par précondition
    - autant qu'il y a de combinaisons intéressantes des paramètres
  - Pour les méthodes :
    - il faut faire un cas de test par état possible de l'objet
    - s'il y a des paramètres, les cas se multiplient par état, et par combinaison de paramètres

## Exercice 1 - Tri

Écrivez les fonctions "TriABulle" et "TriRapide" qui prennent une liste d'éléments génériques en paramètres et qui renvoie une nouvelle liste triée.

Pour effectuer les comparaisons, vous devez utiliser la notation "where" avec l'interface ["IComparable\<TypeElement>"](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable-1?view=netcore-3.1).

## Exercice 2 - Recherche

Écrivez les fonctions "RechercheSimple" et "RechercheDichotomique" qui prennent une liste d'éléments génériques et qui renvoient vrai si l'élément appartient à la liste, faux sinon.

Pour valider l'égalité, utilisez la méthode "Equals".

## Exercice 3 - Tri lambda

Écrivez les fonctions "TriABulle" et "TriRapide" qui prennent une liste d'éléments génériques et une fonction lambda de comparaison en paramètres et qui renvoie une nouvelle liste triée. La fonction de comparaison renvoie vrai si le premier paramètres est inférieur ou égal au deuxième paramètre.

## Exercice 4 - Recherche lambda

Écrivez la fonction "RechercheSimple" qui prend une liste d'éléments génériques et une fonction lambda de validation d'égalité en paramètres qui renvoie vrai si l'élément appartient à la liste, faux sinon. La fonction d'égalité renvoie vrai si le premier paramètres est égal au deuxième paramètre.

Écrivez la fonction "RechercheDichotomique" qui prend une liste d'éléments génériques, une fonction lambda de validation d'égalité et une fonction lambda de comparaison en paramètres qui renvoie vrai si l'élément appartient à la liste, faux sinon. La fonction d'égalité renvoie vrai si le premier paramètres est égal au deuxième paramètre. La fonction de comparaison renvoie vrai si le premier paramètres est inférieur ou égal au deuxième paramètre.

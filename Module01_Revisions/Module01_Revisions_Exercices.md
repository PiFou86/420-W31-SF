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

Écrivez les fonctions "TriABulleLambda" et "TriRapideLambda" qui prennent une liste d'éléments génériques et une fonction lambda de comparaison en paramètres et qui renvoie une nouvelle liste triée. La fonction de comparaison renvoie vrai si le premier paramètres est inférieur ou égal au deuxième paramètre.

## Exercice 4 - Recherche lambda

Écrivez la fonction "RechercheSimpleLambda" qui prend une liste d'éléments génériques et une fonction lambda de validation d'égalité en paramètres qui renvoie vrai si l'élément appartient à la liste, faux sinon. La fonction d'égalité renvoie vrai si le premier paramètres est égal au deuxième paramètre.

Écrivez la fonction "RechercheDichotomiqueLambda" qui prend une liste d'éléments génériques, une fonction lambda de validation d'égalité et une fonction lambda de comparaison en paramètres qui renvoie vrai si l'élément appartient à la liste, faux sinon. La fonction d'égalité renvoie vrai si le premier paramètres est égal au deuxième paramètre. La fonction de comparaison renvoie vrai si le premier paramètres est inférieur ou égal au deuxième paramètre.

## Exercice 5 - Méthodes d'extensions

Reprenez la fonction "RechercheSimple" et transformez la en la méthode d'extension "Filtrer". (Version simplifiée du "where")

Écrivez la méthode d'extension "Projeter" qui prend une liste générique en paramètres, une fonction lambda de transformation et qui renvoie une nouvelle liste du type de retour de la fonction lambda. (Version simplifiée du "select")

## Exercice 6 - Histogramme

Écrire une fonction qui affiche les valeurs d’un histogramme sous forme graphique.

Exemple : [3, 6, 3, 4, 1]

```console
  #
  #
  #   #
# # # #
# # # #
# # # # #
3 6 3 4 1
```

(Problème extrait de la lettre quotidienne "Daily interview pro" de techseries.dev)

## Exercice 7 - Témoin d’un crime

N personnes sont en file et leur grandeur (hauteur) est représentée par un entier. Un meurtre est arrivé devant eux et seulement les personnes plus grandes que les personnes qui sont devant elles peuvent avoir vu ce qui s’est passé.

Écrivez une fonction qui à partir d’une liste d’entiers représentant les grandeurs des différents témoins, renvoie une nouvelle liste contenant les grandeurs des témoins.

**Attention** : vous n'avez droit qu'à un seul parcours pour construire votre résultat (pas de boucle interne)

Exemple : [3, 6, 3, 4, 1] => [6, 4, 1]

```console
  #
  #
  #   #
# # # #
# # # #
# # # # #
3 6 3 4 1                                 x (scène de crime)
```

(Problème extrait de la lettre quotidienne "Daily interview pro" de techseries.dev)

## Exercice 8 - Première lettres récurrentes

Étant donné une chaîne de caractères, renvoyez la première lettre doublé. Si aucune n'est trouvée, renvoyez "null" (utilisez char? ou Nullable<char>).

Exemples :

- "asdfdgh" => null
- "zxxcvbnm" => 'x'

(Problème extrait de la lettre quotidienne "Daily interview pro" de techseries.dev)

## Exercice 9 - Somme de nombres

Soient deux listes (l1, l2) et une valeur cible (s). Vous devez trouver la liste des pairs [(n1l1, n1l2) de nombres dont la somme se rapproche le plus de s.

Exemple :

- l1 = [-1, 3, 8, 2, 9, 5, 1]
- l2 = [4, 1, 2, 10, 5, 20]
- s = 24

=> [(5, 20), (3, 20)]
(25 et 23 ont la même différence avec 24 et sont donc des candidats)

Ce problème est tiré d'une vidéo YouTube (CS Dojo). Il devrait vous prendre un peu de temps. N'allez pas voir les solutions tout de suite ([Problème et solutions très bien expliquées](https://www.youtube.com/watch?v=GBuHSRDGZBY)).

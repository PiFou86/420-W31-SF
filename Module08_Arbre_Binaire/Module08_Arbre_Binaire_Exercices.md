# Module 08 - Arbre binaire

## Exercice 1 - Structure ArbreBinaire

À partir de la structure vue en cours :

- Écrivez la classe « NoeudArbreBinaire » qui permet de représenter les liens vers les différents enfants et qui permet de stocker une valeur d’un type paramétré
- Écrivez la classe « ArbreBinaire » qui contient simplement le nœud racine

## Exercice 2 - Données de tests

Dans la nouvelle classe « GenerateurArbreBinaire », écrivez la méthode statique « ExempleArbre1 » qui renvoie un arbre binaire d’entiers qui est exactement le suivant :

```bash
    4
   / \
  2   5
 / \   \
1   3   6
```

## Exercice 3 - Hauteur

Dans la classe « ArbreBinaire », écrivez la méthode « get » de la propriété « Hauteur » qui calcule sa hauteur et la renvoie.

## Exercice 4 - Parcours

- À partir de l’algorithme vu en cours, dans la classe « ArbreBinaire », écrivez les méthodes suivantes :

  - ParcoursPrefixe : prend un traitement en paramètre et l’applique sur le nœud courant avant de parcourir ses fils
  - ParcoursInfixe : prend un traitement en paramètre et parcours son fils gauche puis applique le traitement sur le nœud courant et parcours son fils droit
  - ParcoursPostfixe : prend un traitement en paramètre et l’applique sur le nœud courant après de parcourir ses fils

Le traitement est une fonction qui prend la valeur en paramètres et ne renvoie rien

- Sans exécuter le code, cherchez sur papier le résultat ces parcours sur l’exemple de l’arbre que vous avez codé.
- Validez que vous avez le bon résultat avec votre programme.

## Exercice 5 - Arbre binaire de recherche

- Proposez une structure de données générique qui permet de représenter un ABR et codez la
(Le type d’élément doit implanter l’interface IComparable<TypeElement>)
- Écrivez la méthode « Minimum » qui renvoie la plus petite valeur
- Écrivez la méthode « Maximum » qui renvoie le plus grande valeur
- Quelles sont les complexités de ces deux méthodes dans le meilleur des cas ?
- Quel type de parcours permet d’afficher les valeurs dans l’ordre croissant ?
- Dans la classe « GenerateurArbreBinaire », écrivez la méthode statique « ExempleArbre2 » qui renvoie un arbre binaire d’entiers qui est exactement le suivant :

```bash
          13
       /      \
      /        \
     /          \
    -4          39
             /      \
            /        \
           24        42
         /    \    /    \
        18    35  40    56
```

## Exercice 6 - Opérations

- Écrivez et codez l’algorithme d’insertion d’une valeur dans l’arbre
- Quel problème voyez vous aux ABR ? (Pour vous aider, sur papier, essayez d’insérer les éléments suivants dans l’ordre donné : -42, -10, 0 ,15, 23, 42)
- Déduisez :

  - Quelle est la hauteur idéale d’un arbre binaire de recherche ?
  - Quelle est la hauteur dans le pire des cas de l’arbre binaire de recherche ?
- Déterminer sur papier comment rechercher une valeur
- Écrivez et codez l’algorithme

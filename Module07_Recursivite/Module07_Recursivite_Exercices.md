# Module 07 - Récursivité

## Compter en négatif

Écrivez une première fonction récursive qui affiche les nombres de -n à 0 à l'écran.

Écrivez une seconde fonction récursive qui affiche les nombres de 0 à -n. Si vous avez utilisé plus d'une paramètre, écrivez une variante à un paramètre.

## Division entière

Écrivez une fonction récursive qui calcule le reste de la division entière de deux nombres entiers sans utiliser le modulo.

## Suite de Fibonacci

La suite est définie de la façon suivante :

- Fibonacci(0) = 0
- Fibonacci(1) = 1
- Fibonacci(n) = Fibonacci(n - 1) + Fibonacci(n - 2)


Question 1 : écrivez la fonction Fibonacci en version récursive qui calcule une valeur de la suite de Fibonacci.

Avec cette fonction, calculez Fibonacci de 10 et validez que vous obtenez bien la valeur 55.

Question 2 : quelle est la complexité de votre fonction ? (Pour vous aider, dessinez l'arbre d'appels des fonctions) 

Question 3 : modifiez votre programme principal pour qu'il calcule les valeurs de Fibonacci de 1 à 40. Affichez les temps en Ticks et tracez la courbe sur Excel afin de valider la complexité que vous aviez trouvé.

Question 3 : pourquoi la complexité est-elle aussi élevée ? 

Question 4 : comment pourriez-vous améliorez votre fonction ? Réécrivez une version optimisée.

## Liste chaînée

Question 1 : écrivez une fonction récursive qui prend une liste chaînée générique et qui renvoie son nombre d'éléments en parcours tous ses noeuds.

Question 2 : écrivez une fonction récursive qui prend une liste chaînée générique et qui renvoie la valeur la plus grande.

Question 3 : écrivez une fonction récursive qui prend une liste chaînée générique et une fonction qui ne renvoie rien (Action<TypeElement>) et qui applique la fonction sur chacun des noeuds.

Question 4 : réécrivez une nouvelle version des fonctions NombreDElements et Maximmum en utilisant la fonction de parcours.
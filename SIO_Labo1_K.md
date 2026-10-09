## 1. Introduction

L'onjectif de ce labo est d'étudier et de détailler l'heuristique de coloration séquentielle **DSATUR**. Cette méthode permet de colorier les sommets d'un graphe simple et non orienté en utilisant des degrés de saturation. Nous présentons dans ce rapport notre pseudo-code, ainsi qu'une analyse des complexités.

On note *G = (V,E)* le graphe simple et non orienté, avec *n = |V|* sommets et *m = |E|* arêtes. Une coloration compatible associe à chaque sommet une couleur entière, les couleurs étant consécutives à partir de 0. Deux sommets adjacents n'ont jamais la même couleur.

L'objectif est d'obtenir une complexité temporelle et spatiale en *O(n^2)* dans le pire des cas.

## 2. Structures de données

| Structure | Type / taille | Rôle |
|---|---|---|
| `voisins` | tableau de n listes | Listes d'adjacence de G (donnée) |
| `degre` | tableau d'entiers, taille n | Degré initial de chaque sommet |
| `saturation` | tableau d'entiers, taille n | Degré de saturation courant |
| `couleur` | tableau d'entiers, taille n | Couleur de chaque sommet (-1 = non colorié) |
| `couleur_interdite` | tableau de booléens, taille n × n | `couleur_interdite[s][c] = VRAI` si un voisin colorié de `s` a la couleur `c` |

<!-- À remplir : justification du choix de n couleurs possibles (au plus Δ+1 ≤ n couleurs), justification du tableau n × n à la place d'un ensemble/dictionnaire. -->

## 3. Pseudocode

```text
Procédure DSATUR(voisins, n)

    // ---------- Initialisation ----------
    Pour sommet de 0 à n-1 faire
        degre[sommet]       <- taille de voisins[sommet]
        saturation[sommet]  <- 0
        couleur[sommet]     <- -1
        Pour c de 0 à n-1 faire
            couleur_interdite[sommet][c] <- FAUX
        Fin pour
    Fin pour

    // ---------- Boucle principale : un sommet colorié par itération ----------
    Pour iteration de 1 à n faire

        // Choix du sommet à colorier :
        //   plus grand degré de saturation,
        //   puis plus grand degré initial,
        //   puis premier rencontré
        sommet_choisi <- -1
        Pour sommet de 0 à n-1 faire
            Si couleur[sommet] = -1 alors
                Si sommet_choisi = -1
                   ou saturation[sommet] > saturation[sommet_choisi]
                   ou (saturation[sommet] = saturation[sommet_choisi]
                       et degre[sommet] > degre[sommet_choisi]) alors
                    sommet_choisi <- sommet
                Fin si
            Fin si
        Fin pour

        // Plus petite couleur disponible pour sommet_choisi
        couleur_candidate <- 0
        Tant que couleur_interdite[sommet_choisi][couleur_candidate] = VRAI faire
            couleur_candidate <- couleur_candidate + 1
        Fin tant que
        couleur[sommet_choisi] <- couleur_candidate

        // Mise à jour des voisins non coloriés
        Pour chaque voisin de voisins[sommet_choisi] faire
            Si couleur[voisin] = -1
               et couleur_interdite[voisin][couleur_candidate] = FAUX alors
                couleur_interdite[voisin][couleur_candidate] <- VRAI
                saturation[voisin] <- saturation[voisin] + 1
            Fin si
        Fin pour

    Fin pour

    Retourner couleur
Fin Procédure
```

## 4. Analyse de complexité temporelle

### 4.1 Initialisation

L'initialisation est une boucle `Pour sommet de 0 à n-1 faire` qui est exéctuée exactement *n* fois. À chaque itération, les opérations suivantes sont effectuées:
- `degré[sommet] <- taille voisins[sommet]`, les voisins sont passés en paramètre à l'algorithme, sa taille est connue, on y a donc accès en *O(1)*.
- `saturation[sommet] <- 0` et `couleur[sommet] <- -1` sont deux affectations en *O(1)*.
- Il y a une boucle interne `Pour c de 0 à n-1 faire` qui fait *n* affectations `couleur_interdite[sommet][c] <- FAUX`. Son coût est donc de *O(n)* pour chaque sommet.

Chaque itération de la boucle externe coûte *O(n)*. Cette boucle est répétée *n* fois, le coût total de l'initisalisation est: *O(n) x O(n) = O(n^2)*.

### 4.2 Boucle principale (n itérations)

#### 4.2.1 Choix du sommet

À chaque itération de la boucle princpiale on doit séléctionner le sommet non colorié de plus grand degré de saturation. En cas d'égalité, on choisit celui de plus grand degré initial. S'il y a de nouveau égalité, on prend le premier sommet rencontré.

On parcourt tous les sommets avec l'aide de cette boucle `Pour sommet de 0 à n-1 faire`. Pour chaque sommet on fait:
- Un test `couleur[sommet] == -1` se fait en *O(1)*.
- Si le sommet est non colorié, une comparaison entre `saturation[sommet]` et `saturation[sommet_choisi]` se fait en *O(1)*.

Il n'y a pas de structure complexe, on parcourt des tableaux. Le coût d'une séléction est donc en *O(n)*. La boucle principale comporte *n* itérations, une par sommet à colorier, le coût total de toutes les séléctions vaut: *O(n) x O(n) = O(n^2)*.

#### 4.2.2 Recherche de la plus petite couleur disponible

<!-- À remplir : au plus n tests = O(n) par itération, O(n²) au total. -->

#### 4.2.3 Mise à jour des voisins

<!-- À remplir : chaque liste voisins[s] est parcourue exactement une fois sur toute l'exécution (s est colorié une seule fois) → somme des degrés = 2m = O(m) au total, O(n²) car m ≤ n(n-1)/2. -->

### 4.3 Bilan

<!-- À remplir : O(n²) + O(n²) + O(n²) + O(m) = O(n²). -->

## 5. Analyse de complexité spatiale

L'analyse de complexités spatiales consiste à évaluer la quantité de mémoire utilisée par notre algorithme en fonction de la taille d'entrée. On distingue l'espace occupé par les structures d de données auxiliaires de celui occupé par l'entrée elle-même.

Les structures de données utilisées:
- `degré` est un tableau d'entiers de taille *n*, donc *O(n)*.
- `saturation` est un tableau d'entiers de taille *n*, donc *O(n)*.
- `couleur` est un tableau d'entiers de taille *n*, donc *O(n)*.
- `couleur_interdite` est un tableau de boolean de taille  *n x n*, donc *O(n^2)*.
- Il y a des variables comme `sommet` ou `sommet_choisi`, ce sont des entiers ou des booleans, donc en *O(1)*.
- `voisins` est le tableau donné en entrée. C'est un tableau  de *n* listes d'adjacence. La somme des tailles de ces listes est *2m*. L'espace occupé par l'entrée est en *O(n + m)*.

La complexité spatiale est dominée par le tableau `couleur_interdite` et vaut *O(n^2)*. En incluant l'entrée, on ajoute *O(n + m)*, mais on reste en *O(n^2)* car *m ≤ n(n-1)/2*. Dans les deux cas, la complexité spatiale totale de l'algorithme DSATUR est de *O(n^2)* dans le pire des cas.

## 6. Conclusion

<!-- À remplir : rappel que l'implémentation est en O(n²) en temps et en espace dans le pire des cas, avec uniquement des tableaux et des listes. -->

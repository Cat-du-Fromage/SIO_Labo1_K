## 1. Introduction

<!-- À remplir : rappel de l'objectif (DSATUR, O(n²) temps et espace), notations (n, m, G = (V, E)), hypothèses (graphe simple, non orienté, sommets numérotés de 0 à n-1, listes d'adjacence). -->

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

## 4. Correction

### 4.1 Validité de la coloration

<!-- À remplir : montrer que deux sommets adjacents n'ont jamais la même couleur (invariant sur couleur_interdite). -->

### 4.2 Terminaison et accès aux tableaux

<!-- À remplir : la boucle « Tant que » s'arrête et couleur_candidate ≤ n-1 (au plus deg(s) ≤ n-1 couleurs interdites), donc pas de dépassement d'indice. -->

### 4.3 Conformité avec l'algorithme 1

<!-- À remplir : le premier sommet choisi est bien un sommet de plus grand degré (saturation nulle partout, départage par le degré initial) ; la saturation est bien le nombre de couleurs *différentes* chez les voisins coloriés (grâce au test sur couleur_interdite). -->

## 5. Analyse de complexité temporelle

### 5.1 Initialisation

<!-- À remplir : n × (O(1) pour le degré + O(n) pour la ligne de couleur_interdite) = O(n²). Attention : taille d'une liste = O(1) si la taille est stockée, sinon O(deg) et total O(n + m). -->

### 5.2 Boucle principale (n itérations)

#### 5.2.1 Choix du sommet

<!-- À remplir : parcours de n sommets en O(1) chacun = O(n) par itération, O(n²) au total. -->

#### 5.2.2 Recherche de la plus petite couleur disponible

<!-- À remplir : au plus n tests = O(n) par itération, O(n²) au total. -->

#### 5.2.3 Mise à jour des voisins

<!-- À remplir : chaque liste voisins[s] est parcourue exactement une fois sur toute l'exécution (s est colorié une seule fois) → somme des degrés = 2m = O(m) au total, O(n²) car m ≤ n(n-1)/2. -->

### 5.3 Bilan

<!-- À remplir : O(n²) + O(n²) + O(n²) + O(m) = O(n²). -->

## 6. Analyse de complexité spatiale

<!-- À remplir :
- degre, saturation, couleur : 3 × O(n)
- couleur_interdite : O(n²)
- variables auxiliaires : O(1)
- entrée (voisins) : O(n + m), non comptée ou comptée, de toute façon ≤ O(n²)
→ total O(n²). -->

## 7. Conclusion

<!-- À remplir : rappel que l'implémentation est en O(n²) en temps et en espace dans le pire des cas, avec uniquement des tableaux et des listes. -->

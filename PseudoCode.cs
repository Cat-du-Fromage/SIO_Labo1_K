// private int[] DESATUR(List<Int>[] voisins, int n) ?
private void DESATUR(int n)
{
	int[] sommets = new[n];
	int[] dsat = new[n];
	int[] colors = new[n];
}
//Florian
/*
// IMPORTANT : pour chaque structure de donnée utilisée : commentaire expliquant ce que chaque structure de donné et à quoi elle sert
// couleur[v] représente la couleur du sommet courant
// -1 indqiue que le sommet n'est pas coloré
int[] couleur = new[n];

// 
int[] sommets = new[n];

// degré[v] est le degré du sommet dans le graphe initial
// Départager les sommets en cas de degré de saturation égal
int[] degre = new[n];

// degSat[v] est le nombre de couelurs différentes utilisées par les voisins déjà coloré de v.
int[] degSat = new[n];

 //tableau indiquant les couleurs interdite à un sommet donné premier index = indice du sommet et 2ème index = index de la couleur, valeur = couleur interdite  oui /non ?
 // couleur_interdite[v][c] est vrai si la couleur c est déjà utilisée par un voisin déjà coloré de v.
bool[][] couleur_interdite = new[n][n];

// Initialisation
Pour sommet de 0 à n-1 faire
	degre[sommet] <- nombre de voisins de v // taille de voisins[v]
	//deg[sommet] = 0
	//Pour chaque voisin appartenant à voisins[sommet] faire
	//	deg[sommet]++
	//Fin Pour
	degSat[sommet] = 0
	couleur[sommet] = -1
	
	Pour itération i de 0 à n-1 faire
		couleur_interdite[sommet][i] = FALSE
	Fin Pour
Fin Pour -- O(n) * [ O(m) + O(n) ] = O(n^2) ?? 
*/

/*
IL y a n couleur possible
--un sommet colorié par itération--
// Choix du premier sommet de plus haut degré de saturation
// Si égalité, on choisit le plus haut degré initial
// Si égalité, on choisit le premier rencontré
Pour iteration de 1 à n faire -O(n)

  "choix du sommet à colorier" 
  sommet_choisi = -1
  Pour sommet de 0 à n-1 faire
    Si couleur[sommet] == -1 alors
      Si sommet_choisi == -1 alors
	  		// au lieu de faire le sinon ?
			// ou saturation[sommet] > saturation[sommet_choisi]
			// ou (saturation[sommet] == saturation[sommet_choisi] et degre[sommet] > degre[sommet_choisi]) alors
			
        sommet_choisi = sommet
      //Sinon si saturation[sommet] > saturation[sommet_choisi]  
	  //	ou (saturation[sommet] == saturation[sommet_choisi] 
	  //	et degre[sommet] > degre[sommet_choisi]) alors
		
      //  sommet_choisi = sommet
      Fin si
    Fin si
  Fin pour - O(n)
  
  "plus petite couleur disponible pour sommet_choisi"
  // On continue tant que la couleur est interdite pour ce sommet
  couleur_candidate = 0
  Tant que couleur_interdite[sommet_choisi][couleur_candidate] == VRAI faire
    couleur_candidate = couleur_candidate + 1
  Fin tant que - O(n)
  couleur[sommet_choisi] = couleur_candidate
  
  "mise à jour des voisins non coloriés"
  Pour chaque voisin appartenant à voisins[sommet_choisi] faire
    Si couleur[voisin] == -1 et couleur_interdite[voisin][couleur_candidate] == FAUX alors
      couleur_interdite[voisin][couleur_candidate] = VRAI
      saturation[voisin] = saturation[voisin] + 1
    Fin si
  Fin pour - O(m)
  
Fin pour --- O(n) * [ O(n) + O(n) +O(m)] => O(n) * O(2n + m) => = O(n^2) ??
Retourner couleur

// Complexité ? je suis sûr de rien du tout
- Double boucle sur couleur_interdite à l'initialisation donc O(n^2)
- BOucle principale O(n)
	- Séléction sommet O(n), donc O(n^2) au total
	- Recherche couleur O(n) pire des cas, donc O(n^2) au total
	- Màj des voisins, se fait en un seul parcours de liste adjacence O(m)
- Complexité : O(n^2 + m) -> O(n^2)

*/

//REMY

/*
// Entrée
adjacence[0..n-1] // tableau liste adjacence graphe simple non orienté
// Sortie
couleur[0..n-1] // pire des cas, couelur[i] = couleur du sommet i
// Varaibles
n // nombre sommets
couleur[0..n-1]
degré[0..n-1] // dans graphe G pas le sous graphe
saturation[0..n-1]
sommetVu[0..n-1][0..n-1] // vrai si voisin colorié, sommetVu[voisin colorié][avec la couleur]
sommetCourrant
nbrSommetColorié
 
// Initialisations
// TODO
// 1)
sommetCourant <- 0
for i de 1 à n-1 do
  if degré[i] > degré[sommetCourant]
    sommetCourant <- i
couleur[sommetCourant] <- 0
nbrSommetColorié <- 1

// 2
for voisin in adjacence[sommetCourant]
  if couleur[voisin] == -1
    if sommetVu[voisin][0] == false
      sommetVu[voisin][0] <- true
      saturation[voisin] <- += 1
// 3)
tant que nbrSommetColorié < n do
  // 3.1), 3.2), 3.3)
  sommetCourant <- -1
  saturationMax <- -1
  degréMax <- -1
  
  for i de 0 à n-1 do
    if couelur[i] == -1
      sommetCourant <- i
      saturationMax <- saturation[i]
      degreéMax <- degré[i]
  fin for

  // 4)
  couleurCourant <- 0
  tant que sommetVu[sommetCourant][couleurCOurant] == true
    couleurCourant <- += 1
    // TODO j'ai pas fini

  fin tant // 4)
fin tant // 3)
*/

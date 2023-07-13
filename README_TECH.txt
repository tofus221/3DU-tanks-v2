Nous avons utilisé la version 2022.3.4f1 de unity

Le projet se compose uniquement de deux scènes:
-menu
-Arena

Les niveaux en eux-mêmes sont stocké dans des prefabs
Les décors et les prefabs des niveaux sont faits a la main avec des assets gratuits trouver sur l'asset store

en ce qui concerne les scripts

Joueur:
	- tankFiringSystem: s'occupe de tirer les obus du tank
	- tankMovement: s'occupe de faire bouger le tank avec les entrer de l'utilisateur
	- turretMovement: s'occupe de faire bouger la tourelle du tank
	
Le script turretMovement nous a donné pas mal de fil à retordre; 
principalement a cause du fait que la camera ne regarde pas directement
vers le sol mais est légèrement oblique par rapport à celui-ci.
Pour récupérer la position de la souris dans le monde on doit alors
le projeter sur un plan parallèle au sol.

Obus:
	- bulletBouncing: s'occupe du comportement des balles, les faire rebondir et appliquer du dégât s'il touche quelque chose
	
Enemi:
	- dumbTurretAI: s'occupe de la rotation des tourelles ennemies (full aléatoire)
	- lessDumbTurretAI: pareil mais en un peu plus intelligent (change de sens pour pointer vers le joueur)
	- tankMovementAI: s'occupe de faire bouger les tanks sur le navmesh
	
Spawner:
	- EnemySpawner: fait spawn un enemi
	- PlayerSpawner: fait spawn un joueur

Autre:
	- HealthSystem: s'occupe de la vie des différentes entités
	- LevelManager: s'occupe de changer de niveau au bon moment, s'occupe de jouer la musique au bon moment aussi
	- Menu: s'occupe du menu principal
	- MusicManager: quelque fonction pour jouer de la musique que le LevelManager utilise
	- PauseMenu: s'occupe du menu pause en jeu


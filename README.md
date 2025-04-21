Projet Console C# – Gestion des enseignants avec MySQL

Auteur : dev-2311029
Base de données : h25_devapp_2311029
Serveur : sql.decinfo-cchic.ca:33306

---

Objectif :
Ce logiciel permet d'interagir avec une base de données MySQL via des procédures stockées pour gérer des enseignants.

---

Fonctionnalités disponibles :
1. Afficher les informations d’un enseignant à partir de son ID
2. Afficher le nombre d’enseignants d’un département donné
3. Ajouter un nouvel enseignant avec validations
4. Quitter le programme

---

Étapes pour tester chaque fonctionnalité :

1️⃣ Démarrer le programme (`F5` dans Visual Studio)

2️⃣ Menu affiché :
   === MENU ===
   1. Afficher un enseignant par ID
   2. Afficher nombre d'enseignants par département
   3. Ajouter un nouvel enseignant
   4. Quitter

3️⃣ Test 1 : Afficher un enseignant
   - Choisir option 1
   - Saisir un ID valide existant (ex : 1, 2, etc.)
   - Résultat : nom et prénom s'affichent

4️⃣ Test 2 : Compter les enseignants par département
   - Choisir option 2
   - Saisir le nom d’un département existant (ex : Informatique, Mathématiques)
   - Résultat : nombre total affiché

5️⃣ Test 3 : Ajouter un enseignant
   - Choisir option 3
   - Suivre les instructions :
     • Entrer le nom, prénom, discipline (choisir un numéro)
     • Entrer courriel, téléphone
     • Saisir date d'embauche et de retraite (format yyyy-MM-dd)
     • Ancienneté (0 à 100)
     • Salaire (positif)
   - Résultat : message “Enseignant ajouté avec succès” ou erreur SQL si validation échoue

6️⃣ Test 4 : Quitter
   - Choisir option 4 pour fermer le programme

---

📋 Remarques :
- Les procédures stockées doivent être créées au préalable dans MySQL :
    • `getProfesseur`
    • `getNombresProfesseurs`
    • `ajouterEnseignant`
- Le champ `tp3_ens_id` doit être AUTO_INCREMENT
- Connexion sécurisée via la classe `MysqlConnection`

---

📦 Dépendances :
- MySQL Connector (installé via NuGet : `MySql.Data`)
- CultureInfo pour gérer les formats de date (format : yyyy-MM-dd)

---

Merci d’avoir testé ce projet !

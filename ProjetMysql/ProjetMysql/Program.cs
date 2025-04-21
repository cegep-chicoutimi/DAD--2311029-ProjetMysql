using BibliothequeFonctionsDeBase;
using System.Globalization;
namespace ProjetMysql
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Création d'une instance de connexion à la base de données
            var db = new MysqlConnection();
            db.InitialiserConnexion(); // Initialisation de la connexion MySQL

            // Boucle infinie pour le menu principal
            while (true)
            {
                Console.Clear(); // Efface l'écran à chaque itération
                Console.WriteLine("=== MENU ==="); // Affichage du menu
                Console.WriteLine("1. Afficher un enseignant par ID");
                Console.WriteLine("2. Afficher nombre d'enseignants par département");
                Console.WriteLine("3. Ajouter un nouvel enseignant");
                Console.WriteLine("4. Quitter");
                Console.Write("Choix : ");

                // Lecture du choix de l'utilisateur
                string choix = Console.ReadLine();

                // Traitement du choix via un switch
                switch (choix)
                {
                    case "1":
                        // Cas 1 : Affichage des infos d'un enseignant par son ID
                        Console.Write("Entrez l'ID de l'enseignant : ");
                        int id = int.Parse(Console.ReadLine());
                        db.AfficherEnseignantParId(id); // Appel à la méthode correspondante
                        break;

                    case "2":
                        // Cas 2 : Affichage du nombre d'enseignants par département
                        Console.Write("Entrez le nom du département : ");
                        string dep = Console.ReadLine();
                        db.CompterEnseignantsParDepartement(dep); // Appel de la méthode
                        break;

                    case "3":
                        // Cas 3 : Ajouter un nouvel enseignant avec vérification des champs

                        // Lecture et validation du nom
                        string nom = FonctionsDeBase.LireTexte("Nom : ", "Nom invalide : ", false);
                        // Lecture et validation du prénom
                        string prenom = FonctionsDeBase.LireTexte("Prenom : ", "Prenom invalide : ", false);

                        Console.Write("Département : ");

                        // Liste prédéfinie des disciplines proposées à l'utilisateur
                        List<string> disciplines = new List<string> { "Informatique", "Mathématiques", "Physique", "Chimie", "Biologie" };

                        // Affichage des choix de disciplines
                        Console.WriteLine("Choisissez une discipline parmi les options suivantes :");
                        for (int i = 0; i < disciplines.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {disciplines[i]}");
                        }

                        // Lecture et validation du choix de discipline (entier entre 1 et 5)
                        int choixDiscipline = 0;
                        while (choixDiscipline < 1 || choixDiscipline > disciplines.Count)
                        {
                            Console.Write("Entrez le numéro correspondant à la discipline : ");
                            int.TryParse(Console.ReadLine(), out choixDiscipline);
                        }

                        // Sélection de la discipline à partir du choix de l'utilisateur
                        string discipline = disciplines[choixDiscipline - 1];

                        // Lecture et validation du courriel
                        string courriel = FonctionsDeBase.LireTexte("Votre couriel : ", "Choix invalide : ");

                        // Lecture et validation du téléphone
                        string telephone = FonctionsDeBase.LireTexte("Telephone : ", "Format invalide");

                        // Lecture et validation de la date d'embauche
                        Console.Write("Date d'embauche de l'enseignant (format : yyyy-MM-dd) : ");
                        DateTime dateEmbauche;
                        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateEmbauche))
                        {
                            Console.Write("Format invalide. Veuillez entrer la date d'embauche au format yyyy-MM-dd : ");
                        }

                        // Lecture et validation de l'ancienneté (entier entre 0 et 100)
                        int anciennete = FonctionsDeBase.LireEntierMinMax("Anciete : ", 0, 100);

                        // Lecture et validation du salaire, converti en decimal
                        decimal salaire = (decimal)FonctionsDeBase.LireDoublePositif("Salaire : ");

                        // Lecture et validation de la date de retraite
                        Console.Write("Date de retraite de l'enseignant (format : yyyy-MM-dd) : ");
                        DateTime dateRetraite;
                        while (!DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateRetraite))
                        {
                            Console.Write("Format invalide. Veuillez entrer la date d'embauche au format yyyy-MM-dd : ");
                        }

                        // Appel de la méthode d'insertion avec procédure stockée
                        db.InsererEnseignantAvecProcedure(nom, prenom, discipline, courriel, telephone, anciennete, salaire, dateEmbauche, dateRetraite);
                        break;

                    case "4":
                        // Cas 4 : quitter le programme
                        return;

                    default:
                        // Si le choix n'est pas valide
                        Console.WriteLine("Choix invalide.");
                        break;
                }

                // Pause pour laisser l'utilisateur lire les résultats avant de revenir au menu
                Console.WriteLine("\nAppuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }


    }
}

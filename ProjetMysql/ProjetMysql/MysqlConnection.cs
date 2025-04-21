using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ProjetMysql
{
    // Déclaration de la classe MysqlConnection pour gérer la connexion à MySQL
    public class MysqlConnection
    {
        // Propriété publique pour stocker l'objet de connexion MySQL
        public MySqlConnection LaConnexion { get; set; } = null;

        // Constructeur par défaut (vide)
        public MysqlConnection()
        {

        }

        // Méthode pour initialiser la connexion à la base de données
        public void InitialiserConnexion()
        {
            // Chaîne de connexion à la base de données MySQL (serveur, port, utilisateur, mot de passe, base)
            string connectionString = "server=sql.decinfo-cchic.ca;port=33306;uid=dev-2311029;pwd=Balde622@@;database=h25_devapp_2311029";

            // Création de l'objet MySqlConnection avec la chaîne de connexion
            LaConnexion = new MySqlConnection(connectionString);
        }

        // Méthode privée pour vérifier que la connexion a bien été initialisée
        private void VerifierConnexionBD()
        {
            // Si la connexion est nulle, on lève une exception
            if (LaConnexion == null)
                throw new Exception("Connexion non initialisée.");
        }

        // Méthode pour afficher les informations d’un enseignant à partir de son ID
        public void AfficherEnseignantParId(int id)
        {
            VerifierConnexionBD(); // Vérifie que la connexion est bien initialisée
            try
            {
                LaConnexion.Open(); // Ouvre la connexion à la base de données

                // Création de la commande pour appeler la procédure stockée "getProfesseur"
                var cmd = new MySqlCommand("getProfesseur", LaConnexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Ajout du paramètre d’entrée "@id"
                cmd.Parameters.AddWithValue("@id", id);

                // Ajout d’un paramètre de sortie "@count" (optionnel ici)
                cmd.Parameters.Add("@count", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;

                // Exécution de la procédure stockée, lecture du résultat
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Lecture des colonnes "tp3_end_nom" et "tp3_end_prenom"
                    string nom = reader.GetString("tp3_end_nom");
                    string prenom = reader.GetString("tp3_end_prenom");

                    // Affichage des informations
                    Console.WriteLine($"Enseignant : {prenom} {nom}");
                }
            }
            catch (MySqlException ex)
            {
                // Gestion des erreurs SQL
                Console.WriteLine("Erreur : " + ex.Message);
            }
            finally
            {
                // Fermeture de la connexion, même en cas d'erreur
                LaConnexion.Close();
            }
        }

        // Méthode pour compter les enseignants appartenant à un département donné
        public void CompterEnseignantsParDepartement(string departement)
        {
            VerifierConnexionBD(); // Vérifie que la connexion est bien initialisée
            try
            {
                LaConnexion.Open(); // Ouvre la connexion

                // Appel de la procédure stockée "getNombresProfesseurs"
                var cmd = new MySqlCommand("getNombresProfesseurs", LaConnexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Ajout du paramètre d’entrée "@discipline"
                cmd.Parameters.AddWithValue("@discipline", departement);

                // Paramètre de sortie (optionnel)
                cmd.Parameters.Add("@count", MySqlDbType.Int32).Direction = System.Data.ParameterDirection.Output;

                // Exécution de la requête
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Lecture du champ "nombre" retourné par la procédure
                    int nombre = reader.GetInt32("nombre");
                    Console.WriteLine($"Nombre d'enseignants dans {departement} : {nombre}");
                }
            }
            catch (MySqlException ex)
            {
                // Affichage de l'erreur SQL
                Console.WriteLine("Erreur : " + ex.Message);
            }
            finally
            {
                // Fermeture de la connexion
                LaConnexion.Close();
            }
        }

        // Méthode pour insérer un enseignant en appelant la procédure stockée "ajouterEnseignant"
        public void InsererEnseignantAvecProcedure(string nom, string prenom, string discipline, string courriel, string telephone, int anciennete, decimal salaire, DateTime embauche, DateTime retraite)
        {
            VerifierConnexionBD(); // Vérifie que la connexion est bien initialisée
            try
            {
                LaConnexion.Open(); // Ouvre la connexion

                // Création de la commande pour appeler la procédure stockée
                var cmd = new MySqlCommand("ajouterEnseignant", LaConnexion)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                // Ajout de tous les paramètres requis par la procédure
                cmd.Parameters.AddWithValue("nom", nom);
                cmd.Parameters.AddWithValue("prenom", prenom);
                cmd.Parameters.AddWithValue("discipline", discipline);
                cmd.Parameters.AddWithValue("courriel", courriel);
                cmd.Parameters.AddWithValue("telephone", telephone);
                cmd.Parameters.AddWithValue("anciennete", anciennete);
                cmd.Parameters.AddWithValue("echelon_salaire", salaire);
                cmd.Parameters.AddWithValue("date_embauche", embauche);
                cmd.Parameters.AddWithValue("date_retraite", retraite);

                // Exécution de la procédure (pas de retour de résultats)
                cmd.ExecuteNonQuery();
                Console.WriteLine("Enseignant ajouté avec succès.");
            }
            catch (MySqlException ex)
            {
                // Gestion des erreurs MySQL
                Console.WriteLine("Erreur MySQL : " + ex.Message);
            }
            finally
            {
                // Fermeture de la connexion à la base de données
                LaConnexion.Close();
            }
        }
    }


}



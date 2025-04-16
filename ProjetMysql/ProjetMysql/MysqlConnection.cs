using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace ProjetMysql
{
    public class MysqlConnection
    {
        public MySqlConnection LaConnexion { get; set; } = null;

        public MysqlConnection()
        {

        }
            public void InitialiserConnexion()
        {
            // 
            string connectionString = "server=sql.decinfo-cchic.ca;port=33306;uid=dev-2311029;pwd=Balde622@@;database=h25_devapp_2311029";

            LaConnexion = new MySqlConnection(connectionString);

        }

        public void AppelerProcedureStockee()
        {
            VerifierConnexionBD();

            try
            {
                LaConnexion.Open();

                //Écrire la requête SQL qu'on veut exécuter
                string requete = "getProfesseur";

                MySqlCommand laCommande = new MySqlCommand(requete, LaConnexion);

                laCommande.CommandType = System.Data.CommandType.StoredProcedure;

                //Fournir les paramètres selon la procédure stockée appelée
                laCommande.Parameters.AddWithValue("@id", 4);

                //Fournir un paramètres en sortie
                laCommande.Parameters.Add("@count", MySqlDbType.Int32);
                laCommande.Parameters["@count"].Direction = System.Data.ParameterDirection.Output;

                //Choisir le bon mode d'exécution selon le type de procédure qu'on appelle
                //laCommande.ExecuteNonQuery(); //Pour exécuter des procédures qui ne retournent rien (Insert, Update, Delete)
                MySqlDataReader resultatRequete = laCommande.ExecuteReader();  //Pour exécuter des procédures qui retournent une ou plusieurs lignes (Select)
                                                                               //int resultatRequete = laCommande.ExecuteScalar(); //Pour exécuter des procédures qui retournent une seule valeur (Count, Max)
                                                                               //Récupérer la valeur d'une paramètre en sortie
                int count = Convert.ToInt32((laCommande.Parameters["@count"].Value));

                //Traiter les données selon la méthode exécutée
                while (resultatRequete.Read())
                {
                    //Méthode 1
                    string nom = resultatRequete.GetString("tp3_end_nom");
                    string departement = resultatRequete.GetString("tp3_end_prenom");
                    Console.WriteLine("Méthode 1 - Nom : " + nom + " | Departement : " + departement);

                    Console.WriteLine(@"\|/_\|/_\|/_\|/");

                    //Méthode 2
                    //string nom2 = resultatRequete.GetString(0);
                    //string departement2 = resultatRequete.GetString(1);
                    //Console.WriteLine("Méthode 2 - Nom : " + nom2 + " | Departement : " + departement2);

                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine(sqlEx.ToString());
            }
            finally
            {
                if (LaConnexion != null)
                {
                    LaConnexion.Close();
                }
            }
        }


        public void AppelerProcedureStockee1()
        {
            VerifierConnexionBD();

            try
            {
                LaConnexion.Open();

                //Écrire la requête SQL qu'on veut exécuter
                string requete = "getNombreProfesseurs";

                MySqlCommand laCommande = new MySqlCommand(requete, LaConnexion);

                laCommande.CommandType = System.Data.CommandType.StoredProcedure;

                //Fournir les paramètres selon la procédure stockée appelée
                laCommande.Parameters.AddWithValue("@discipline", "Informatique");

                //Fournir un paramètres en sortie
                laCommande.Parameters.Add("@count", MySqlDbType.Int32);
                laCommande.Parameters["@count"].Direction = System.Data.ParameterDirection.Output;

                //Choisir le bon mode d'exécution selon le type de procédure qu'on appelle
                //laCommande.ExecuteNonQuery(); //Pour exécuter des procédures qui ne retournent rien (Insert, Update, Delete)
                MySqlDataReader resultatRequete = laCommande.ExecuteReader();  //Pour exécuter des procédures qui retournent une ou plusieurs lignes (Select)
                                                                               //int resultatRequete = laCommande.ExecuteScalar(); //Pour exécuter des procédures qui retournent une seule valeur (Count, Max)
                                                                               //Récupérer la valeur d'une paramètre en sortie
                int count = Convert.ToInt32((laCommande.Parameters["@count"].Value));

                //Traiter les données selon la méthode exécutée
                while (resultatRequete.Read())
                {
                    //Méthode 1
                    string nombre = resultatRequete.GetString("nombre");
                    //string departement = resultatRequete.GetString("tp3_end_prenom");
                    Console.WriteLine("Méthode 1 - nombre : " + nombre );

                    //Console.WriteLine(@"\|/_\|/_\|/_\|/");

                    //Méthode 2
                    //string nom2 = resultatRequete.GetString(0);
                    //string departement2 = resultatRequete.GetString(1);
                    //Console.WriteLine("Méthode 2 - Nom : " + nom2 );

                }
            }
            catch (MySqlException sqlEx)
            {
                Console.WriteLine(sqlEx.ToString());
            }
            finally
            {
                if (LaConnexion != null)
                {
                    LaConnexion.Close();
                }
            }
        }


        private void VerifierConnexionBD()
        {
            if (LaConnexion == null)
            {
                throw new Exception("La connexion est nulle, veuillez Initialiser la Connexion avant.");
            }
        }

    }


    }



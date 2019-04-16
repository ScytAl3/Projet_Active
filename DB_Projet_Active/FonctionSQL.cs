using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;


namespace DB_Projet_Active
{
    public class FonctionSQL
    {
        /// <summary>
        /// Methode qui retourne un string contenant les informations pour la connexion 
        /// a la base de donnees Projet Active
        /// </summary>
        /// <returns></returns>
        static private string GetConnectionString()
        {
            /*
            //  Connection portable
            string source = "Data Source=MU-TH-UR-PORT\\SQLEXPRESS;";
            string catalogue = "Initial Catalog=DB_Projet_Active[prod];";
            */
            /*
            //  Connection Maison
            string source = "Data Source=MU-TH-UR\\SQLEXPRESS;";
            string catalogue = "Initial Catalog=DB_Projet_Active[prod];";
            */
            /*
            //  Connection Laxou
            string source = "Data Source=MU-TH-UR_W\\SQLEXPRESS;";
            string catalogue = "Initial Catalog=DB_Projet_Active[prod];";
            */
            
            //  Connection AFPA
            string source = "Data Source=STA7400390\\CDI_SQLEXPRESS;";
            string catalogue = "Initial Catalog=DB_Projet_Active_prod;";
            
            string security = "Integrated Security=true;";
            string connectionString = source + catalogue + security;
            return connectionString;
        }

        /// <summary>
        /// Traitement pour tester la connexion a la base de donnees
        /// </summary>
        public static void TestConnection()
        {
            // Tentative de connexion a SQL Server
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Echec de la connection à la base de données : " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Methode pour verifier l existence d une ou plusieurs lignes de resultat d une requete
        /// </summary>
        /// <param name="sqlRequete"></param>
        /// <returns></returns>
        public static bool Exister(string sqlRequete)
        {
            bool b_Existe = false;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                //  Creation de la commande - assignation de la requete et de la connexion
                using (SqlCommand command = new SqlCommand(sqlRequete, connection))
                {
                    connection.Open();
                    //  Creation du reader et execution de la commande
                    SqlDataReader reader = command.ExecuteReader();
                    //  Appelle du Read() avant d'accéder aux données
                    while (reader.Read())
                    {
                        //  Si pas de resultats la valeur de la colonne est null
                        if (reader.IsDBNull(0))
                        {
                            b_Existe =  false;
                        }
                        else
                        {
                            b_Existe = true;
                        }
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Echec lecture " + ex.Message, ex);
            }
            return b_Existe;
        }

        #region"--Methode qui retourne des lignes lues (SqlDataReader) ou un cache de donnees en memoire (DataTable)

        /// <summary>
        /// Methode pour remplir un DataGridView
        /// </summary>
        /// <param name="selectCommand"></param>
        /// <returns>Retourne une table</returns>
        public static DataTable Adapter(string selectCommand)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    // Creation d un nouveau data adapter base sur une requete SQL
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, GetConnectionString()))
                    {
                        // Remplissage d une nouvelle table de donnees
                        DataTable table = new DataTable();
                        table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                        dataAdapter.Fill(table);
                        return table;
                    }                                      
                }                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Echec du remplissage ! " + ex.Message);
            }
            return null;
        }                

        /// <summary>
        /// Methode pour lire une ligne de resultat d une requete
        /// </summary>
        /// <param name="sqlRequete"></param>
        /// <returns>retourne un Reader</returns>
        public static SqlDataReader Lecture(string sqlRequete)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            try
            {
                //  Creation de la commande - assignation de la requete et de la connexion
                using (SqlCommand command = new SqlCommand(sqlRequete, connection))
                {
                    connection.Open();
                    //  Creation du reader et execution
                    SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                    return reader;
                }
            }
            catch (SqlException ex)
            { throw new ApplicationException("Echec lecture " + ex.Message, ex); }
        }

        #endregion

        #region"--Methode pour la creation d identifiant--"

        /// <summary>
        /// Methode pour compter le nombre de ligne d une TABLE en fonction d une condition where
        /// </summary>
        /// <param name="select"></param>
        /// <param name="table">CLIENT ou PROSPECT</param>
        /// <param name="where">La condition where sera utilisee avec la table PROSPECT</param>
        /// <returns></returns>
        public static int CompteLigne(string select, string table, string where)
        {
            //  On concatene les differentes parties de la requete 
            string requete = select + table + where;
            int compteur = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    //  Creation de la commande - assignation de la requete et de la connexion
                    SqlCommand command = new SqlCommand(requete, connection);
                    compteur = (int)command.ExecuteScalar();                    
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Echec lecture " + ex.Message, ex);
            }
            return (int)compteur;
        }

        /// <summary>
        /// Methode pour recuperer le prochain numero d identification lors de la creation
        /// dans une TABLE si le numero d identification n est pas en AUTO-INCREMENT !
        /// </summary>
        /// <param name="requete"></param>
        /// <returns></returns>
        public static int Compte(string requete)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    //  Creation de la commande - assignation de la requete et de la connexion
                    SqlCommand command = new SqlCommand(requete, connection);
                    //  Recupere la valeur et la retourne a la procedure qui a appelee la methode 
                    int nbr = Convert.ToInt32(command.ExecuteScalar());
                    return nbr;
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Echec lecture " + ex.Message, ex);
            }
        }

        #endregion

        #region"--Methodes pour la creation, la mise a jour et la suppression dans la DB--"

        /// <summary>
        /// Methode pour inserer une ligne dans la table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="valeur"></param>
        public static void Inserer(string table, string valeur)
        {
            string requete = "insert into " + table + " values (" + valeur + ")";
            try
            {
                using(TransactionScope transScope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                    {
                        connection.Open();
                        SqlCommand commande = new SqlCommand(requete, connection);
                        commande.ExecuteNonQuery();
                    }
                    transScope.Complete();
                }                
            }
            catch(TransactionAbortedException trans_ex)
            {
                MessageBox.Show("Probleme lors de la transaction insert sur la table " + table + " : "+ trans_ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur lors l'insertion dans la table " + table + " : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode pour mettre a jour une ligne dans la table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="set"></param>
        /// <param name="where"></param>
        public static void MiseAjour(string table, string set, string where)
        {
            string requete = "update " + table + " set " + set + " where " + where;
            try
            {
                using (TransactionScope transScope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                    {
                        connection.Open();
                        SqlCommand commande = new SqlCommand(requete, connection);
                        commande.ExecuteNonQuery();
                    }
                    transScope.Complete();
                }
            }
            catch (TransactionAbortedException trans_ex)
            {
                MessageBox.Show("Probleme lors de la transaction update sur la table " + table + " : " + trans_ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour sur la table " + table + " : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode pour supprimer une ligne dans la table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="where"></param>
        public static void Supprimer(string table, string where)
        {
            string requete = "delete from " + table + where;
            try
            {
                using (TransactionScope transScope = new TransactionScope())
                {
                    using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                    {
                        connection.Open();
                        SqlCommand commande = new SqlCommand(requete, connection);
                        commande.ExecuteNonQuery();
                    }
                    transScope.Complete();
                }
            }
            catch (TransactionAbortedException trans_ex)
            {
                MessageBox.Show("Probleme lors de la transaction delete sur la table " + table + " : " + trans_ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur lors de suppression sur la table " + table + " : " + ex.Message);
            }
        }

        #endregion
    }
}

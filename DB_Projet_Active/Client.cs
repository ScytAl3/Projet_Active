using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_Projet_Active
{
    /// <summary>
    /// La Class Client qui permet d instancier des Clients. Contient les methodes pour generer la liste de client,
    /// creer, mettre a jour et supprimer un client 
    /// </summary>
    /// <remarks>
    /// <para>Auteur : Franck Jakubowski</para>
    /// <para>Version : 0.1</para>
    /// <para>Date de creation : 07/01/2019</para>
    /// </remarks>
    public class Client
    {
        //---------------------------------------------------
        //  Declaration des attributs de la class Client
        //---------------------------------------------------
        protected int idClient;
        protected string rsClient;
        protected string typeClient;
        protected string domaineClient;
        protected string adrClient;
        protected string telClient;
        protected int caClient;
        protected string commClient;
        protected int nbrEmp;

        //---------------------------------------------------
        //  Declaration des proprietes de la class Client
        //---------------------------------------------------

        #region "Proprietes"

        public int acc_idClient
        {
            get { return this.idClient; }
            set { this.idClient = value; }
        }

        public string acc_rsClient
        {
            get { return this.rsClient; }
            set { this.rsClient = value; }
        }

        public string acc_typeClient
        {
            get { return this.typeClient; }
            set { this.typeClient = value; }
        }

        public string acc_domaineClient
        {
            get { return this.domaineClient; }
            set { this.domaineClient = value; }
        }

        public string acc_adrClient
        {
            get { return this.adrClient; }
            set { this.adrClient = value; }
        }

        public string acc_telClient
        {
            get { return this.telClient; }
            set { this.telClient = value; }
        }

        public int acc_caClient
        {
            get { return this.caClient; }
            set { this.caClient = value; }
        }

        public string acc_commClient
        {
            get { return this.commClient; }
            set { this.commClient = value; }
        }

        public int acc_nbrEmp
        {
            get { return this.nbrEmp; }
            set { this.nbrEmp = value; }
        }

        #endregion

        //-----------------------------------------------------
        //  Declaration des constructeurs de la class Client
        //-----------------------------------------------------

        #region "Constructeurs de la class Client"

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public Client() { }

        /// <summary>
        /// Constructeur avec 8 variables pour instancier la class Client pour mise a jour
        /// </summary>
        /// <param name="raison"></param>
        /// <param name="type"></param>
        /// <param name="domaine"></param>
        /// <param name="adresse"></param>
        /// <param name="numTel"></param>
        /// <param name="chiffre"></param>
        /// <param name="nbEmploye"></param>
        /// <param name="commentaires"></param>
        public Client(string raison, string type, string domaine, string adresse, string numTel,
            int chiffre, string commentaires, int nbEmploye)
        {
            try
            {
                this.rsClient = raison;
                this.typeClient = type;
                this.domaineClient = domaine;
                this.adrClient = adresse;
                this.telClient = numTel;
                this.caClient = chiffre;
                this.commClient = commentaires;
                this.nbrEmp = nbEmploye;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //----------------------------------------
        //  Declaration des methodes de Class 
        //       
        //----------------------------------------

        #region "Methode de recuperation des donnees de tous les clients"

        /// <summary>
        /// Methode de Class qui renvoie la liste de tous les clients de la table selectionnee
        /// </summary>
        /// <param name="laTable"></param>
        /// <returns></returns>
        public static List<Client> AfficheListClient(string laTable)
        {
            //  Declaration de la variable qui va contenir la requete
            string requete = "select * from " + laTable;
            //  Declaration de la liste qui va contenir les objets CLIENT
            List<Client> myListClient = new List<Client>();
            try
            {
                //  Passage des parametres a la methode de class FonctionSQL
                using (SqlDataReader myReader = FonctionSQL.Lecture(requete))
                {
                    //  Si il y a une ligne dans le reader
                    if (myReader.HasRows)
                    {
                        //  Tant que le reader lit
                        while (myReader.Read())
                        {
                            //  A chaque passage on instancie un Client
                            Client LeClient = new Client();
                            //  Et on recupere la valeur de ses attributs
                            LeClient.acc_idClient = int.Parse(myReader.GetValue(0).ToString());
                            LeClient.acc_rsClient = myReader.GetValue(1).ToString();
                            LeClient.acc_typeClient = myReader.GetValue(2).ToString();
                            LeClient.acc_domaineClient = myReader.GetValue(3).ToString();
                            LeClient.acc_adrClient = myReader.GetValue(4).ToString();
                            LeClient.acc_telClient = myReader.GetValue(5).ToString();
                            LeClient.acc_caClient = int.Parse(myReader.GetValue(6).ToString());
                            LeClient.acc_commClient = myReader.GetValue(7).ToString();
                            LeClient.acc_nbrEmp = int.Parse(myReader.GetValue(8).ToString());
                            //  On stocke le client instancier dans la list
                            myListClient.Add(LeClient);
                        }
                    }// On affiche un message si myReader.HasRows = false
                    else { MessageBox.Show("La table " + laTable + " ne contient aucune ligne !"); }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme lors de la lecture de la liste ! " + ex.Message);
            }
            return myListClient;
        }

        #endregion

        //----------------------------------------
        //  Declaration des methodes d instance
        //----------------------------------------

        /// <summary>
        /// Methode d'intance pour comparer le nom de la raison sociale avec une saisie dynamique
        /// </summary>
        /// <param name="aComparer">Texte ecrit dans une TextBox de recherche</param>
        /// <returns></returns>
        public bool RaisonSocialeMatch(string aComparer)
        {
            bool b_RaisonSocialeMatch = false;
            //  Si la TextBox est vide ou null
            if (String.IsNullOrEmpty(aComparer))
            {
                //  On revoie true pour charger le DataGridView avec tous les Client
                b_RaisonSocialeMatch = true;
            }
            else
            {
                //  Sino on transforme les 2 string en tableau de caracteres majuscules pour eviter les probleme de casse
                char[] raison = this.rsClient.ToUpper().ToCharArray();
                char[] textCompare = aComparer.ToUpper().ToCharArray();
                //  Initialisation d un indexe pour parcourir les tableaux
                int i = 0;
                // Booleen pour sortir de la boucle des que les caracteres sont different
                bool different = false;
                //  Tant que pas arriver au bout du texte saisi et que different = false
                while (i < textCompare.Length && !different)
                {
                    //  Si les carateres au meme indice correspondent b_RaisonSocialeMatch passe a true
                    if (raison[i] == textCompare[i])
                    {
                        b_RaisonSocialeMatch = true;
                    }
                    else
                    {
                        b_RaisonSocialeMatch = false;
                        //  On sort de la boucle
                        different = true;
                    }
                    i++;
                }
            }
            //  Si on est pas passe dans la boucle on renvoie false
            return b_RaisonSocialeMatch;
        }

        #region "Methode d action sur la base de donnees"    

        /// <summary>
        /// Methode d instance pour la creation des champs de la table
        /// </summary>
        public virtual void CreaClient(string f_laTable)
        {
            try
            {
                //  Creation de la requete SQL pour mettre a jour
                string table = f_laTable;
                string valeurs = "'" + this.rsClient + "'";
                valeurs += ", '" + this.typeClient + "'";
                valeurs += ", '" + this.domaineClient + "'";
                valeurs += ", '" + this.adrClient + "'";
                valeurs += ", '" + this.telClient + "'";
                valeurs += ", " + this.caClient.ToString() + "";
                valeurs += ", '" + this.commClient + "'";
                valeurs += ", " + this.nbrEmp.ToString() + "";
                //  Appelle de la methode MiseAjour() de la class FonctionSQL
                FonctionSQL.Inserer(table, valeurs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode d instance pour la mise à jour des champs de la table
        /// </summary>
        /// <param name="f_laTable"></param>
        public virtual void Mise_A_Jour(string f_laTable)
        {
            try
            {
                //  Creation de la requete SQL pour mettre a jour
                string table = f_laTable;
                string set = " RSCLIENT = '" + this.rsClient + "'";
                set += ",TYPECLIENT = '" + this.typeClient + "'";
                set += ",DOMAINECLIENT = '" + this.domaineClient + "'";
                set += ",ADRCLIENT = '" + this.adrClient + "'";
                set += ",TELCLIENT = '" + this.telClient + "'";
                set += ",CACLIENT = " + this.caClient.ToString() + "";
                set += ",COMMENTAIRESCLIENT = '" + this.commClient + "'";
                set += ",NBREMPCLIENT = '" + this.nbrEmp.ToString() + "'";
                string where = " IDCLIENT = " + this.idClient.ToString();
                //  Appelle de la methode MiseAjour() de la class FonctionSQL
                FonctionSQL.MiseAjour(table, set, where);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode pour supprimer un Client... et il y a beaucoup de tables à contrôler, donc seul le bouton pour un Prospect a ete code
        /// </summary>
        /// <param name="f_laTable">="CLIENT"</param>
        /// <param name="numId">numero d identification du client selectionne dans le DataGridView</param>
        public virtual void SupClient(string f_laTable, int numId)
        {
            MessageBox.Show("La suppression de ce Client entrainera la suppression, dans les tables associées, des références à ce Client... " +
                " et le mieux est de créér une procédure dans le DB qui s'occupera de faire la suppression en chaîne.");
        }

        #endregion
    }
}

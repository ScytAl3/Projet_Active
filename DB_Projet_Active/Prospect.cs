using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
namespace DB_Projet_Active
{
    public class Prospect : Client
    {
        //-------------------------------------------------------------------
        //  Declaration des attributs supplementaires de la class Prospect
        //-------------------------------------------------------------------
        private DateTime dateProspect;
        private bool interetProspec;
        //  Variable de classe pour stocker le dernier numero identifiant cree
        public static int dernierIdentifiant;
        //  Et la derniere annee
        public static int derniereAnee;

        //-------------------------------------------------------------------
        //  Declaration des proprietes supplementaires de la class Prospect
        //-------------------------------------------------------------------

        #region "Proprietes"

        public DateTime acc_dateProspect
        {
            get { return this.dateProspect; }
            set { this.dateProspect = value; }
        }
            
        public bool acc_interetProspec
        {
            get { return this.interetProspec; }
            set { this.interetProspec = value; }            
        }

        #endregion

        //-----------------------------------------------------
        //  Declaration des constructeurs de la class Prospect
        //-----------------------------------------------------

        #region "Constructeurs de la class Client"

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public Prospect() { }

        /// <summary>
        /// Constructeur avec 10 variables pour instancier la Class Prospect pour creation
        /// </summary>
        /// <param name="raison"></param>
        /// <param name="type"></param>
        /// <param name="domaine"></param>
        /// <param name="adresse"></param>
        /// <param name="numTel"></param>
        /// <param name="chiffre"></param>
        /// <param name="commentaires"></param>
        /// <param name="nbEmploye"></param>
        /// <param name="dateProsp"></param>
        /// <param name="interet"></param>
        public Prospect(string raison, string type, string domaine, string adresse, string numTel,
            int chiffre, string commentaires, int nbEmploye, DateTime dateProsp, bool interet)
            : base(raison, type, domaine, adresse, numTel, chiffre, commentaires, nbEmploye)
        {
            try
            {
                this.dateProspect = dateProsp;
                this.interetProspec = interet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        //----------------------------------------
        //  Declaration des methodes de Class 
        //----------------------------------------

        #region "Methode de recuperation des donnees de tous les clients"

        /// <summary>
        /// Methode de Class qui renvoie la liste de tous les Prospects de la table selectionnee
        /// </summary>
        /// <param name="laTable"></param>
        /// <param name="leWhere"></param>
        /// <returns></returns>
        public static new List<Client> AfficheListClient(string laTable)
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
                            Prospect leProspect = new Prospect();
                            //  Et on recupere la valeur de ses attributs
                            leProspect.acc_idClient = int.Parse(myReader.GetValue(0).ToString());
                            leProspect.acc_rsClient = myReader.GetValue(1).ToString();
                            leProspect.acc_typeClient = myReader.GetValue(2).ToString();
                            leProspect.acc_domaineClient = myReader.GetValue(3).ToString();
                            leProspect.acc_adrClient = myReader.GetValue(4).ToString();
                            leProspect.acc_telClient = myReader.GetValue(5).ToString();
                            leProspect.acc_caClient = int.Parse(myReader.GetValue(6).ToString());
                            leProspect.acc_commClient = myReader.GetValue(7).ToString();
                            leProspect.acc_nbrEmp = int.Parse(myReader.GetValue(8).ToString());
                            leProspect.acc_dateProspect = DateTime.Parse(myReader.GetValue(9).ToString());
                            leProspect.acc_interetProspec = Convert.ToBoolean(myReader.GetValue(10).ToString());
                            //  On stocke le client instancier dans la list
                            myListClient.Add(leProspect);
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

        #region"---Traitements pour la creation du numero d identification---"

        /// <summary>
        /// Methode de class pour recuperer le dernier identifiant Prospect creer
        /// </summary>
        public static void DernierIdCreer()
        {
            //  On recupere l anne en cours
            int an = DateTime.Now.Year;
            //  On initialise le compteur du numero d identification 
            int numId = 0;
            //  On creer une requete pour recuperer la valeur max du dernier Prospect cree (de l annee en cours) dans la table PROSPECT
            string query = "select max(right(idprospect, 2)) from ";
            string from = " PROSPECT ";
            string where = " where YEAR(DATEPROSPECT) = " + an;
            string requete = query + from + where;
            //  On verifie s il existe un resultat
            try
            {
                if (FonctionSQL.Exister(requete))
                {
                    //  On compte le nombre de ligne de PROSPECTS de l annee en cours deja crees
                    int dernierIdProspect = FonctionSQL.Compte(requete);
                    //  On incremente de 1 pour le numero du PROSPECT que l on creer
                    dernierIdProspect += 1;
                    numId = dernierIdProspect;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme lors de la récupération du dernier identifiant Prospect ! " + ex.Message);
            }
            //  On stock le numero du dernier identifiant dans la variable de class dernierIdentifiant
            dernierIdentifiant = numId;
            derniereAnee = an;
        }

        /// <summary>
        /// Methode pour creer le numero identifiant d un PROSPECT : annee + nombre incremente
        /// </summary>
        /// <returns></returns>
        public static int Crea_NumIdProspect()
        {
            //  On recupere la valeur du compteur de class
            int leDernierId = dernierIdentifiant;
            //  On recupere l anne en cours
            int anEnCours = DateTime.Now.Year;
            int numIncre;
            int leNewId;
            string idPros;
            //  Si le compteur = 0 donc pas de ligne pour l annee en cours
            if (leDernierId == 0)
            {
                //  On initialise le compteur du numero d identification 
                numIncre = 1;
                //  On concatene l annee en cours et le chiffre "1" sous la forme "01"
                idPros = Convert.ToString(anEnCours) + numIncre.ToString("D2");
                //  On recupere l identifiant concatene
                leNewId = Convert.ToInt32(idPros);
            }
            //  Sinon il existe des prospects pour l annee en cours
            else
            {     
                //  Si changement d annee en cours
                if (derniereAnee < anEnCours)
                {
                    numIncre = 1;
                }
                else
                {
                    numIncre = leDernierId;
                }
                //  On concatene l annee en cours et le chiffre sous la forme "01"
                idPros = Convert.ToString(anEnCours) + numIncre.ToString("D2");                
            }
            leNewId = Convert.ToInt32(idPros);
            dernierIdentifiant = numIncre;
            return leNewId;
        }

        /// <summary>
        /// Methode pour incrementer le compteur
        /// </summary>
        public static void IncrementerCompeur()
        {
            dernierIdentifiant++;
        }

        #endregion

        //----------------------------------------
        //  Declaration des methodes d instance 
        //----------------------------------------

        /// <summary>
        /// Methode qui verifie que la duree entre la date de prospection + 30 jours est inferieure a la date du jour
        /// et que le prospect est interresse
        /// </summary>
        /// <param name="dateProspection">date a laquelle a eu lieu la prospection</param>
        /// <param name="interet">interet du prospect =true, =false</param>
        /// <returns></returns>
        public bool Relancer()
        {
            bool b_Relance = false;
            DateTime expiryDate = this.dateProspect.AddDays(30);
            if ((DateTime.Now > expiryDate) && this.interetProspec)
            {
                b_Relance = true;
            }
            return b_Relance;
        }

        #region "Methode d action sur la base de donnees"

        /// <summary>
        /// Methode d instance pour la creation d un prospect dans la table PROSPECT
        /// </summary>
        /// <param name="f_laTable"></param>
        public override void CreaClient(string f_laTable)
        {
            try
            {
                //  Creation de la requete SQL pour mettre a jour
                string table = f_laTable;
                string valeurs = "" + this.idClient + "";
                valeurs += ", '" + this.rsClient + "'";
                valeurs += ", '" + this.typeClient + "'";
                valeurs += ", '" + this.domaineClient + "'";
                valeurs += ", '" + this.adrClient + "'";
                valeurs += ", '" + this.telClient + "'";
                valeurs += ", " + this.caClient.ToString() + "";
                valeurs += ", '" + this.commClient + "'";
                valeurs += ", " + this.nbrEmp.ToString() + "";
                valeurs += ", '" + this.dateProspect.ToString("dd/MM/yyyy") + "'";
                valeurs += ", " + Convert.ToInt32(this.interetProspec) + "";
                //  Appelle de la methode MiseAjour() de la class FonctionSQL
                FonctionSQL.Inserer(table, valeurs);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la création ! : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode d instance pour la mise à jour des attributs d un prospect de la table PROSPECT
        /// </summary>
        /// <param name="f_laTable"></param>
        public override void Mise_A_Jour(string f_laTable)
        {
            try
            {
                //  Creation de la requete SQL pour mettre a jour
                string table = f_laTable;
                string set = " RSPROSPECT = '" + this.rsClient + "'";
                set += ", TYPEPROSPECT = '" + this.typeClient + "'";
                set += ", DOMAINEPROSPECT = '" + this.domaineClient + "'";
                set += ", ADRPROSPECT = '" + this.adrClient + "'";
                set += ", TELPROSPECT = '" + this.telClient + "'";
                set += ", CAPROSPECT = " + this.caClient.ToString() + "";
                set += ", COMMENTAIRESPROSPECT = '" + this.commClient + "'";
                set += ", NBREMPPROSPECT = '" + this.nbrEmp.ToString() + "'";
                set += ", DATEPROSPECT = '" + this.dateProspect.ToString("dd/MM/yyyy") + "'";
                set += ", INTERETPROSPECT = " + Convert.ToInt32(this.interetProspec) + "";
                string where = " IDPROSPECT = " + this.idClient;
                //  Appelle de la methode MiseAjour() de la class FonctionSQL
                FonctionSQL.MiseAjour(table, set, where);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour ! : " + ex.Message);
            }
        }

        /// <summary>
        /// Methode d instance pour la suppression d un prospect dans la table PROSPECT
        /// </summary>
        /// <param name="f_laTable">le nom de la table, ici "PROSPECT"</param>
        /// <param name="numId">le numero d identification du prospect que l on veut supprimer, obtenu a partir du DataGridView</param>
        public override void SupClient(string f_laTable, int numId)
        {
            try
            {
                //  Creation de la requete SQL pour suppression
                string table = f_laTable;
                string where = " where IDPROSPECT = " + this.acc_idClient;
                //  Appelle de la methode Supprimer() de la class FonctionSQL
                FonctionSQL.Supprimer(table, where);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression du prospect ! : " + ex.Message);
            }
        }

        #endregion
    }
}

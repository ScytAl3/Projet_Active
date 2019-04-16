using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DB_Projet_Active
{
    /// <summary>
    /// La Class EcranGestion qui affiche, dans un DataGridView, en fonction du choix a l ecran
    /// d accueil et la liste des CLIENTS ou des PROSPECTS. Contient les methodes pour charger le DataGridView,
    /// et les differents boutons (ajouter, mettre a jour, supprimer et retour) 
    /// </summary>
    /// <remarks>
    /// <para>Auteur : Franck Jakubowski</para>
    /// <para>Version : 0.1</para>
    /// <para>Date de creation : 07/01/2019</para>
    /// </remarks>
    public partial class EcranGestion : Form
    {
        //  Declaration d une liste pour y stocker les CLIENTS/PROSPECTS
        public List<Client> laListClient ;


        //---------------------------------------------------
        //  Declaration des attributs de la class Client
        //---------------------------------------------------
        private bool gestClient;            //  Booleen pour le choix de gestion true=CLIENT, false=PROSPECT 
        private string laTable;             //  Variable pour recuperer le nom de la table pour les requetes SQL
        private string rechercheRaison;     //  Variable stocker le string de recherche de la raison sociale
        private bool btnClicked = false;    //  Booleen pour savoir si on veut afficher les prospects a relancer ou tous les prospects

        //---------------------------------------------------
        //  Declaration des proprietes de la class Client
        //---------------------------------------------------

        #region "Proprietes"

        public bool acc_gestClient
        { get { return this.gestClient; } set { this.gestClient = value; } }

        public string acc_laTable
        { get { return this.laTable; } set { this.laTable = value; } }

        public string Acc_rechercheRaison
        { get { return this.rechercheRaison; } set { this.rechercheRaison = value; } }

        public bool acc_btnClicked
        { get { return this.btnClicked; } set { this.btnClicked = value; } }

        #endregion

        //-----------------------------------------------------
        //  Constructeurs de la class EcranGestion
        //-----------------------------------------------------

        /// <summary>
        /// Initialisation de tous les composants et Instanciation de la class GestionClient
        /// permet de savoir si on travaille sur la table CLIENT ou PROSPECT
        /// </summary>
        /// <param name="choix">booleen pour savoir si on travaille sur un CLIENT (=true) ou un PROSPECT (=false)</param>        
        public EcranGestion(bool choix)
        {
            InitializeComponent();
            //  On initialise les variables d instance
            this.gestClient = choix;
            this.laTable = (choix) ? "CLIENT" : "PROSPECT";
        }

        //---------------------------------------------------------------
        //  Traitement sur le DataGridView et la TextBox de recherche
        //---------------------------------------------------------------

        #region "Traitements sur le DatagridView"

        /// <summary>
        /// Modification dynamique du DataGridView en fonction des lettres saisies dans la TextBox de recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_RechClient_TextChanged(object sender, EventArgs e)
        {
            //  On affecte la saisie de la TextBox
            this.rechercheRaison = tbx_RechClient.Text;
            //  On efface les lignes du DataGridView
            dtgGestClient.Rows.Clear();
            //  On appelle la methode pour changer le DataGidView en passant en parametre une chaine vide
            dtg_Load();
        }

        /// <summary>
        /// Fonction pour charger les donnees du DataGridView en fonction du choix de gestion CLIENT/PROSPECT et de la
        /// saisie dans la TextBox de la raison sociale grace a la methode TextChanged() associee
        /// </summary>
        /// <param name="leWhere">Permet de modifier le DataGridView en fonction de la saisie dans la TextBox de recherche</param>
        private void dtg_Load ()
        {
            try
            {
                #region"--CLIENT--"

                //  Si gestClient=true (donc CLIENT)
                if (gestClient)
                {
                    //  On instancie une nouvelle List de CLIENT
                    laListClient = new List<Client>();
                    //  On utilise la methode AfficheListClient(string, string) de la Class CLIENT
                    laListClient = Client.AfficheListClient(this.laTable);
                    //  Pour chaque objet CLIENT dans la List
                    foreach (Client unClient in laListClient)
                    {
                        //  Si la raison social d un client commence par la sasie utilisateur
                        if (unClient.RaisonSocialeMatch(this.rechercheRaison))
                        {
                            //  On affiche pour chaque ligne du DataGridView la valeur des ses attributs
                            dtgGestClient.Rows.Add(unClient.acc_idClient,
                                                    unClient.acc_rsClient,
                                                    unClient.acc_typeClient,
                                                    unClient.acc_domaineClient,
                                                    unClient.acc_adrClient,
                                                    unClient.acc_telClient,
                                                    unClient.acc_caClient,
                                                    unClient.acc_commClient,
                                                    unClient.acc_nbrEmp
                                                    );
                        }                        
                    }
                }

                #endregion

                #region"--PROSPECT--"

                //  Sinon PROSPECT
                else
                {
                    //  On instancie une nouvelle List de PROSPECT 
                    laListClient = new List<Client>();
                    //  On utilise la methode AfficheListClient(string, string) de la Class PROSPECT
                    laListClient = Prospect.AfficheListClient(this.laTable);
                    //  Pour chaque objet PROSPECT dans la List
                    foreach (Prospect unClient in laListClient)
                    {
                        if (unClient.RaisonSocialeMatch(this.rechercheRaison))
                        {
                            //  Si on a cliquer sur le bouton pour afficher les prospects a relancer
                            if (btnClicked)
                            {
                                //  Appelle de la methode Relancer(Datetime, bool) qui verifie si un prospect est a relancer
                                if (unClient.Relancer())
                                {
                                    //  On recupere pour chaque ligne du DataGridView la valeur du prospect a relancer
                                    dtgGestClient.Rows.Add(unClient.acc_idClient,
                                                            unClient.acc_rsClient,
                                                            unClient.acc_typeClient,
                                                            unClient.acc_domaineClient,
                                                            unClient.acc_adrClient,
                                                            unClient.acc_telClient,
                                                            unClient.acc_caClient,
                                                            unClient.acc_commClient,
                                                            unClient.acc_nbrEmp,
                                                            unClient.acc_dateProspect.ToString("dd/MM/yyyy"),
                                                            unClient.acc_interetProspec
                                                            );
                                }
                            }
                            //  Sinon on recupere toute la liste des prospects
                            else
                            {
                                //  On a affiche pour chaque ligne du DataGridView la valeur des ses attributs
                                dtgGestClient.Rows.Add(unClient.acc_idClient,
                                                        unClient.acc_rsClient,
                                                        unClient.acc_typeClient,
                                                        unClient.acc_domaineClient,
                                                        unClient.acc_adrClient,
                                                        unClient.acc_telClient,
                                                        unClient.acc_caClient,
                                                        unClient.acc_commClient,
                                                        unClient.acc_nbrEmp,
                                                        unClient.acc_dateProspect.ToString("dd/MM/yyyy"),
                                                        unClient.acc_interetProspec
                                                        );
                            }
                        }                            
                    }
                }

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement du DataGridView ! " + ex.Message);
            }                       
        }
        
        #endregion

        //---------------------------------------------------------------
        //  Traitement au chargement de la fenetre
        //---------------------------------------------------------------

        /// <summary>
        /// Methode pour cacher les boutons Modifier et supprimer si le DataGridView ne contient aucune donnee
        /// On a acces qu a la creation
        /// </summary>
        private void CacherBouton()
        {
            //  S il n y a pas de donnees dans le DataGridView, donc que les en-tetes
            if (dtgGestClient.Rows.Count == 1)
            {
                //  On cache les boutons Modifier et supprimer
                this.btn_Modif.Visible = false;
                this.btn_Supp.Visible = false;
            }
            else
            {
                //  On affiche les boutons Modifier et supprimer
                this.btn_Modif.Visible = true;
                this.btn_Supp.Visible = true;
            }
        }

        
        private void GestionClient_Load(object sender, EventArgs e)
        {
            //  Initialisation a vide du message d erreur de la fenetre et de la TextBox de recherche
            lblMessEcranGestion.Text = "";
            tbx_RechClient.Text = "";
            Bt_Relance.Text = "Afficher Prospect à relancer";
            //  Configure la taille des colonnes automatiquement
            dtgGestClient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;            
            //  Si on a choisi la gestion de CLIENT (gestClient=true)
            if (gestClient)
            {
                //  On adapte le titre de la fenetre et la couleur a la gestion des CLIENT
                lblGestClient.Text = "Gestion des client";
                this.BackColor = Color.DarkSeaGreen;
                this.Bt_Relance.Visible = false;
                //  On creer les en-tete des colonnes du DataGridView CLIENT
                dtgGestClient.ColumnCount = 9;
                dtgGestClient.Columns[0].Name = "IDCLIENT";
                dtgGestClient.Columns[1].Name = "RSCLIENT";
                dtgGestClient.Columns[2].Name = "TYPECLIENT";
                dtgGestClient.Columns[3].Name = "DOMAINECLIENT";
                dtgGestClient.Columns[4].Name = "ADRCLIENT";
                dtgGestClient.Columns[5].Name = "TELCLIENT";
                dtgGestClient.Columns[6].Name = "CACLIENT";
                dtgGestClient.Columns[7].Name = "COMMENTAIRESCLIENT";
                dtgGestClient.Columns[8].Name = "NBREMPCLIENT";
            }
            //  Sinon on a choisi la gestion de PROSPECT
            else
            {
                //  On adapte le titre de la fenetre et la couleur a la gestion des PROSPECTS
                lblGestClient.Text = "Gestion des prospects";
                this.BackColor = Color.DarkCyan;
                this.Bt_Relance.Visible = true;
                //  On creer les en-tete des colonnes du DataGridView PROSPECT
                dtgGestClient.ColumnCount = 11;
                dtgGestClient.Columns[0].Name = "IDPROSPECT";
                dtgGestClient.Columns[1].Name = "RSPROSPECT";
                dtgGestClient.Columns[2].Name = "TYPEPROSPECT";
                dtgGestClient.Columns[3].Name = "DOMAINEPROSPECT";
                dtgGestClient.Columns[4].Name = "ADRPROSPECT";
                dtgGestClient.Columns[5].Name = "TELPROSPECT";
                dtgGestClient.Columns[6].Name = "CAPROSPECT";
                dtgGestClient.Columns[7].Name = "COMMENTAIRESPROSPECT";
                dtgGestClient.Columns[8].Name = "NBREMPPROSPECT";
                dtgGestClient.Columns[9].Name = "DATEPROSPECT";
                dtgGestClient.Columns[10].Name = "INTERETPROSPECT";
                //  On initialise la variable de classe contenant le dernier numéro de prospect crée
                Prospect.DernierIdCreer();
                //MessageBox.Show("Test init compteur dernier Prospect : " + Prospect.dernierIdentifiant.ToString());
            }
            //  Chargement du DataGridView au chargement de la fenetre  
            dtgGestClient.Rows.Clear();
            dtg_Load();
            // Appelle de la methode pour cacher les bouton Modifier et supprimer
            CacherBouton();
        }

        //----------------------------------------------
        //  Methodes pour les differents boutons
        //----------------------------------------------

        #region "Traitement pour les boutons de creation, modification, relancer, suppression et quitter"

        /// <summary>
        /// Methode associee au bouton de creation du CLIENT ou du PROSPECT en utilisant le constructeur de creation,
        /// Formulaire(bool, string, string)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ajouter_Click(object sender, EventArgs e)
        {
            //  Declaration et instanciation d un nouvel objet Formulaire avec les informations de gestion, type de gestion et le nom de la table
            Formulaire crea_Formulaire = new Formulaire(gestClient, "CREA", this.laTable);
            //  Affiche le formulaire
            crea_Formulaire.ShowDialog();

            //  Vidage et recharge du DatagridView 
            dtgGestClient.Rows.Clear();
            dtg_Load();
            CacherBouton();
        }

        /// <summary>
        /// Methode associee au bouton de modification du CLIENT ou du PROSPECT en utilisant le constructeur de mise a jour,
        /// Formulaire(bool, string, string, Object)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modif_Click(object sender, EventArgs e)
        {
            //  On verifie que l utilisateur a selectionne une ligne pour la modification
            if (dtgGestClient.SelectedRows.Count != 1)
            { MessageBox.Show("Veuillez selectionner une ligne et une seule !");return; }
            //  On recupere le numero de la ligne
            int i = dtgGestClient.CurrentCell.RowIndex;
            //  Declaration et instanciation d un nouvel objet Formulaire avec les informations de gestion, type de gestion , le nom de la table 
            //  et l Objet CLIENT/PROSPECT selectionne dans le DataGridView
            Formulaire maj_Formulaire = new Formulaire(gestClient, "MAJ", this.laTable, this.laListClient[i]);
            //  Affiche le formulaire
            maj_Formulaire.ShowDialog();
            //  Vidage et recharge du DatagridView 
            dtgGestClient.Rows.Clear();
            dtg_Load();           
        }

        /// <summary>
        /// Methode associee au bouton pour afficher les Prospects interesses dont la prospection date de plus de 30 jours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Relance_Click(object sender, EventArgs e)
        {
            if (btnClicked)
            {
                Bt_Relance.Text = "Afficher les Prospects à relancer";
                Bt_Relance.BackColor = Color.LightBlue;
                btnClicked = false;
                dtgGestClient.Rows.Clear();
                dtg_Load();
            }
            else
            {
                Bt_Relance.Text = "Afficher la liste des Prospects";
                Bt_Relance.BackColor = Color.CadetBlue;
                btnClicked = true;
                dtgGestClient.Rows.Clear();
                dtg_Load();
                tbx_RechClient.Text = "";
            }
        }

        /// <summary>
        /// Methode associer au bouton de suppression du CLIENT ou du PROSPRECT en utilisant la methode d instance,
        /// SupClient(string, int)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Supp_Click(object sender, EventArgs e)
        {
            //  On verifie que l utilisateur a selectionne une ligne pour la suppression
            if (dtgGestClient.SelectedRows.Count != 1)
            { MessageBox.Show("Veuillez selectionner une ligne et une seule !"); return; }
            //  On recupere le numero de la ligne
            int i = dtgGestClient.CurrentCell.RowIndex;
            //  On appelle la methode d instance SupClient() associee au CLIENT/PROSPECT selectionne
            this.laListClient[i].SupClient(this.laTable, this.laListClient[i].acc_idClient);
            //  Vidage et recharge du DatagridView 
            dtgGestClient.Rows.Clear();
            dtg_Load();
        }

        /// <summary>
        /// Methode pour fermer la fenetre en cours
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Retour_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion       
    }
}

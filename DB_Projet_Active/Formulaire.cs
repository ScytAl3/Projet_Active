using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace DB_Projet_Active
{
    /// <summary>
    /// La Class Formulaire qui affiche, dans des TextBox, DateTimePicker et CheckBox, les informations concernant
    /// la creation ou la mise a jour des CLIENTS ou des PROSPECTS. Contient les methodes pour controler la saisie,
    /// et les differents boutons (valider et retour) 
    /// </summary>
    /// <remarks>
    /// <para>Auteur : Franck Jakubowski</para>
    /// <para>Version : 0.1</para>
    /// <para>Date de creation : 07/01/2019</para>
    /// </remarks>
    public partial class Formulaire : Form
    {

        //---------------------------------------------------
        //  Declaration des attributs de la class Formulaire
        //---------------------------------------------------
        private bool gestClient;        //  Booleen pour le choix de gestion true=CLIENT, false=PROSPECT
        private string typeGestion;     //  Variable pour connaitre le type de gestion creation="CREA", mise a jour="MAJ"
        private int idClient;           //  Entier pour recuperer le numero d'identification d'un CLIENT/PROSPECTS
        private string laTable;         //  Variable pour recuperer le nom de la table pour les requetes SQL
        private Client leClient;        //  Declaration d un objet Client
        private Prospect leProspect;    //  Declaration d un objet Prospect

        //----------------------------------------------------
        //  Declaration des proprietes de la class Formulaire
        //----------------------------------------------------

        #region "Proprietes"
        public bool acc_gestClient
        { get { return this.gestClient; } set { this.gestClient = value; } }

        public string acc_typeGestion
        { get { return this.typeGestion; } set { this.typeGestion = value; } }

        public int acc_idClient
        { get { return this.idClient; } set { this.idClient = value; } }

        public string acc_laTable
        { get { return this.laTable; } set { this.laTable = value; } }

        public Client Acc_leClient
        { get; set; }

        public Prospect Acc_leProspect
        { get; set; }
        #endregion

        //-----------------------------------------------------
        //  Declaration des constructeurs de la class Client
        //-----------------------------------------------------

        #region "Les constructeurs"

        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public Formulaire()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructeur avec 3 parametres pour la creation d un CLIENT/PROSPECT
        /// </summary>
        /// <param name="choix">true=CLIENT, false=PROSPECT</param>
        /// <param name="typGes">"CREA"</param>
        /// <param name="table">"CLIENT" ou "PROSPECT"</param>
        public Formulaire(bool choix, string typGes, string table)
        {
            InitializeComponent();
            //  Initialisation des variables d instance
            this.gestClient = choix;
            this.typeGestion = typGes;            
            this.laTable = table;
            //  Si gestClient=true, on travaille sur un CLIENT
            if (gestClient)
            {
                //  On instancie un Client
                leClient = new Client();
            }
            //  Sinon on travaille sur un PROSPECT
            else
            {
                //  On instancie un Prospect
                leProspect = new Prospect();
            }
        }

        /// <summary>
        /// Constructeur avec 4 parametres pour la mise a jour d un CLIENT/PROSPECT
        /// </summary>
        /// <param name="choix">true=CLIENT, false=PROSPECT</param>
        /// <param name="typGes">"MAJ"</param>
        /// <param name="table">"CLIENT" ou "PROSPECT"</param>
        /// <param name="maj_client">Object selectionne dans le DataGridView</param>
        public Formulaire(bool choix, string typGes, string table, Client maj_client)
        {
            InitializeComponent();
            //  Initialisation des variables d instance
            this.gestClient = choix;
            this.typeGestion = typGes;
            this.laTable = table;
            //  Si gestClient=true, on travaille sur un CLIENT
            if (gestClient)
            {
                //  On instancie un Client
                leClient = new Client();
                //  On initialise les attributs du Client instancie leClient avec les attributs du Client selectionne
                //  dans le DataGridView
                this.leClient = maj_client;
            }
            //  Sinon on travaille sur un PROSPECT
            else
            {
                //  On instancie un Prospect
                leProspect = new Prospect();
                //  Si l objet Client selectionne dans le DataGridView est un objet Prospect
                //  On initialise leProspect avec les attributs du Prospect selectionne dans le DataGridView
                if (maj_client is Prospect)
                { this.leProspect = (Prospect)maj_client; }
                
            }            
        }

        #endregion

        //-------------------------------------------------------------------------------
        //  Methodes pour les differents chargements fenetre et informations formulaire
        //-------------------------------------------------------------------------------

        #region "Les chargements"

        /// <summary>
        /// Methode pour recuperer et afficher les informations du CLIENT/PROSPECT a mettre a jour grace au 
        /// constructeur de mise a jour Formulaire(bool, string, string, Objet)
        /// </summary>
        private void Champ_A_Modifier()
        {
            try
            {
                // Si on a choisi un CLIENT a mettre a jour
                if (gestClient)
                {
                    //  On affiche dans les TestBox les valeurs (attributs du Client instancie leClient) recuperees
                    this.tbx_NumIden.Text = leClient.acc_idClient.ToString();
                    this.tbxRaisonSocial.Text = leClient.acc_rsClient;
                    this.cbx_TypSociete.Text = leClient.acc_typeClient;
                    this.tbx_DomActivity.Text = leClient.acc_domaineClient;
                    this.tbx_Adresse.Text = leClient.acc_adrClient;
                    this.tbx_Telephone.Text = leClient.acc_telClient;
                    this.tbx_CA_Societe.Text = leClient.acc_caClient.ToString();
                    this.rtbx_Commentaire.Text = leClient.acc_commClient;
                    this.tbx_NbEmploye.Text = leClient.acc_nbrEmp.ToString();
                }
                // Sinon on a choisi un PROSPECT a mettre a jour
                else
                {
                    //  On affiche dans les TextBox les valeurs (attributs du Prospect instancie leProspect) recuperees
                    this.tbx_NumIden.Text = leProspect.acc_idClient.ToString();
                    this.tbxRaisonSocial.Text = leProspect.acc_rsClient;
                    this.cbx_TypSociete.Text = leProspect.acc_typeClient;
                    this.tbx_DomActivity.Text = leProspect.acc_domaineClient;
                    this.tbx_Adresse.Text = leProspect.acc_adrClient;
                    this.tbx_Telephone.Text = leProspect.acc_telClient;
                    this.tbx_CA_Societe.Text = leProspect.acc_caClient.ToString();
                    this.rtbx_Commentaire.Text = leProspect.acc_commClient;
                    this.tbx_NbEmploye.Text = leProspect.acc_nbrEmp.ToString();
                    this.dtp_DateProsp.Value = leProspect.acc_dateProspect;
                    if (leProspect.acc_interetProspec)
                    {
                        this.chkbx_Oui.Checked = true;
                    }
                    else
                    {
                        this.chkbx_Non.Checked = true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                lblMessEcranFormulaire.Text = "Problème lors du chargement des données : " + ex.Message;
            }
        }

        /// <summary>
        /// Traitement pour modifier le titre en fonction des choix dans les fenetres
        /// precedentes, gestion Client/Prospect, creation ou modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Formulaire_Load(object sender, EventArgs e)
        {
            //  Affiche le type de gestion du CLIENT ou du PROSPECT 
            lblMessEcranFormulaire.Text = "Vous allez " + typeGestion + " un " + laTable;
            //  Initialisation de la combobox du choix de la raison sociale
            cbx_TypSociete.Items.Add("privé");
            cbx_TypSociete.Items.Add("public");
            // Affichage de la valeur "privé" par defaut
            cbx_TypSociete.SelectedIndex = 0;
            // Formatage et affichage de la date de prospection            
            dtp_DateProsp.Format = DateTimePickerFormat.Custom;
            dtp_DateProsp.CustomFormat = "dd/MM/yyyy";

            //===================================//
            //  Si on travaille sur un PROSPECT
            //===================================//

            #region "--PROSPECT--"

            if (!gestClient)
            {
                //  On change le titre de la fenetre et la couleur du fond
                lbl_TitreFenetre.Text = "Gestion des prospects";
                this.BackColor = Color.DarkCyan;
                //  On affiche la BroupBox qui contient les attributs supplementaires, date et interet
                this.gbx_InfoProspect.Visible = true;

                //  Si on on veut creer un PROSPECT
                if (typeGestion == "CREA")
                {
                    //  On instancie un Objet Prospect
                    Prospect leProspect = new Prospect();
                    //  On creer un numero d identification pour le Prospect
                    leProspect.acc_idClient = Prospect.Crea_NumIdProspect();
                    //  On affiche le numero d identification creer
                    tbx_NumIden.Text = leProspect.acc_idClient.ToString();
                    //  On limite le choix de l'annee du DateTimePicker a l annee en cours
                    dtp_DateProsp.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
                    dtp_DateProsp.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
                }
                //  Si on veut mettre a jour un PROSPECT
                if (typeGestion == "MAJ")
                {
                    //  On limite le choix de l'annee du DateTimePicker a l annee de creation du prospect
                    dtp_DateProsp.MinDate = new DateTime(leProspect.acc_dateProspect.Year, 1, 1);
                    dtp_DateProsp.MaxDate = new DateTime(leProspect.acc_dateProspect.Year, 12, 31);
                    //  On appelle la methode pour afficher les informations du PROSPECT
                    Champ_A_Modifier();
                }
            }

            #endregion

            //===================================//
            //  Si on travaille sur un CLIENT
            //===================================//

            #region "--CLIENT--"

            if (gestClient)
            {
                //  On change le titre de la fenetre et la couleur du fond 
                lbl_TitreFenetre.Text = "Gestion des clients";
                this.BackColor = Color.DarkSeaGreen;
                //  On cache la BroupBox qui contient les attributs supplementaires
                this.gbx_InfoProspect.Visible = false;

                //  Si on on veut creer un CLIENT
                if (typeGestion == "CREA")
                {
                    //  On cache le Label et la TextBox du numero d identification
                    lbl_NumIdent.Visible = false;
                    tbx_NumIden.Visible = false; 
                }
                //  Si on veut mettre a jour un CLIENT
                if (typeGestion == "MAJ")
                {
                    //  On appelle la methode pour afficher les informations du CLIENT
                    Champ_A_Modifier();
                }
            }

            #endregion
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////
        ///                                                                             ///
        ///          Traitements pour controler et valider la saisie utilisateur        ///
        ///                                                                             ///
        ///////////////////////////////////////////////////////////////////////////////////                                                                            

        #region "Controle de la saisie alphanumerique dans les TextBox"

        /// <summary>
        /// Controle de la saisie alphanumeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxRaisonSocial_TextChanged(object sender, EventArgs e)
        {
            if ((!System.Text.RegularExpressions.Regex.IsMatch(tbxRaisonSocial.Text, "^[0-9a-zA-Z ]")) && (tbxRaisonSocial.Text.Length > 0))
            {
                MessageBox.Show("Cette TextBox n'accepte que des caractères alphabétique !");
                tbxRaisonSocial.Text = String.Empty;
            }
        }

        private void tbx_DomActivity_TextChanged(object sender, EventArgs e)
        {
            if ((!System.Text.RegularExpressions.Regex.IsMatch(tbx_DomActivity.Text, "^[0-9a-zA-Z ]")) && (tbx_DomActivity.Text.Length > 0))
            {
                MessageBox.Show("Cette TextBox n'accepte que des caractères alphabétique !");
                tbx_DomActivity.Text = String.Empty;
            }
        }

        private void tbx_Adresse_TextChanged(object sender, EventArgs e)
        {
            if ((!System.Text.RegularExpressions.Regex.IsMatch(tbx_Adresse.Text, "^[0-9a-zA-Z ]")) && (tbx_Adresse.Text.Length > 0))
            {
                MessageBox.Show("Cette TextBox n'accepte que des caractères alphabétique !");
                tbx_Adresse.Text = String.Empty;
            }
        }

        private void rtbx_Commentaire_TextChanged(object sender, EventArgs e)
        {
            if ((!System.Text.RegularExpressions.Regex.IsMatch(rtbx_Commentaire.Text, "^[0-9a-zA-Z ]")) && (rtbx_Commentaire.Text.Length > 0))
            {
                MessageBox.Show("Cette TextBox n'accepte que des caractères alphabétique !");
                rtbx_Commentaire.Text = String.Empty;
            }
        }

        #endregion

        #region "Controle des saisies dans les TextBox a l aide d un errorProvider, controle de la date et des CheckBox"

        /// <summary>
        /// Traitement du controle de la saisie du numero de telephone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_Telephone_Validating(object sender, CancelEventArgs e)
        {
            //  On instancie un Regex qui n'autorise qu une saisie de 10 chiffres
            Regex rg_Tel = new Regex("^[0-9]{10}$");
            //  Si au moins 1 caractere
            if (tbx_Telephone.Text.Length != 0)
            {
                //  Si la saisie correspond au regex : 10 chiffre consecutifs
                if (rg_Tel.IsMatch(tbx_Telephone.Text))
                {
                    //  Si la saisie correspond a ce que l on attend il n y a pas d alerte
                    errProvidFormulaire.SetError(tbx_Telephone, "");
                }
                else
                {
                    //  Sinon on affiche une alerte avec un message sur l icone
                    errProvidFormulaire.SetError(tbx_Telephone, "Veuillez saisir un numéro de téléphone à 10 chiffre sans espace !");
                }
            }
            
        }

        /// <summary>
        /// Methode qui renvoie une booleen si la saisie du Chiffre d affaire est valide
        /// </summary>
        /// <returns></returns>
        private bool Valid_CA()
        {
            bool bStatus = false;
            // Si au moins 1 caractere
            if(tbx_CA_Societe.Text.Length != 0)
            {
                try
                {
                    //  On essaye de convertir la saisie en entier, si probleme de conversion
                    //  l erreur est recuperee par le catch
                    int montanCA = Int32.Parse(tbx_CA_Societe.Text);
                    //  Si on a un nombre le provider n affiche pas d alerte 
                    errProvidFormulaire.SetError(tbx_CA_Societe, "");
                    //  Si le nombre recupere est negatif
                    if (montanCA < 0)
                    {
                        //  On affiche une alerte avec un message sur l icone
                        errProvidFormulaire.SetError(tbx_CA_Societe, "Le Chiffre d'affaire ne peut être négatif !");
                        bStatus = false;
                    }
                    else
                    {
                        errProvidFormulaire.SetError(tbx_CA_Societe, "");
                        bStatus = true;
                    }
                }
                catch
                {
                    //  La saisie n etait pas numerique
                    errProvidFormulaire.SetError(tbx_CA_Societe, "Veillez saisir un nombre");
                    bStatus = false;
                }
            }
            else { errProvidFormulaire.SetError(tbx_CA_Societe, ""); }
            return bStatus;
        }

        /// <summary>
        /// Methode associee a la TextBox du chiffre d affaire qui appelle la fonction Valid_CA()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_CA_Societe_Validating(object sender, CancelEventArgs e)
        {
            Valid_CA();
        }

        /// <summary>
        /// Methode qui renvoie une booleen si la saisie du nombre d employe(s) est valide
        /// </summary>
        /// <returns></returns>
        private bool Valid_Employe()
        {
            bool bStatus = false;
            // Si au moins 1 caractere
            if (tbx_NbEmploye.Text.Length != 0)
            {
                try
                {
                    //  On essaye de convertir la saisie en entier, si probleme de conversion
                    //  l erreur est recuperee par le catch
                    int nbEmp = Int32.Parse(tbx_NbEmploye.Text);
                    //  Si on a un nombre le provider n affiche pas d alerte
                    errProvidFormulaire.SetError(tbx_NbEmploye, "");
                    //  Si le nombre recupere est negatif
                    if (nbEmp < 0)
                    {
                        //  On affiche une alerte avec un message sur l icone
                        errProvidFormulaire.SetError(tbx_NbEmploye, "Le nombre d'employé ne peut être négatif !");
                        bStatus = false;
                    }
                    else
                    {
                        errProvidFormulaire.SetError(tbx_NbEmploye, "");
                        bStatus = true;
                    }
                }
                catch
                {
                    //  La saisie n etait pas numerique
                    errProvidFormulaire.SetError(tbx_NbEmploye, "Veillez saisir un nombre");
                }
            }
            else { errProvidFormulaire.SetError(tbx_NbEmploye, ""); }
            return bStatus;
        }

        /// <summary>
        /// Methode associee a la TextBox du du nombre d employe(s) qui appelle la fonction Valid_Employe()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbx_NbEmploye_Validating(object sender, CancelEventArgs e)
        {
            Valid_Employe();
        }

        /// <summary>
        /// Traitement du controle de la saisie de la date de prospection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtp_DateProsp_Validating(object sender, CancelEventArgs e)
        {
            //  Si la date selectionnee est superieure a la date du jour
            if (dtp_DateProsp.Value > DateTime.Now)
            {
                //  On affiche une alerte avec un message sur l icone
                errProvidFormulaire.SetError(dtp_DateProsp, "La date de prospection ne doit pas être supérieure à la date du jour !");
            }
            else
            {
                //  Sinon le provider n affiche pas d alerte
                errProvidFormulaire.SetError(dtp_DateProsp, "");
            }
        }
       
        /// <summary>
        /// Controle quand on clique sur la CheckBox OUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkbx_Oui_Click(object sender, EventArgs e)
        {
            //  Si NON etait coche on le decoche
            if (chkbx_Non.Checked)
            {
                chkbx_Non.Checked = false;
            }
        }

        /// <summary>
        /// Controle quand on clique sur la CheckBox NON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkbx_Non_Click(object sender, EventArgs e)
        {
            //  Si OUI etait coche on le decoche
            if (chkbx_Oui.Checked)
            {
                chkbx_Oui.Checked = false;
            }
        }

        /// <summary>
        /// Methode qui renvoie TRUE lorsque la CheckBox OUI est cochee
        /// </summary>
        /// <returns></returns>
        private bool Choix_Interet()
        {
            bool bChoix = (chkbx_Oui.Checked) ? true : false;
            return bChoix;
        }

        #endregion

        //===================================================================================

        #region "Controles de validation des saisies"

        /// <summary>
        /// Methode pour verifier la coherence entre le chiffre d affaire et le nombre d employe(s)
        /// </summary>
        /// <returns></returns>
        private bool CA_Erreur()
        {
            bool bStatus = false;
            //  On recupere la valeur des booleens des controles de saisie : chiffre d affaire, nombre
            //  d employe(s)
            bool bValid_CA = Valid_CA();
            bool bValid_Employe = Valid_Employe();
            //  Si le Chiffre d affaire et le nombre d employe(s) sont valide on peut verifier la coherence CA/Employe(s)
            if (bValid_CA && bValid_Employe)
            {
                if ((int.Parse(tbx_CA_Societe.Text) / int.Parse(tbx_NbEmploye.Text)) > 1000000)
                {
                    MessageBox.Show("Incohérence chiffre d'affaire / nombre d'employé(s)");
                    bStatus = false;
                }
                else
                {
                    bStatus = true;
                }
            }            
            return bStatus;
        }

        /// <summary>
        /// Methode pour verifier qu une CheckBox est cochee, l event Click ne permet qu un CheckBox a la fois
        /// </summary>
        /// <returns></returns>
        private bool Interesser()
        {
            bool bStatus;
            if ((chkbx_Oui.Checked) || (chkbx_Non.Checked))
            {
                bStatus = true;
            }
            else
            {
                bStatus = false;
            }
            return bStatus;
        }

        /// <summary>
        /// Methode pour controler la saisie utilisateur
        /// </summary>
        /// <returns></returns>
        private bool ValiderSaisie()
        {
            //  On initialise la validation a false
            bool valid = false;
            try
            {
                //  Si on gere un CLIENT
                if (gestClient)
                {
                    //  On utilise les proprietes de la class pour verifier la coherence des saisies
                    //  Si c est une mise a jour
                    if (typeGestion == "MAJ")
                    {
                        leClient.acc_idClient = int.Parse(tbx_NumIden.Text);
                    }                    
                    leClient.acc_rsClient = (tbxRaisonSocial.Text.Length > 0) ? tbxRaisonSocial.Text.ToString() : throw new Exception("Vous n'avez pas saisi la raison sociale !");
                    leClient.acc_typeClient = cbx_TypSociete.Text;
                    leClient.acc_domaineClient = (tbx_DomActivity.Text.Length > 0) ? tbx_DomActivity.Text.ToString() : throw new Exception("Vous n'avez pas saisi le domaine !");
                    leClient.acc_adrClient = (tbx_Adresse.Text.Length > 0) ? tbx_Adresse.Text.ToString() : throw new Exception("Vous n'avez pas saisi l'adresse !");
                    leClient.acc_telClient = (tbx_Telephone.Text.Length > 0) ? tbx_Telephone.Text.ToString() : throw new Exception("Vous n'avez pas saisi le numéro de téléphone !");
                    //  On utlise la methode de validation du chiffre d affaire pour affecter la valeur valide saisi au CLIENT cree
                    leClient.acc_caClient = Valid_CA() ? int.Parse(tbx_CA_Societe.Text) : throw new Exception("Saisissez un chiffre d'affaire !"); 
                    leClient.acc_commClient = (rtbx_Commentaire.Text.Length > 0) ? rtbx_Commentaire.Text.ToString() : throw new Exception("Vous n'avez pas saisi de commentaire !");
                    //  On utlise la methode de validation du nombre d employe(s)
                    leClient.acc_nbrEmp = Valid_Employe() ? int.Parse(tbx_NbEmploye.Text) : throw new Exception("Saisissez un nombre d'employé(s) !");
                    //  Si toute les saisies sont correctes valid passe a true
                    valid = true;
                }
                else
                {
                    //  On utilise les proprietes de la class pour verifier la coherence des saisies
                    leProspect.acc_idClient = int.Parse(tbx_NumIden.Text);
                    leProspect.acc_rsClient = (tbxRaisonSocial.Text.Length > 0) ? tbxRaisonSocial.Text.ToString(): throw new Exception("Vous n'avez pas choisi la raison sociale !");
                    leProspect.acc_typeClient = cbx_TypSociete.Text;
                    leProspect.acc_domaineClient = (tbx_DomActivity.Text.Length > 0) ? tbx_DomActivity.Text.ToString() : throw new Exception("Vous n'avez pas saisi le domaine !");
                    leProspect.acc_adrClient = (tbx_Adresse.Text.Length > 0) ? tbx_Adresse.Text.ToString() : throw new Exception("Vous n'avez pas saisi l'adresse !");
                    leProspect.acc_telClient = (tbx_Telephone.Text.Length > 0) ? tbx_Telephone.Text.ToString() : throw new Exception("Vous n'avez pas saisi le numéro de téléphone !");
                    //  On utlise la methode de validation du chiffre d affaire pour affecter la valeur valide saisi au PROSPECT cree
                    leProspect.acc_caClient = Valid_CA() ? int.Parse(tbx_CA_Societe.Text) : throw new Exception("Saisissez un chiffre d'affaire !");
                    leProspect.acc_commClient = (rtbx_Commentaire.Text.Length > 0) ? rtbx_Commentaire.Text.ToString() : throw new Exception("Vous n'avez pas saisi de commentaire !");
                    //  On utlise la methode de validation du nombre d employe(s)
                    leProspect.acc_nbrEmp = Valid_Employe() ? int.Parse(tbx_NbEmploye.Text) : throw new Exception("Saisissez un nombre d'employé(s) !");
                    leProspect.acc_dateProspect = (dtp_DateProsp.Value < DateTime.Now) ? dtp_DateProsp.Value : throw new Exception("La date est supérieure à la date du jour !"); ;
                    leProspect.acc_interetProspec = Interesser() ? Choix_Interet() : throw new Exception("Veuillez cocher si le prospect est intéressé !");
                    //  Si toute les saisies sont correctes valid passe a true
                    valid = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                valid = false;
            }
            return valid;
        }

        #endregion

        //===================================================================================

        ///////////////////////////////////////////////////////////////////////////////////
        ///                                                                             ///
        ///          Traitements pour valider la creation ou la mise a jour d un        ///
        ///                        formulaire CLIENT ou PROSPECT                        ///
        ///                                                                             ///
        ///////////////////////////////////////////////////////////////////////////////////  

        #region"Traitement pour les boutons valider et retour"

        /// <summary>
        /// Methode associee au bouton valider le formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ValidFormulaire_Click(object sender, EventArgs e)
        {
            //  si pas d'erreur avec les TextBox ni avec le controle CA/Employe(s)
            if (ValiderSaisie() && CA_Erreur())
            {
                //===================================//
                //  Si on travaille sur un CLIENT
                //===================================//

                #region"--CLIENT--"

                if (gestClient)
                {
                    //  Si on on veut creer un CLIENT
                    if (typeGestion == "CREA")
                    {
                        //  Appelle de la methode d instance de creation d un client
                        leClient.CreaClient(this.laTable);
                        this.Close();
                    }
                    //  Si on veut mettre a jour un CLIENT
                    if (typeGestion == "MAJ")
                    {
                        //  Appelle de la methode d instance pour la modification d un client
                        leClient.Mise_A_Jour(this.laTable);
                        this.Close();
                    }
                }

                #endregion

                //===================================//
                //  Si on travaille sur un PROSPECT
                //===================================//

                #region"---PROSPECT---"

                if (!gestClient)
                {
                    //  Si on on veut creer un PROSPECT
                    if (typeGestion == "CREA")
                    {
                        //  Appelle de la methode d instance de creation d un PROSPECT
                        leProspect.CreaClient(this.laTable);
                        //  Incrementation de la variable de class Compteur
                        Prospect.IncrementerCompeur();
                        this.Close();
                    }
                    //  Si on veut mettre a jour un CLIENT
                    if (typeGestion == "MAJ")
                    {
                        //  Appelle de la methode d instance pour la modification d un PROSPECT
                        leProspect.Mise_A_Jour(this.laTable);
                        this.Close();
                    }
                }

                #endregion
            }
            //  On informe l utilisateur s il y a eu un probleme lors de la validation
            else { lblMessEcranFormulaire.Text = "Erreur lors de la validation !";  }
        }       

        /// <summary>
        /// Methode associee au bouton fermer la fenetre en cours
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

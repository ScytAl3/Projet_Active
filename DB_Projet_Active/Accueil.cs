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
    /// La Class Accueil qui est l entree de l application et contient les methodes pour choisir
    /// si l on veut travailler sur les CLIENTS ou les PROSPECTS
    /// </summary>
    /// <remarks>
    /// <para>Auteur : Franck Jakubowski</para>
    /// <para>Version : 0.1</para>
    /// <para>Date de creation : 07/01/2019</para>
    /// </remarks>
    public partial class Accueil : Form
    {   
        /// <summary>
        /// Initialisation de tous les composants de la Class Accueil
        /// </summary>
        public Accueil()
        {
            InitializeComponent();
        }
       
        /// <summary>
        /// Traitement a effectuer au chargement de la forme dont un test
        /// sur la connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accueil_Load(object sender, EventArgs e)
        {
            //  Initialisation a vide du label des messages de la fenetre Accueil
            lblMessEcranChoixGest.Text = "";
            try
            {
                //  Test pour verifier que les informations pour la connexion sont les bons
                FonctionSQL.TestConnection();
                MessageBox.Show("Connexion établie !");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème lors de la connexion ! " + ex.Message);
            }
        }

        //----------------------------------------------
        //  Methodes pour les differents boutons
        //----------------------------------------------

        #region "Methodes associees aux differents boutons dont le choix de gestion CLIENT/PROSPECT"

        /// <summary>
        /// Methode associee au bouton CLIENT : instancie la Class EcranGestion
        /// </summary>
        /// <remarks>
        /// Utilisation du constructeur par defaut de EcranGestion(bool) pour un CLIENT le booleen = true
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Gest_Client_Click(object sender, EventArgs e)
        {            
            EcranGestion E_Gestion = new EcranGestion(true);
            E_Gestion.ShowDialog();
        }

        /// <summary>
        /// Methode associee au bouton PROSPECT : instancie la Class EcranGestion
        /// </summary>
        /// <remarks>
        /// Utilisation du constructeur par defaut de EcranGestion(bool) pour un PROSPECT le booleen = false
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Gest_Prospect_Click(object sender, EventArgs e)
        {
            EcranGestion E_Gestion = new EcranGestion(false);
            E_Gestion.ShowDialog();
        }

        /// <summary>
        /// Methode pour quitter l application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bt_Quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}

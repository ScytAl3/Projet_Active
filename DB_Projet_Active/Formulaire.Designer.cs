namespace DB_Projet_Active
{
    partial class Formulaire
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblMessEcranFormulaire = new System.Windows.Forms.Label();
            this.lbl_NumIdent = new System.Windows.Forms.Label();
            this.lbl_RaisonSocial = new System.Windows.Forms.Label();
            this.lbl_TypSociete = new System.Windows.Forms.Label();
            this.lbl_DomActivity = new System.Windows.Forms.Label();
            this.tbx_NumIden = new System.Windows.Forms.TextBox();
            this.tbx_DomActivity = new System.Windows.Forms.TextBox();
            this.lbl_Adresse = new System.Windows.Forms.Label();
            this.tbx_Adresse = new System.Windows.Forms.TextBox();
            this.lbl_Telephone = new System.Windows.Forms.Label();
            this.tbx_Telephone = new System.Windows.Forms.TextBox();
            this.lbl_CA_Societe = new System.Windows.Forms.Label();
            this.tbx_CA_Societe = new System.Windows.Forms.TextBox();
            this.lbl_NbEmploye = new System.Windows.Forms.Label();
            this.tbx_NbEmploye = new System.Windows.Forms.TextBox();
            this.lbl_DateProspec = new System.Windows.Forms.Label();
            this.lbl_Interesse = new System.Windows.Forms.Label();
            this.chkbx_Oui = new System.Windows.Forms.CheckBox();
            this.chkbx_Non = new System.Windows.Forms.CheckBox();
            this.btn_ValidFormulaire = new System.Windows.Forms.Button();
            this.btn_Retour = new System.Windows.Forms.Button();
            this.lbl_TitreFenetre = new System.Windows.Forms.Label();
            this.gbx_InfoProspect = new System.Windows.Forms.GroupBox();
            this.dtp_DateProsp = new System.Windows.Forms.DateTimePicker();
            this.lbl_Commentaires = new System.Windows.Forms.Label();
            this.rtbx_Commentaire = new System.Windows.Forms.RichTextBox();
            this.errProvidFormulaire = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbxRaisonSocial = new System.Windows.Forms.TextBox();
            this.cbx_TypSociete = new System.Windows.Forms.ComboBox();
            this.gbx_InfoProspect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvidFormulaire)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessEcranFormulaire
            // 
            this.lblMessEcranFormulaire.AutoSize = true;
            this.lblMessEcranFormulaire.Location = new System.Drawing.Point(12, 555);
            this.lblMessEcranFormulaire.Name = "lblMessEcranFormulaire";
            this.lblMessEcranFormulaire.Size = new System.Drawing.Size(56, 13);
            this.lblMessEcranFormulaire.TabIndex = 0;
            this.lblMessEcranFormulaire.Text = "Message !";
            // 
            // lbl_NumIdent
            // 
            this.lbl_NumIdent.AutoSize = true;
            this.lbl_NumIdent.Location = new System.Drawing.Point(83, 74);
            this.lbl_NumIdent.Name = "lbl_NumIdent";
            this.lbl_NumIdent.Size = new System.Drawing.Size(87, 13);
            this.lbl_NumIdent.TabIndex = 1;
            this.lbl_NumIdent.Text = "N° identification :";
            // 
            // lbl_RaisonSocial
            // 
            this.lbl_RaisonSocial.AutoSize = true;
            this.lbl_RaisonSocial.Location = new System.Drawing.Point(83, 123);
            this.lbl_RaisonSocial.Name = "lbl_RaisonSocial";
            this.lbl_RaisonSocial.Size = new System.Drawing.Size(84, 13);
            this.lbl_RaisonSocial.TabIndex = 2;
            this.lbl_RaisonSocial.Text = "Raison Sociale :";
            // 
            // lbl_TypSociete
            // 
            this.lbl_TypSociete.AutoSize = true;
            this.lbl_TypSociete.Location = new System.Drawing.Point(83, 165);
            this.lbl_TypSociete.Name = "lbl_TypSociete";
            this.lbl_TypSociete.Size = new System.Drawing.Size(100, 13);
            this.lbl_TypSociete.TabIndex = 3;
            this.lbl_TypSociete.Text = "Type de la société :";
            // 
            // lbl_DomActivity
            // 
            this.lbl_DomActivity.AutoSize = true;
            this.lbl_DomActivity.Location = new System.Drawing.Point(83, 205);
            this.lbl_DomActivity.Name = "lbl_DomActivity";
            this.lbl_DomActivity.Size = new System.Drawing.Size(100, 13);
            this.lbl_DomActivity.TabIndex = 4;
            this.lbl_DomActivity.Text = "Domaine d\'activité :";
            // 
            // tbx_NumIden
            // 
            this.tbx_NumIden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_NumIden.Location = new System.Drawing.Point(209, 71);
            this.tbx_NumIden.Name = "tbx_NumIden";
            this.tbx_NumIden.ReadOnly = true;
            this.tbx_NumIden.Size = new System.Drawing.Size(100, 20);
            this.tbx_NumIden.TabIndex = 5;
            this.tbx_NumIden.TabStop = false;
            this.tbx_NumIden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbx_DomActivity
            // 
            this.tbx_DomActivity.Location = new System.Drawing.Point(209, 198);
            this.tbx_DomActivity.Name = "tbx_DomActivity";
            this.tbx_DomActivity.Size = new System.Drawing.Size(100, 20);
            this.tbx_DomActivity.TabIndex = 4;
            this.tbx_DomActivity.TextChanged += new System.EventHandler(this.tbx_DomActivity_TextChanged);
            // 
            // lbl_Adresse
            // 
            this.lbl_Adresse.AutoSize = true;
            this.lbl_Adresse.Location = new System.Drawing.Point(83, 250);
            this.lbl_Adresse.Name = "lbl_Adresse";
            this.lbl_Adresse.Size = new System.Drawing.Size(97, 13);
            this.lbl_Adresse.TabIndex = 9;
            this.lbl_Adresse.Text = "Adresse complète :";
            // 
            // tbx_Adresse
            // 
            this.tbx_Adresse.Location = new System.Drawing.Point(209, 247);
            this.tbx_Adresse.Name = "tbx_Adresse";
            this.tbx_Adresse.Size = new System.Drawing.Size(495, 20);
            this.tbx_Adresse.TabIndex = 5;
            this.tbx_Adresse.TextChanged += new System.EventHandler(this.tbx_Adresse_TextChanged);
            // 
            // lbl_Telephone
            // 
            this.lbl_Telephone.AutoSize = true;
            this.lbl_Telephone.Location = new System.Drawing.Point(83, 296);
            this.lbl_Telephone.Name = "lbl_Telephone";
            this.lbl_Telephone.Size = new System.Drawing.Size(64, 13);
            this.lbl_Telephone.TabIndex = 11;
            this.lbl_Telephone.Text = "Téléphone :";
            // 
            // tbx_Telephone
            // 
            this.tbx_Telephone.Location = new System.Drawing.Point(209, 289);
            this.tbx_Telephone.Name = "tbx_Telephone";
            this.tbx_Telephone.Size = new System.Drawing.Size(100, 20);
            this.tbx_Telephone.TabIndex = 6;
            this.tbx_Telephone.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_Telephone_Validating);
            // 
            // lbl_CA_Societe
            // 
            this.lbl_CA_Societe.AutoSize = true;
            this.lbl_CA_Societe.Location = new System.Drawing.Point(83, 343);
            this.lbl_CA_Societe.Name = "lbl_CA_Societe";
            this.lbl_CA_Societe.Size = new System.Drawing.Size(83, 13);
            this.lbl_CA_Societe.TabIndex = 13;
            this.lbl_CA_Societe.Text = "Chiffre d\'affaire :";
            // 
            // tbx_CA_Societe
            // 
            this.tbx_CA_Societe.Location = new System.Drawing.Point(209, 336);
            this.tbx_CA_Societe.Name = "tbx_CA_Societe";
            this.tbx_CA_Societe.Size = new System.Drawing.Size(100, 20);
            this.tbx_CA_Societe.TabIndex = 7;
            this.tbx_CA_Societe.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_CA_Societe_Validating);
            // 
            // lbl_NbEmploye
            // 
            this.lbl_NbEmploye.AutoSize = true;
            this.lbl_NbEmploye.Location = new System.Drawing.Point(83, 391);
            this.lbl_NbEmploye.Name = "lbl_NbEmploye";
            this.lbl_NbEmploye.Size = new System.Drawing.Size(111, 13);
            this.lbl_NbEmploye.TabIndex = 15;
            this.lbl_NbEmploye.Text = "Nombre d\'employé(s) :";
            // 
            // tbx_NbEmploye
            // 
            this.tbx_NbEmploye.Location = new System.Drawing.Point(209, 384);
            this.tbx_NbEmploye.Name = "tbx_NbEmploye";
            this.tbx_NbEmploye.Size = new System.Drawing.Size(69, 20);
            this.tbx_NbEmploye.TabIndex = 8;
            this.tbx_NbEmploye.Validating += new System.ComponentModel.CancelEventHandler(this.tbx_NbEmploye_Validating);
            // 
            // lbl_DateProspec
            // 
            this.lbl_DateProspec.AutoSize = true;
            this.lbl_DateProspec.Location = new System.Drawing.Point(4, 25);
            this.lbl_DateProspec.Name = "lbl_DateProspec";
            this.lbl_DateProspec.Size = new System.Drawing.Size(120, 13);
            this.lbl_DateProspec.TabIndex = 17;
            this.lbl_DateProspec.Text = "Date de la prospection :";
            // 
            // lbl_Interesse
            // 
            this.lbl_Interesse.AutoSize = true;
            this.lbl_Interesse.Location = new System.Drawing.Point(4, 59);
            this.lbl_Interesse.Name = "lbl_Interesse";
            this.lbl_Interesse.Size = new System.Drawing.Size(65, 13);
            this.lbl_Interesse.TabIndex = 19;
            this.lbl_Interesse.Text = "Intéréssé ? :";
            // 
            // chkbx_Oui
            // 
            this.chkbx_Oui.AutoSize = true;
            this.chkbx_Oui.Location = new System.Drawing.Point(130, 55);
            this.chkbx_Oui.Name = "chkbx_Oui";
            this.chkbx_Oui.Size = new System.Drawing.Size(42, 17);
            this.chkbx_Oui.TabIndex = 10;
            this.chkbx_Oui.Text = "Oui";
            this.chkbx_Oui.UseVisualStyleBackColor = true;
            this.chkbx_Oui.Click += new System.EventHandler(this.chkbx_Oui_Click);
            // 
            // chkbx_Non
            // 
            this.chkbx_Non.AutoSize = true;
            this.chkbx_Non.Location = new System.Drawing.Point(184, 55);
            this.chkbx_Non.Name = "chkbx_Non";
            this.chkbx_Non.Size = new System.Drawing.Size(46, 17);
            this.chkbx_Non.TabIndex = 11;
            this.chkbx_Non.Text = "Non";
            this.chkbx_Non.UseVisualStyleBackColor = true;
            this.chkbx_Non.Click += new System.EventHandler(this.chkbx_Non_Click);
            // 
            // btn_ValidFormulaire
            // 
            this.btn_ValidFormulaire.BackColor = System.Drawing.Color.YellowGreen;
            this.btn_ValidFormulaire.Location = new System.Drawing.Point(494, 497);
            this.btn_ValidFormulaire.Name = "btn_ValidFormulaire";
            this.btn_ValidFormulaire.Size = new System.Drawing.Size(97, 39);
            this.btn_ValidFormulaire.TabIndex = 13;
            this.btn_ValidFormulaire.Text = "Valider";
            this.btn_ValidFormulaire.UseVisualStyleBackColor = false;
            this.btn_ValidFormulaire.Click += new System.EventHandler(this.btn_ValidFormulaire_Click);
            // 
            // btn_Retour
            // 
            this.btn_Retour.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Retour.Location = new System.Drawing.Point(713, 534);
            this.btn_Retour.Name = "btn_Retour";
            this.btn_Retour.Size = new System.Drawing.Size(75, 34);
            this.btn_Retour.TabIndex = 23;
            this.btn_Retour.Text = "<< retour";
            this.btn_Retour.UseVisualStyleBackColor = false;
            this.btn_Retour.Click += new System.EventHandler(this.btn_Retour_Click);
            // 
            // lbl_TitreFenetre
            // 
            this.lbl_TitreFenetre.AutoSize = true;
            this.lbl_TitreFenetre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TitreFenetre.Location = new System.Drawing.Point(314, 9);
            this.lbl_TitreFenetre.Name = "lbl_TitreFenetre";
            this.lbl_TitreFenetre.Size = new System.Drawing.Size(163, 25);
            this.lbl_TitreFenetre.TabIndex = 24;
            this.lbl_TitreFenetre.Text = "Titre de la fenêtre";
            // 
            // gbx_InfoProspect
            // 
            this.gbx_InfoProspect.Controls.Add(this.dtp_DateProsp);
            this.gbx_InfoProspect.Controls.Add(this.chkbx_Non);
            this.gbx_InfoProspect.Controls.Add(this.chkbx_Oui);
            this.gbx_InfoProspect.Controls.Add(this.lbl_Interesse);
            this.gbx_InfoProspect.Controls.Add(this.lbl_DateProspec);
            this.gbx_InfoProspect.Location = new System.Drawing.Point(79, 419);
            this.gbx_InfoProspect.Name = "gbx_InfoProspect";
            this.gbx_InfoProspect.Size = new System.Drawing.Size(398, 117);
            this.gbx_InfoProspect.TabIndex = 25;
            this.gbx_InfoProspect.TabStop = false;
            this.gbx_InfoProspect.Text = "Informations prospect";
            // 
            // dtp_DateProsp
            // 
            this.dtp_DateProsp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_DateProsp.Location = new System.Drawing.Point(130, 19);
            this.dtp_DateProsp.Name = "dtp_DateProsp";
            this.dtp_DateProsp.Size = new System.Drawing.Size(200, 20);
            this.dtp_DateProsp.TabIndex = 9;
            this.dtp_DateProsp.Validating += new System.ComponentModel.CancelEventHandler(this.dtp_DateProsp_Validating);
            // 
            // lbl_Commentaires
            // 
            this.lbl_Commentaires.AutoSize = true;
            this.lbl_Commentaires.Location = new System.Drawing.Point(423, 293);
            this.lbl_Commentaires.Name = "lbl_Commentaires";
            this.lbl_Commentaires.Size = new System.Drawing.Size(79, 13);
            this.lbl_Commentaires.TabIndex = 27;
            this.lbl_Commentaires.Text = "Commentaires :";
            // 
            // rtbx_Commentaire
            // 
            this.rtbx_Commentaire.Location = new System.Drawing.Point(494, 309);
            this.rtbx_Commentaire.Name = "rtbx_Commentaire";
            this.rtbx_Commentaire.Size = new System.Drawing.Size(242, 102);
            this.rtbx_Commentaire.TabIndex = 12;
            this.rtbx_Commentaire.Text = "";
            this.rtbx_Commentaire.TextChanged += new System.EventHandler(this.rtbx_Commentaire_TextChanged);
            // 
            // errProvidFormulaire
            // 
            this.errProvidFormulaire.ContainerControl = this;
            // 
            // tbxRaisonSocial
            // 
            this.tbxRaisonSocial.Location = new System.Drawing.Point(209, 120);
            this.tbxRaisonSocial.Name = "tbxRaisonSocial";
            this.tbxRaisonSocial.Size = new System.Drawing.Size(100, 20);
            this.tbxRaisonSocial.TabIndex = 2;
            this.tbxRaisonSocial.TextChanged += new System.EventHandler(this.tbxRaisonSocial_TextChanged);
            // 
            // cbx_TypSociete
            // 
            this.cbx_TypSociete.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TypSociete.FormattingEnabled = true;
            this.cbx_TypSociete.Location = new System.Drawing.Point(209, 162);
            this.cbx_TypSociete.Name = "cbx_TypSociete";
            this.cbx_TypSociete.Size = new System.Drawing.Size(121, 21);
            this.cbx_TypSociete.TabIndex = 3;
            // 
            // Formulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.cbx_TypSociete);
            this.Controls.Add(this.tbxRaisonSocial);
            this.Controls.Add(this.rtbx_Commentaire);
            this.Controls.Add(this.lbl_Commentaires);
            this.Controls.Add(this.gbx_InfoProspect);
            this.Controls.Add(this.lbl_TitreFenetre);
            this.Controls.Add(this.btn_Retour);
            this.Controls.Add(this.btn_ValidFormulaire);
            this.Controls.Add(this.tbx_NbEmploye);
            this.Controls.Add(this.lbl_NbEmploye);
            this.Controls.Add(this.tbx_CA_Societe);
            this.Controls.Add(this.lbl_CA_Societe);
            this.Controls.Add(this.tbx_Telephone);
            this.Controls.Add(this.lbl_Telephone);
            this.Controls.Add(this.tbx_Adresse);
            this.Controls.Add(this.lbl_Adresse);
            this.Controls.Add(this.tbx_DomActivity);
            this.Controls.Add(this.tbx_NumIden);
            this.Controls.Add(this.lbl_DomActivity);
            this.Controls.Add(this.lbl_TypSociete);
            this.Controls.Add(this.lbl_RaisonSocial);
            this.Controls.Add(this.lbl_NumIdent);
            this.Controls.Add(this.lblMessEcranFormulaire);
            this.Name = "Formulaire";
            this.Text = "Formulaire";
            this.Load += new System.EventHandler(this.Formulaire_Load);
            this.gbx_InfoProspect.ResumeLayout(false);
            this.gbx_InfoProspect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errProvidFormulaire)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessEcranFormulaire;
        private System.Windows.Forms.Label lbl_NumIdent;
        private System.Windows.Forms.Label lbl_RaisonSocial;
        private System.Windows.Forms.Label lbl_TypSociete;
        private System.Windows.Forms.Label lbl_DomActivity;
        private System.Windows.Forms.TextBox tbx_NumIden;
        private System.Windows.Forms.TextBox tbx_DomActivity;
        private System.Windows.Forms.Label lbl_Adresse;
        private System.Windows.Forms.TextBox tbx_Adresse;
        private System.Windows.Forms.Label lbl_Telephone;
        private System.Windows.Forms.TextBox tbx_Telephone;
        private System.Windows.Forms.Label lbl_CA_Societe;
        private System.Windows.Forms.TextBox tbx_CA_Societe;
        private System.Windows.Forms.Label lbl_NbEmploye;
        private System.Windows.Forms.TextBox tbx_NbEmploye;
        private System.Windows.Forms.Label lbl_DateProspec;
        private System.Windows.Forms.Label lbl_Interesse;
        private System.Windows.Forms.CheckBox chkbx_Oui;
        private System.Windows.Forms.CheckBox chkbx_Non;
        private System.Windows.Forms.Button btn_ValidFormulaire;
        private System.Windows.Forms.Button btn_Retour;
        private System.Windows.Forms.Label lbl_TitreFenetre;
        private System.Windows.Forms.GroupBox gbx_InfoProspect;
        private System.Windows.Forms.Label lbl_Commentaires;
        private System.Windows.Forms.RichTextBox rtbx_Commentaire;
        private System.Windows.Forms.ErrorProvider errProvidFormulaire;
        private System.Windows.Forms.DateTimePicker dtp_DateProsp;
        private System.Windows.Forms.TextBox tbxRaisonSocial;
        private System.Windows.Forms.ComboBox cbx_TypSociete;
    }
}
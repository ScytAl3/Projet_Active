namespace DB_Projet_Active
{
    partial class EcranGestion
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
            this.tbx_RechClient = new System.Windows.Forms.TextBox();
            this.lblGestClient = new System.Windows.Forms.Label();
            this.lblRechClient = new System.Windows.Forms.Label();
            this.dtgGestClient = new System.Windows.Forms.DataGridView();
            this.btn_Ajouter = new System.Windows.Forms.Button();
            this.btn_Modif = new System.Windows.Forms.Button();
            this.btn_Retour = new System.Windows.Forms.Button();
            this.btn_Supp = new System.Windows.Forms.Button();
            this.lblMessEcranGestion = new System.Windows.Forms.Label();
            this.Bt_Relance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGestClient)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_RechClient
            // 
            this.tbx_RechClient.Location = new System.Drawing.Point(197, 87);
            this.tbx_RechClient.Name = "tbx_RechClient";
            this.tbx_RechClient.Size = new System.Drawing.Size(219, 20);
            this.tbx_RechClient.TabIndex = 0;
            this.tbx_RechClient.TextChanged += new System.EventHandler(this.tbx_RechClient_TextChanged);
            // 
            // lblGestClient
            // 
            this.lblGestClient.AutoSize = true;
            this.lblGestClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGestClient.Location = new System.Drawing.Point(244, 21);
            this.lblGestClient.Name = "lblGestClient";
            this.lblGestClient.Size = new System.Drawing.Size(403, 39);
            this.lblGestClient.TabIndex = 1;
            this.lblGestClient.Text = "Titre de la gestion choisie";
            this.lblGestClient.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRechClient
            // 
            this.lblRechClient.AutoSize = true;
            this.lblRechClient.Location = new System.Drawing.Point(50, 90);
            this.lblRechClient.Name = "lblRechClient";
            this.lblRechClient.Size = new System.Drawing.Size(141, 13);
            this.lblRechClient.TabIndex = 2;
            this.lblRechClient.Text = "Raison Social à rechercher :";
            // 
            // dtgGestClient
            // 
            this.dtgGestClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGestClient.Location = new System.Drawing.Point(39, 116);
            this.dtgGestClient.Name = "dtgGestClient";
            this.dtgGestClient.Size = new System.Drawing.Size(731, 326);
            this.dtgGestClient.TabIndex = 3;
            // 
            // btn_Ajouter
            // 
            this.btn_Ajouter.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_Ajouter.Location = new System.Drawing.Point(39, 448);
            this.btn_Ajouter.Name = "btn_Ajouter";
            this.btn_Ajouter.Size = new System.Drawing.Size(100, 45);
            this.btn_Ajouter.TabIndex = 4;
            this.btn_Ajouter.Text = "Ajouter";
            this.btn_Ajouter.UseVisualStyleBackColor = false;
            this.btn_Ajouter.Click += new System.EventHandler(this.btn_Ajouter_Click);
            // 
            // btn_Modif
            // 
            this.btn_Modif.BackColor = System.Drawing.Color.NavajoWhite;
            this.btn_Modif.Location = new System.Drawing.Point(145, 448);
            this.btn_Modif.Name = "btn_Modif";
            this.btn_Modif.Size = new System.Drawing.Size(100, 45);
            this.btn_Modif.TabIndex = 5;
            this.btn_Modif.Text = "Modifier";
            this.btn_Modif.UseVisualStyleBackColor = false;
            this.btn_Modif.Click += new System.EventHandler(this.btn_Modif_Click);
            // 
            // btn_Retour
            // 
            this.btn_Retour.BackColor = System.Drawing.Color.LightCoral;
            this.btn_Retour.Location = new System.Drawing.Point(693, 518);
            this.btn_Retour.Name = "btn_Retour";
            this.btn_Retour.Size = new System.Drawing.Size(100, 45);
            this.btn_Retour.TabIndex = 6;
            this.btn_Retour.Text = "<< Retour";
            this.btn_Retour.UseVisualStyleBackColor = false;
            this.btn_Retour.Click += new System.EventHandler(this.btn_Retour_Click);
            // 
            // btn_Supp
            // 
            this.btn_Supp.BackColor = System.Drawing.Color.Firebrick;
            this.btn_Supp.Location = new System.Drawing.Point(521, 448);
            this.btn_Supp.Name = "btn_Supp";
            this.btn_Supp.Size = new System.Drawing.Size(100, 45);
            this.btn_Supp.TabIndex = 7;
            this.btn_Supp.Text = "Supprimer";
            this.btn_Supp.UseVisualStyleBackColor = false;
            this.btn_Supp.Click += new System.EventHandler(this.btn_Supp_Click);
            // 
            // lblMessEcranGestion
            // 
            this.lblMessEcranGestion.AutoSize = true;
            this.lblMessEcranGestion.Location = new System.Drawing.Point(12, 550);
            this.lblMessEcranGestion.Name = "lblMessEcranGestion";
            this.lblMessEcranGestion.Size = new System.Drawing.Size(56, 13);
            this.lblMessEcranGestion.TabIndex = 8;
            this.lblMessEcranGestion.Text = "Message !";
            // 
            // Bt_Relance
            // 
            this.Bt_Relance.BackColor = System.Drawing.Color.LightBlue;
            this.Bt_Relance.Location = new System.Drawing.Point(282, 448);
            this.Bt_Relance.Name = "Bt_Relance";
            this.Bt_Relance.Size = new System.Drawing.Size(100, 45);
            this.Bt_Relance.TabIndex = 9;
            this.Bt_Relance.Text = "À relancer";
            this.Bt_Relance.UseVisualStyleBackColor = false;
            this.Bt_Relance.Click += new System.EventHandler(this.Bt_Relance_Click);
            // 
            // EcranGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 575);
            this.Controls.Add(this.Bt_Relance);
            this.Controls.Add(this.lblMessEcranGestion);
            this.Controls.Add(this.btn_Supp);
            this.Controls.Add(this.btn_Retour);
            this.Controls.Add(this.btn_Modif);
            this.Controls.Add(this.btn_Ajouter);
            this.Controls.Add(this.dtgGestClient);
            this.Controls.Add(this.lblRechClient);
            this.Controls.Add(this.lblGestClient);
            this.Controls.Add(this.tbx_RechClient);
            this.Name = "EcranGestion";
            this.Text = "GestionClient";
            this.Load += new System.EventHandler(this.GestionClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGestClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_RechClient;
        private System.Windows.Forms.Label lblGestClient;
        private System.Windows.Forms.Label lblRechClient;
        private System.Windows.Forms.DataGridView dtgGestClient;
        private System.Windows.Forms.Button btn_Ajouter;
        private System.Windows.Forms.Button btn_Modif;
        private System.Windows.Forms.Button btn_Retour;
        private System.Windows.Forms.Button btn_Supp;
        private System.Windows.Forms.Label lblMessEcranGestion;
        private System.Windows.Forms.Button Bt_Relance;
    }
}
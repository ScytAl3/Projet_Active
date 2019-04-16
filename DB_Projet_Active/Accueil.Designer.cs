namespace DB_Projet_Active
{
    partial class Accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAccueil = new System.Windows.Forms.Label();
            this.Bt_Quit = new System.Windows.Forms.Button();
            this.Bt_Gest_Client = new System.Windows.Forms.Button();
            this.Bt_Gest_Prospect = new System.Windows.Forms.Button();
            this.lblMessEcranChoixGest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAccueil
            // 
            this.lblAccueil.AutoSize = true;
            this.lblAccueil.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccueil.Location = new System.Drawing.Point(160, 31);
            this.lblAccueil.Name = "lblAccueil";
            this.lblAccueil.Size = new System.Drawing.Size(487, 31);
            this.lblAccueil.TabIndex = 0;
            this.lblAccueil.Text = "Gestion des clients et des prospects";
            this.lblAccueil.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Bt_Quit
            // 
            this.Bt_Quit.BackColor = System.Drawing.Color.IndianRed;
            this.Bt_Quit.Location = new System.Drawing.Point(689, 399);
            this.Bt_Quit.Name = "Bt_Quit";
            this.Bt_Quit.Size = new System.Drawing.Size(75, 39);
            this.Bt_Quit.TabIndex = 1;
            this.Bt_Quit.Text = "Quit [ ]";
            this.Bt_Quit.UseVisualStyleBackColor = false;
            this.Bt_Quit.Click += new System.EventHandler(this.Bt_Quit_Click);
            // 
            // Bt_Gest_Client
            // 
            this.Bt_Gest_Client.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.Bt_Gest_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Gest_Client.Location = new System.Drawing.Point(76, 226);
            this.Bt_Gest_Client.Name = "Bt_Gest_Client";
            this.Bt_Gest_Client.Size = new System.Drawing.Size(208, 79);
            this.Bt_Gest_Client.TabIndex = 2;
            this.Bt_Gest_Client.Text = "Gestion des clients";
            this.Bt_Gest_Client.UseVisualStyleBackColor = false;
            this.Bt_Gest_Client.Click += new System.EventHandler(this.Bt_Gest_Client_Click);
            // 
            // Bt_Gest_Prospect
            // 
            this.Bt_Gest_Prospect.BackColor = System.Drawing.Color.DarkCyan;
            this.Bt_Gest_Prospect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bt_Gest_Prospect.Location = new System.Drawing.Point(465, 226);
            this.Bt_Gest_Prospect.Name = "Bt_Gest_Prospect";
            this.Bt_Gest_Prospect.Size = new System.Drawing.Size(238, 79);
            this.Bt_Gest_Prospect.TabIndex = 3;
            this.Bt_Gest_Prospect.Text = "Gestion des prospects";
            this.Bt_Gest_Prospect.UseVisualStyleBackColor = false;
            this.Bt_Gest_Prospect.Click += new System.EventHandler(this.Bt_Gest_Prospect_Click);
            // 
            // lblMessEcranChoixGest
            // 
            this.lblMessEcranChoixGest.AutoSize = true;
            this.lblMessEcranChoixGest.Location = new System.Drawing.Point(12, 428);
            this.lblMessEcranChoixGest.Name = "lblMessEcranChoixGest";
            this.lblMessEcranChoixGest.Size = new System.Drawing.Size(56, 13);
            this.lblMessEcranChoixGest.TabIndex = 4;
            this.lblMessEcranChoixGest.Text = "Message !";
            // 
            // Accueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 450);
            this.Controls.Add(this.lblMessEcranChoixGest);
            this.Controls.Add(this.Bt_Gest_Prospect);
            this.Controls.Add(this.Bt_Gest_Client);
            this.Controls.Add(this.Bt_Quit);
            this.Controls.Add(this.lblAccueil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Accueil";
            this.Text = "Accueil";
            this.Load += new System.EventHandler(this.Accueil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAccueil;
        private System.Windows.Forms.Button Bt_Quit;
        private System.Windows.Forms.Button Bt_Gest_Client;
        private System.Windows.Forms.Button Bt_Gest_Prospect;
        private System.Windows.Forms.Label lblMessEcranChoixGest;
    }
}


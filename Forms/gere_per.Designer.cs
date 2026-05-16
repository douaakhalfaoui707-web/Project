namespace Restaurant_ihec_carthage.Forms
{
    partial class gere_per
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
            System.Windows.Forms.Button btn_dec;
            this.dgvPersonnel = new System.Windows.Forms.DataGridView();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.Ajout = new System.Windows.Forms.Button();
            this.recher = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.retour = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            btn_dec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dec
            // 
            btn_dec.BackColor = System.Drawing.Color.WhiteSmoke;
            btn_dec.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            btn_dec.FlatAppearance.BorderSize = 0;
            btn_dec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_dec.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_dec.Location = new System.Drawing.Point(66, 6);
            btn_dec.Name = "btn_dec";
            btn_dec.Size = new System.Drawing.Size(135, 40);
            btn_dec.TabIndex = 2;
            btn_dec.Text = "Déconnecter";
            btn_dec.UseVisualStyleBackColor = false;
            btn_dec.Click += new System.EventHandler(this.btn_dec_Click);
            // 
            // dgvPersonnel
            // 
            this.dgvPersonnel.AllowUserToOrderColumns = true;
            this.dgvPersonnel.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPersonnel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonnel.Location = new System.Drawing.Point(49, 304);
            this.dgvPersonnel.Name = "dgvPersonnel";
            this.dgvPersonnel.RowHeadersWidth = 51;
            this.dgvPersonnel.RowTemplate.Height = 24;
            this.dgvPersonnel.Size = new System.Drawing.Size(1277, 733);
            this.dgvPersonnel.TabIndex = 31;
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.IndianRed;
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(431, 228);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(307, 59);
            this.btnSupprimer.TabIndex = 30;
            this.btnSupprimer.Text = "Supprimer Personnel🗑️";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.Silver;
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(49, 228);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(362, 59);
            this.btnModifier.TabIndex = 29;
            this.btnModifier.Text = "Enregistrer Modification 💾";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // Ajout
            // 
            this.Ajout.BackColor = System.Drawing.Color.SlateBlue;
            this.Ajout.FlatAppearance.BorderSize = 0;
            this.Ajout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ajout.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ajout.Location = new System.Drawing.Point(1060, 155);
            this.Ajout.Name = "Ajout";
            this.Ajout.Size = new System.Drawing.Size(266, 59);
            this.Ajout.TabIndex = 28;
            this.Ajout.Text = "+ Ajouter Personnel";
            this.Ajout.UseVisualStyleBackColor = false;
            this.Ajout.Click += new System.EventHandler(this.Ajout_Click);
            // 
            // recher
            // 
            this.recher.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recher.Location = new System.Drawing.Point(49, 161);
            this.recher.Name = "recher";
            this.recher.Size = new System.Drawing.Size(993, 47);
            this.recher.TabIndex = 27;
            this.recher.TextChanged += new System.EventHandler(this.recher_TextChanged);
            this.recher.Enter += new System.EventHandler(this.recher_Enter_1);
            this.recher.Leave += new System.EventHandler(this.recher_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Window;
            this.panel3.Controls.Add(this.retour);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1420, 89);
            this.panel3.TabIndex = 26;
            // 
            // retour
            // 
            this.retour.Font = new System.Drawing.Font("MS Outlook", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retour.Location = new System.Drawing.Point(10, 25);
            this.retour.Name = "retour";
            this.retour.Size = new System.Drawing.Size(58, 44);
            this.retour.TabIndex = 8;
            this.retour.Text = "⬅️";
            this.retour.UseVisualStyleBackColor = true;
            this.retour.Click += new System.EventHandler(this.retour_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(166, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gerer Personnel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(162, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "Gestion Personnel";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Restaurant_ihec_carthage.Properties.Resources.Screenshot_2026_04_30_192645;
            this.pictureBox4.Location = new System.Drawing.Point(94, 25);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(49, 47);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(btn_dec);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(1114, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 53);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Restaurant_ihec_carthage.Properties.Resources._23566587_journal_en_dehors_icone_gratuit_vectoriel;
            this.pictureBox3.Location = new System.Drawing.Point(12, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(45, 47);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // gere_per
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 1117);
            this.Controls.Add(this.dgvPersonnel);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.Ajout);
            this.Controls.Add(this.recher);
            this.Controls.Add(this.panel3);
            this.Name = "gere_per";
            this.Text = "gere_per";
            this.Load += new System.EventHandler(this.gere_per_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnel)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonnel;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button Ajout;
        private System.Windows.Forms.TextBox recher;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button retour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
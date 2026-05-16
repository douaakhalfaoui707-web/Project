namespace Restaurant_ihec_carthage.Forms
{
    partial class ajout_per
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ajout_per));
            this.panel6 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.valider = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CIN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pre = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nom = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.mail = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.eye = new System.Windows.Forms.PictureBox();
            this.MDP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TLF = new System.Windows.Forms.TextBox();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel6.Controls.Add(this.comboBox1);
            this.panel6.Location = new System.Drawing.Point(165, 499);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(319, 46);
            this.panel6.TabIndex = 43;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Chef",
            "Sous_chef",
            "Serveur",
            "Plongeur",
            "Caissier"});
            this.comboBox1.Location = new System.Drawing.Point(10, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(276, 31);
            this.comboBox1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(47, 499);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 31);
            this.label6.TabIndex = 42;
            this.label6.Text = "Post :";
            // 
            // valider
            // 
            this.valider.BackColor = System.Drawing.Color.CornflowerBlue;
            this.valider.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.valider.Location = new System.Drawing.Point(312, 571);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(139, 57);
            this.valider.TabIndex = 41;
            this.valider.Text = "Valider ";
            this.valider.UseVisualStyleBackColor = false;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // annuler
            // 
            this.annuler.BackColor = System.Drawing.Color.SkyBlue;
            this.annuler.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.annuler.Location = new System.Drawing.Point(53, 571);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(139, 57);
            this.annuler.TabIndex = 40;
            this.annuler.Text = "Annuler";
            this.annuler.UseVisualStyleBackColor = false;
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.CIN);
            this.panel5.Location = new System.Drawing.Point(165, 143);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(319, 46);
            this.panel5.TabIndex = 39;
            // 
            // CIN
            // 
            this.CIN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CIN.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CIN.ForeColor = System.Drawing.Color.Gray;
            this.CIN.Location = new System.Drawing.Point(21, 11);
            this.CIN.Name = "CIN";
            this.CIN.Size = new System.Drawing.Size(284, 23);
            this.CIN.TabIndex = 8;
            this.CIN.Text = "votre CIN";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(35, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 31);
            this.label5.TabIndex = 38;
            this.label5.Text = "CIN :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.pre);
            this.panel3.Location = new System.Drawing.Point(165, 199);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 46);
            this.panel3.TabIndex = 37;
            // 
            // pre
            // 
            this.pre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pre.ForeColor = System.Drawing.Color.Gray;
            this.pre.Location = new System.Drawing.Point(21, 12);
            this.pre.Name = "pre";
            this.pre.Size = new System.Drawing.Size(284, 23);
            this.pre.TabIndex = 8;
            this.pre.Text = "votre prenom";
            this.pre.Leave += new System.EventHandler(this.pre_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.nom);
            this.panel1.Location = new System.Drawing.Point(165, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 46);
            this.panel1.TabIndex = 36;
            // 
            // nom
            // 
            this.nom.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nom.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nom.ForeColor = System.Drawing.Color.Gray;
            this.nom.Location = new System.Drawing.Point(21, 13);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(284, 23);
            this.nom.TabIndex = 8;
            this.nom.Text = "votre nom";
            this.nom.Leave += new System.EventHandler(this.nom_Leave_1);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.mail);
            this.panel4.Location = new System.Drawing.Point(165, 320);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(319, 46);
            this.panel4.TabIndex = 35;
            // 
            // mail
            // 
            this.mail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mail.ForeColor = System.Drawing.Color.Gray;
            this.mail.Location = new System.Drawing.Point(21, 12);
            this.mail.Name = "mail";
            this.mail.Size = new System.Drawing.Size(284, 23);
            this.mail.TabIndex = 8;
            this.mail.Text = "votre.email@ihec.ucar.tn";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.eye);
            this.panel2.Controls.Add(this.MDP);
            this.panel2.Location = new System.Drawing.Point(165, 377);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 46);
            this.panel2.TabIndex = 32;
            // 
            // eye
            // 
            this.eye.Image = ((System.Drawing.Image)(resources.GetObject("eye.Image")));
            this.eye.Location = new System.Drawing.Point(245, 4);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(41, 42);
            this.eye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eye.TabIndex = 10;
            this.eye.TabStop = false;
            this.eye.Click += new System.EventHandler(this.eye_Click);
            // 
            // MDP
            // 
            this.MDP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MDP.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDP.ForeColor = System.Drawing.Color.Gray;
            this.MDP.Location = new System.Drawing.Point(10, 7);
            this.MDP.Name = "MDP";
            this.MDP.PasswordChar = '●';
            this.MDP.Size = new System.Drawing.Size(229, 23);
            this.MDP.TabIndex = 10;
            this.MDP.Text = "    ●●●●●●●●●●●●●●●●●";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(16, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 31);
            this.label2.TabIndex = 34;
            this.label2.Text = "Prenom :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(35, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 31);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nom :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(6, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 31);
            this.label4.TabIndex = 31;
            this.label4.Text = "Mot De Passe :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(29, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 31);
            this.label3.TabIndex = 30;
            this.label3.Text = "Email :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(94, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(317, 41);
            this.label7.TabIndex = 44;
            this.label7.Text = "Ajouter Un Personnel";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(29, 444);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 31);
            this.label8.TabIndex = 45;
            this.label8.Text = "Telephone : ";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel7.Controls.Add(this.TLF);
            this.panel7.Location = new System.Drawing.Point(165, 439);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(319, 46);
            this.panel7.TabIndex = 46;
            // 
            // TLF
            // 
            this.TLF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TLF.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TLF.ForeColor = System.Drawing.Color.Gray;
            this.TLF.Location = new System.Drawing.Point(21, 11);
            this.TLF.Name = "TLF";
            this.TLF.Size = new System.Drawing.Size(284, 23);
            this.TLF.TabIndex = 8;
            this.TLF.Text = "votre numero du telephone";
            // 
            // ajout_per
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Restaurant_ihec_carthage.Properties.Resources.téléchargement__6_;
            this.ClientSize = new System.Drawing.Size(514, 653);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.valider);
            this.Controls.Add(this.annuler);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "ajout_per";
            this.Text = "ajout_per";
            this.Load += new System.EventHandler(this.ajout_per_Load);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox CIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox pre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nom;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox mail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox eye;
        private System.Windows.Forms.TextBox MDP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox TLF;
    }
}
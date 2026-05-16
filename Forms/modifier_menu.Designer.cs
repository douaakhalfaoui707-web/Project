namespace Restaurant_ihec_carthage.Forms
{
    partial class modifier_menu
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
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.TLF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.jour = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.valider = new System.Windows.Forms.Button();
            this.annuler = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.plat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dessert = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boisson = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Prix = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.places = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(142, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(264, 41);
            this.label7.TabIndex = 45;
            this.label7.Text = "Modifier le Menu";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel7.Controls.Add(this.date);
            this.panel7.Controls.Add(this.TLF);
            this.panel7.Location = new System.Drawing.Point(211, 443);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(319, 46);
            this.panel7.TabIndex = 62;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(77, 447);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 31);
            this.label8.TabIndex = 61;
            this.label8.Text = "Date: ";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel6.Controls.Add(this.jour);
            this.panel6.Location = new System.Drawing.Point(211, 503);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(319, 46);
            this.panel6.TabIndex = 60;
            // 
            // jour
            // 
            this.jour.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.jour.FormattingEnabled = true;
            this.jour.Items.AddRange(new object[] {
            "Lundi",
            "Mardi",
            "Mercredi",
            "Jeudi",
            "Vendredi",
            "Samedi"});
            this.jour.Location = new System.Drawing.Point(10, 9);
            this.jour.Name = "jour";
            this.jour.Size = new System.Drawing.Size(276, 31);
            this.jour.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(78, 507);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 31);
            this.label6.TabIndex = 59;
            this.label6.Text = "Jour :";
            // 
            // valider
            // 
            this.valider.BackColor = System.Drawing.Color.CornflowerBlue;
            this.valider.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.valider.Location = new System.Drawing.Point(358, 575);
            this.valider.Name = "valider";
            this.valider.Size = new System.Drawing.Size(139, 57);
            this.valider.TabIndex = 58;
            this.valider.Text = "Valider ";
            this.valider.UseVisualStyleBackColor = false;
            this.valider.Click += new System.EventHandler(this.valider_Click);
            // 
            // annuler
            // 
            this.annuler.BackColor = System.Drawing.Color.SkyBlue;
            this.annuler.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold);
            this.annuler.Location = new System.Drawing.Point(99, 575);
            this.annuler.Name = "annuler";
            this.annuler.Size = new System.Drawing.Size(139, 57);
            this.annuler.TabIndex = 57;
            this.annuler.Text = "Annuler";
            this.annuler.UseVisualStyleBackColor = false;
            this.annuler.Click += new System.EventHandler(this.annuler_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.plat);
            this.panel5.Location = new System.Drawing.Point(211, 147);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(319, 46);
            this.panel5.TabIndex = 56;
            // 
            // plat
            // 
            this.plat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.plat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plat.ForeColor = System.Drawing.Color.Gray;
            this.plat.Location = new System.Drawing.Point(21, 11);
            this.plat.Name = "plat";
            this.plat.Size = new System.Drawing.Size(284, 23);
            this.plat.TabIndex = 8;
            this.plat.Text = "nom du plat";
            this.plat.Leave += new System.EventHandler(this.plat_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(81, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 31);
            this.label5.TabIndex = 55;
            this.label5.Text = "Plat :";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.Controls.Add(this.dessert);
            this.panel3.Location = new System.Drawing.Point(211, 203);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(319, 46);
            this.panel3.TabIndex = 54;
            // 
            // dessert
            // 
            this.dessert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dessert.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dessert.ForeColor = System.Drawing.Color.Gray;
            this.dessert.Location = new System.Drawing.Point(21, 12);
            this.dessert.Name = "dessert";
            this.dessert.Size = new System.Drawing.Size(284, 23);
            this.dessert.TabIndex = 8;
            this.dessert.Text = "nom de dessert";
            this.dessert.Leave += new System.EventHandler(this.dessert_Leave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.boisson);
            this.panel1.Location = new System.Drawing.Point(211, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 46);
            this.panel1.TabIndex = 53;
            // 
            // boisson
            // 
            this.boisson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boisson.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boisson.ForeColor = System.Drawing.Color.Gray;
            this.boisson.Location = new System.Drawing.Point(21, 13);
            this.boisson.Name = "boisson";
            this.boisson.Size = new System.Drawing.Size(284, 23);
            this.boisson.TabIndex = 8;
            this.boisson.Text = "nom de boisson";
            this.boisson.Leave += new System.EventHandler(this.boisson_Leave);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.Prix);
            this.panel4.Location = new System.Drawing.Point(211, 324);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(319, 46);
            this.panel4.TabIndex = 52;
            // 
            // Prix
            // 
            this.Prix.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Prix.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Prix.ForeColor = System.Drawing.Color.Gray;
            this.Prix.Location = new System.Drawing.Point(21, 12);
            this.Prix.Name = "Prix";
            this.Prix.Size = new System.Drawing.Size(284, 23);
            this.Prix.TabIndex = 8;
            this.Prix.Text = "prix en dt";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.places);
            this.panel2.Location = new System.Drawing.Point(211, 381);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 46);
            this.panel2.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(42, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 31);
            this.label2.TabIndex = 51;
            this.label2.Text = "Dessert :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(42, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 31);
            this.label1.TabIndex = 50;
            this.label1.Text = "Boisson :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(66, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 31);
            this.label4.TabIndex = 48;
            this.label4.Text = "Place :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(82, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 31);
            this.label3.TabIndex = 47;
            this.label3.Text = "Prix :";
            // 
            // places
            // 
            this.places.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.places.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.places.ForeColor = System.Drawing.Color.Gray;
            this.places.Location = new System.Drawing.Point(21, 15);
            this.places.Name = "places";
            this.places.Size = new System.Drawing.Size(284, 23);
            this.places.TabIndex = 9;
            this.places.Text = "nombre de place";
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(21, 11);
            this.date.MinDate = new System.DateTime(2026, 5, 10, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(265, 30);
            this.date.TabIndex = 9;
            // 
            // modifier_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Restaurant_ihec_carthage.Properties.Resources.téléchargement__7_;
            this.ClientSize = new System.Drawing.Size(582, 691);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label8);
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
            this.Controls.Add(this.label7);
            this.Name = "modifier_menu";
            this.Text = "modifier_menu";
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox TLF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox jour;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button valider;
        private System.Windows.Forms.Button annuler;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox plat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox dessert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox boisson;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox Prix;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox places;
        private System.Windows.Forms.DateTimePicker date;
    }
}
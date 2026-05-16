namespace Restaurant_ihec_carthage.Forms
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.eye = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.txtMDP = new System.Windows.Forms.TextBox();
            this.remarque = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnPer = new System.Windows.Forms.Button();
            this.btnEt = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(45, 751);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 163);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtEmail.Location = new System.Drawing.Point(79, 24);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(326, 23);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.Text = "votre.email@ihec.ucar.tn";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.label4.Location = new System.Drawing.Point(59, 506);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mot De Passe :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Location = new System.Drawing.Point(55, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 76);
            this.panel1.TabIndex = 12;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(10, 12);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(55, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.eye);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.txtMDP);
            this.panel2.Location = new System.Drawing.Point(55, 559);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 76);
            this.panel2.TabIndex = 13;
            // 
            // eye
            // 
            this.eye.Image = ((System.Drawing.Image)(resources.GetObject("eye.Image")));
            this.eye.Location = new System.Drawing.Point(380, 15);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(41, 42);
            this.eye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eye.TabIndex = 10;
            this.eye.TabStop = false;
            this.eye.Click += new System.EventHandler(this.eye_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(14, 7);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(50, 50);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 11;
            this.pictureBox6.TabStop = false;
            // 
            // txtMDP
            // 
            this.txtMDP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMDP.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMDP.ForeColor = System.Drawing.Color.Gray;
            this.txtMDP.Location = new System.Drawing.Point(79, 25);
            this.txtMDP.Name = "txtMDP";
            this.txtMDP.PasswordChar = '●';
            this.txtMDP.Size = new System.Drawing.Size(295, 23);
            this.txtMDP.TabIndex = 10;
            this.txtMDP.Text = "    ●●●●●●●●●●●●●●●●●";
            this.txtMDP.Enter += new System.EventHandler(this.txtMDP_Enter);
            this.txtMDP.Leave += new System.EventHandler(this.txtMDP_Leave);
            // 
            // remarque
            // 
            this.remarque.AutoSize = true;
            this.remarque.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.remarque.Location = new System.Drawing.Point(55, 693);
            this.remarque.Name = "remarque";
            this.remarque.Size = new System.Drawing.Size(0, 23);
            this.remarque.TabIndex = 14;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(103)))), ((int)(((byte)(223)))));
            this.btnAdmin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(103)))), ((int)(((byte)(223)))));
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.Location = new System.Drawing.Point(45, 281);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(128, 57);
            this.btnAdmin.TabIndex = 15;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnPer
            // 
            this.btnPer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(103)))), ((int)(((byte)(223)))));
            this.btnPer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(103)))), ((int)(((byte)(223)))));
            this.btnPer.FlatAppearance.BorderSize = 0;
            this.btnPer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPer.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPer.Location = new System.Drawing.Point(192, 281);
            this.btnPer.Name = "btnPer";
            this.btnPer.Size = new System.Drawing.Size(145, 57);
            this.btnPer.TabIndex = 16;
            this.btnPer.Text = "Personnel";
            this.btnPer.UseVisualStyleBackColor = false;
            this.btnPer.Click += new System.EventHandler(this.btnPer_Click);
            // 
            // btnEt
            // 
            this.btnEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(103)))), ((int)(((byte)(223)))));
            this.btnEt.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(103)))), ((int)(((byte)(223)))));
            this.btnEt.FlatAppearance.BorderSize = 0;
            this.btnEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEt.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEt.Location = new System.Drawing.Point(354, 281);
            this.btnEt.Name = "btnEt";
            this.btnEt.Size = new System.Drawing.Size(140, 57);
            this.btnEt.TabIndex = 17;
            this.btnEt.Text = "Etudiant";
            this.btnEt.UseVisualStyleBackColor = false;
            this.btnEt.Click += new System.EventHandler(this.btnEt_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-15, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 265);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 934);
            this.Controls.Add(this.btnEt);
            this.Controls.Add(this.btnPer);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.remarque);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox txtMDP;
        private System.Windows.Forms.PictureBox eye;
        private System.Windows.Forms.Label remarque;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnPer;
        private System.Windows.Forms.Button btnEt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
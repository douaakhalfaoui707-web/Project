using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_ihec_carthage.Forms
{
    public partial class ajout_per : Form
    {
        private bool _mdpVisible = false;
        public ajout_per()
        {
            InitializeComponent();
            CIN.Enter += (s, e) => { if (CIN.Text == "votre CIN") CIN.Text = ""; };
            pre.Enter += (s, e) => { if (pre.Text == "votre prenom") pre.Text = ""; };
            nom.Enter += (s, e) => { if (nom.Text == "votre nom") nom.Text = ""; };
            mail.Enter += (s, e) => { if (mail.Text == "votre.email@ihec.ucar.tn") mail.Text = ""; };
            MDP.Enter += (s, e) => { if (MDP.Text == "    ●●●●●●●●●●●●●●●●●") MDP.Text = ""; };
            TLF.Enter += (s, e) => { if (TLF.Text == "votre numero du telephone") TLF.Text = ""; };

            // ===== REMETTRE LE PLACEHOLDER SI VIDE =====
            CIN.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(CIN.Text)) CIN.Text = "votre CIN"; };
            pre.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(pre.Text)) pre.Text = "votre prenom"; };
            nom.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(nom.Text)) nom.Text = "votre nom"; };
            mail.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(mail.Text)) mail.Text = "votre.email@ihec.ucar.tn"; };
            MDP.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(MDP.Text)) MDP.Text = "    ●●●●●●●●●●●●●●●●●"; };
            TLF.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(TLF.Text)) TLF.Text = "votre numero du telephone"; };
        }

        private void valider_Click(object sender, EventArgs e)
        {
            // --- Vérifier champs vides ---
            if (string.IsNullOrWhiteSpace(CIN.Text) || CIN.Text == "votre CIN" ||
                string.IsNullOrWhiteSpace(pre.Text) || pre.Text == "votre prenom" ||
                string.IsNullOrWhiteSpace(nom.Text) || nom.Text == "votre nom" ||
                string.IsNullOrWhiteSpace(mail.Text) || mail.Text == "votre.email@ihec.ucar.tn" ||
                string.IsNullOrWhiteSpace(MDP.Text) || MDP.Text == "    ●●●●●●●●●●●●●●●●●" ||
                string.IsNullOrWhiteSpace(TLF.Text) || TLF.Text == "votre numero du telephone" ||
                comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs manquants",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Vérifier CIN : exactement 8 chiffres ---
            if (CIN.Text.Length != 8 || !CIN.Text.All(char.IsDigit))
            {
                MessageBox.Show("Le CIN doit contenir exactement 8 chiffres.", "CIN invalide",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CIN.Focus();
                return;
            }

            // --- Vérifier Téléphone : exactement 8 chiffres ---
            if (TLF.Text.Length != 8 || !TLF.Text.All(char.IsDigit))
            {
                MessageBox.Show("Le téléphone doit contenir exactement 8 chiffres.", "Téléphone invalide",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                TLF.Focus();
                return;
            }

            // --- Vérifier Email ---
            string email = mail.Text.Trim();
            if (email != email.ToLower())
            {
                MessageBox.Show("L'email ne doit pas contenir de majuscules.", "Email invalide",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return;
            }
            if (!email.EndsWith("@ihec.ucar.tn"))
            {
                MessageBox.Show("L'email doit terminer par @ihec.ucar.tn\nEx: prenom.nom@ihec.ucar.tn",
                    "Email invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mail.Focus();
                return;
            }

            try
            {
                // 
                string queryUtilisateur = @"INSERT INTO UTILISATEUR 
                            (ID_UTILISATEUR, NOM, PRENOM, MAIL, MOT_DE_PASSE, ROLE) 
                            VALUES (@id, @nom, @prenom, @mail, @mdp, 'Personnel')";

                SqlParameter[] parametresUtilisateur = {
           
                    new SqlParameter("@id",     CIN.Text.Trim()),
                    new SqlParameter("@nom",    nom.Text.Trim()),
                    new SqlParameter("@prenom", pre.Text.Trim()),
                    new SqlParameter("@mail",   email),
                    new SqlParameter("@mdp",    MDP.Text.Trim())
        
                };

                DATABASE.ExecuterRequete(queryUtilisateur, parametresUtilisateur);

                // 
                string queryPersonnel = @"INSERT INTO PERSONNEL 
                                (ID_PERSONNEL, NOM, PRENOM, MAIL, TELEPHONE, POSTE) 
                                VALUES (@id, @nom, @prenom, @mail, @tel, @poste)";

                SqlParameter[] parametresPersonnel = {
            
                    new SqlParameter("@id",     CIN.Text.Trim()),
                    new SqlParameter("@nom",    nom.Text.Trim()),
                    new SqlParameter("@prenom", pre.Text.Trim()),
                    new SqlParameter("@mail",   email),
                   new SqlParameter("@tel",    TLF.Text.Trim()), 
                    new SqlParameter("@poste",  comboBox1.SelectedItem.ToString())
        };
                DATABASE.ExecuterRequete(queryPersonnel, parametresPersonnel);

                MessageBox.Show($"Personnel {pre.Text} {nom.Text} ajouté avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViderChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur base de données",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
        private void eye_Click(object sender, EventArgs e)
        {
            _mdpVisible = !_mdpVisible;

            if (_mdpVisible)
            {
                MDP.PasswordChar = '\0'; //  Mot de passe visible
            }
            else
            {
                MDP.PasswordChar = '●'; // Mot de passe invisible
            }
        }
        private void ViderChamps()
        {
            CIN.Text = "votre CIN";
            pre.Text = "votre prenom";
            nom.Text = "votre nom";
            mail.Text = "votre.email@ihec.ucar.tn";
            MDP.Text = "    ●●●●●●●●●●●●●●●●●";
            TLF.Text = "votre numero du telephone";
            comboBox1.SelectedIndex = -1;
            MDP.PasswordChar = '●';
            _mdpVisible = false;

        }

        private void nom_Leave_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nom.Text))
                nom.Text = char.ToUpper(nom.Text[0]) +
                           nom.Text.Substring(1).ToLower();
        }

        private void pre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pre.Text))
                pre.Text = char.ToUpper(pre.Text[0]) +
                           pre.Text.Substring(1).ToLower();
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            gere_per frmAcc = new gere_per();
            frmAcc.Show();
            this.Hide();
        }

        private void ajout_per_Load(object sender, EventArgs e)
        {

        }
    }
}

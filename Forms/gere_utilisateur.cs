using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_ihec_carthage.Forms
{
    public partial class gere_utilisateur : Form
    {
        public gere_utilisateur()
        {
            InitializeComponent();
            
            
            dgvUtilisateurs.AllowUserToAddRows = false;
            dgvUtilisateurs.ReadOnly = false;  // ← permettre l'édition
            dgvUtilisateurs.SelectionMode = DataGridViewSelectionMode.CellSelect; // ← sélection par cellule
            dgvUtilisateurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUtilisateurs.MultiSelect = false;


            dgvUtilisateurs.CellValueChanged += dgvUtilisateurs_CellValueChanged;
            dgvUtilisateurs.SelectionChanged += dgvUtilisateurs_SelectionChanged;
            dgvUtilisateurs.CellValidating += dgvUtilisateurs_CellValidating;
            dgvUtilisateurs.CellEndEdit += dgvUtilisateurs_CellEndEdit;
            btnModifier.Enabled = false;
            btnModifier.BackColor = Color.Silver;
            btnSupprimer.Enabled = false;
            recherche.Text = "Recherche par nom ou email";
            recherche.ForeColor = Color.Gray;
            ChargerUtilisateurs();
            SetRoundedCorners(Ajout, 40); AjouterShadow(Ajout);
            SetRoundedCorners(btnModifier, 40); AjouterShadow(btnModifier);
            SetRoundedCorners(btnSupprimer, 40); AjouterShadow(btnSupprimer);
            SetRoundedCorners(recherche, 40); AjouterShadow(recherche);
        }

        private void retour_Click(object sender, EventArgs e)
        {
            FormAccA frmAcc = new FormAccA();
            frmAcc.Show();
            this.Hide();
        }

        private void btn_dec_Click(object sender, EventArgs e)
        {
            FormLogin frmAcc = new FormLogin();
            frmAcc.Show();
            this.Hide();
        }
        private void ChargerUtilisateurs()
        {
            string query = "SELECT * FROM UTILISATEUR";
            DataTable dt = DATABASE.ExecuterSelect(query);

            dgvUtilisateurs.DataSource = dt;
        }
        
        private void SetRoundedCorners(Control control, int rayon)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, rayon, rayon, 180, 90);
            path.AddArc(control.Width - rayon, 0, rayon, rayon, 270, 90);
            path.AddArc(control.Width - rayon, control.Height - rayon, rayon, rayon, 0, 90);
            path.AddArc(0, control.Height - rayon, rayon, rayon, 90, 90);
            path.CloseAllFigures();
            control.Region = new Region(path);
        }
        private void AjouterShadow(Control pic)
        {
            // Créer un panel ombre derrière la PictureBox
            Panel shadow = new Panel();
            shadow.Size = new Size(pic.Width, pic.Height);
            shadow.Location = new Point(pic.Left + 4, pic.Top + 4); // décalé de 4px
            shadow.BackColor = Color.FromArgb(80, 0, 0, 0); // noir transparent

            // Coins arrondis sur le shadow
            SetRoundedCorners(shadow, 40);

            // Ajouter DERRIÈRE la PictureBox
            pic.Parent.Controls.Add(shadow);
            pic.Parent.Controls.SetChildIndex(shadow,
            pic.Parent.Controls.GetChildIndex(pic) + 1); // derrière
        }
        private bool _modificationEnCours = false;
        private void dgvUtilisateurs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _modificationEnCours = true;
                btnModifier.Enabled = true;
                btnModifier.BackColor = Color.LightSeaGreen; // signaler visuellement qu'il y a des changements
               
            }
        }
        private void dgvUtilisateurs_SelectionChanged(object sender, EventArgs e)
        {
            bool ligneSelectionnee = dgvUtilisateurs.CurrentRow != null
                          && dgvUtilisateurs.CurrentRow.Index >= 0;
            btnSupprimer.Enabled = ligneSelectionnee;
        }
        private void dgvUtilisateurs_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colonne = dgvUtilisateurs.Columns[e.ColumnIndex].Name;
            string valeur = e.FormattedValue?.ToString().Trim();

            //   1ère lettre en majuscule
            if (colonne == "NOM" || colonne == "PRENOM")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = $"{colonne} obligatoire.";
                    MessageBox.Show($"Le champ {colonne} ne peut pas être vide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Corriger automatiquement la 1ère lettre en majuscule
                string corrige = char.ToUpper(valeur[0]) + valeur.Substring(1).ToLower();
                dgvUtilisateurs.CurrentCell.Value = corrige;
            }

            // minuscules + terminer par @ihec.ucar.tn
            if (colonne == "MAIL")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "Email obligatoire.";
                    MessageBox.Show("L'email est obligatoire.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier pas de majuscules
                if (valeur != valeur.ToLower())
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "Email ne doit pas contenir de majuscules.";
                    MessageBox.Show("L'email ne doit pas contenir de lettres majuscules.", "Email invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier qu'il termine par @ihec.ucar.tn
                if (!valeur.EndsWith("@ihec.ucar.tn"))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "Email doit terminer par @ihec.ucar.tn";
                    MessageBox.Show("L'email doit terminer par @ihec.ucar.tn\nEx: nom@ihec.ucar.tn", "Email invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier qu'il y a quelque chose avant le @
                string partieAvantArobase = valeur.Split('@')[0];
                if (string.IsNullOrWhiteSpace(partieAvantArobase))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "Email invalide.";
                    MessageBox.Show("Email invalide. Ex: nom@ihec.ucar.tn", "Email invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //  Administrateur Etudiant  Personnel
            if (colonne == "ROLE")
            {
                string[] rolesAcceptes = { "Administrateur", "Etudiant", "Personnel" };

                if (!rolesAcceptes.Contains(valeur))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "Rôle invalide.";
                    MessageBox.Show("Le rôle doit être :\n• Administrateur\n• Etudiant\n• Personnel",
                        "Rôle invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //  ID exactement 8 chiffres
           if (colonne == "ID_UTILISATEUR")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "ID obligatoire.";
                    MessageBox.Show("L'ID est obligatoire.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier que c'est uniquement des chiffres
                if (!valeur.All(char.IsDigit))
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "ID doit contenir uniquement des chiffres.";
                    MessageBox.Show("L'ID doit contenir uniquement des chiffres.", "ID invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier exactement 8 chiffres
                if (valeur.Length != 8)
                {
                    e.Cancel = true;
                    dgvUtilisateurs.Rows[e.RowIndex].ErrorText = "ID doit contenir exactement 8 chiffres.";
                    MessageBox.Show($"L'ID doit contenir exactement 8 chiffres.\nVous avez entré {valeur.Length} chiffre(s).",
                        "ID invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // Effacer le message d'erreur après correction
        private void dgvUtilisateurs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvUtilisateurs.Rows[e.RowIndex].ErrorText = string.Empty;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ajout_utilisateur frmAcc = new ajout_utilisateur();
            frmAcc.Show();
            this.Hide();

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            if (!_modificationEnCours) return;

            var confirm = MessageBox.Show(
                "Voulez-vous enregistrer les modifications ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int erreurs = 0;
            int succes = 0;

            foreach (DataGridViewRow row in dgvUtilisateurs.Rows) //corrigé
            {
                if (row.IsNewRow) continue;

                try
                {
                    int id = Convert.ToInt32(row.Cells["ID_UTILISATEUR"].Value);
                    string nom = row.Cells["NOM"].Value?.ToString();
                    string prenom = row.Cells["PRENOM"].Value?.ToString();
                    string mail = row.Cells["MAIL"].Value?.ToString();
                    string role = row.Cells["ROLE"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
                    {
                        erreurs++;
                        continue;
                    }

                    string query = @"UPDATE UTILISATEUR 
                             SET NOM=@nom, PRENOM=@prenom, MAIL=@mail, ROLE=@role
                             WHERE ID_UTILISATEUR=@id";

                    SqlParameter[] parametres = {
                            new SqlParameter("@nom",    nom),
                            new SqlParameter("@prenom", prenom),
                            new SqlParameter("@mail",   mail),
                            new SqlParameter("@role",   role),
                            new SqlParameter("@id",     id)
                                                       };

                    int result = DATABASE.ExecuterRequete(query, parametres);
                    if (result > 0) succes++;
                }
                catch
                {
                    erreurs++;
                }
            }

            if (erreurs == 0)
                MessageBox.Show($"{succes} modification(s) enregistrée(s).", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"{succes} succès, {erreurs} erreur(s).", "Résultat",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            _modificationEnCours = false;
            btnModifier.BackColor = SystemColors.Control;
            //btnModifier.Text = "Modifier";
            ChargerUtilisateurs();
        }

        

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée
            if (dgvUtilisateurs.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Forcer la fin de l'édition en cours
            dgvUtilisateurs.EndEdit();

            string nom = dgvUtilisateurs.CurrentRow.Cells["NOM"].Value?.ToString();
            string prenom = dgvUtilisateurs.CurrentRow.Cells["PRENOM"].Value?.ToString();
            int id = Convert.ToInt32(dgvUtilisateurs.CurrentRow.Cells["ID_UTILISATEUR"].Value);

            var confirm = MessageBox.Show(
                $"Voulez-vous supprimer {prenom} {nom} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM UTILISATEUR WHERE ID_UTILISATEUR = @id";
                SqlParameter[] parametres = { new SqlParameter("@id", id) };
                int result = DATABASE.ExecuterRequete(query, parametres);

                if (result > 0)
                {
                    ChargerUtilisateurs();
                    btnSupprimer.Enabled = false;
                    MessageBox.Show("Utilisateur supprimé.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gere_utilisateur_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_modificationEnCours)
            {
                var confirm = MessageBox.Show(
                    "Vous avez des modifications non enregistrées. Quitter quand même ?",
                    "Attention",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void recherche_TextChanged(object sender, EventArgs e)
        {
            if (recherche.Text == "Recherche par nom ou email")
                return;

            string motrecherche = recherche.Text.Trim();

            string query = @"SELECT * 
                     FROM UTILISATEUR
                     WHERE NOM LIKE @recherche
                     OR MAIL LIKE @recherche";

            SqlParameter[] parametres =
            {
       
                new SqlParameter("@recherche", "%" + motrecherche + "%")
    
            };

            DataTable dt = DATABASE.ExecuterSelect(query, parametres);

            dgvUtilisateurs.DataSource = dt;
        }

        private void recherche_Enter(object sender, EventArgs e)
        {
            if (recherche.Text == "Recherche par nom ou email")
            {
                recherche.Text = "";
                recherche.ForeColor = Color.Black;
            }
        }

        private void recherche_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(recherche.Text))
            {
                recherche.Text = "Recherche par nom ou email";
                recherche.ForeColor = Color.Gray;
            }
        }

        private void gere_utilisateur_Load(object sender, EventArgs e)
        {

        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_ihec_carthage.Forms
{
    public partial class gere_per : Form
    {
        public gere_per()
        {
            InitializeComponent();
            dgvPersonnel.AllowUserToAddRows = false;
            dgvPersonnel.ReadOnly = false;  // ← permettre l'édition
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.CellSelect; // ← sélection par cellule
            dgvPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPersonnel.MultiSelect = false;


            dgvPersonnel.CellValueChanged += dgvPersonnel_CellValueChanged;
            dgvPersonnel.SelectionChanged += dgvPersonnel_SelectionChanged;
            dgvPersonnel.CellValidating += dgvPersonnel_CellValidating;
            dgvPersonnel.CellEndEdit += dgvPersonnel_CellEndEdit;
            btnModifier.Enabled = false;
            btnModifier.BackColor = Color.Silver;
            btnSupprimer.Enabled = false;
            recher.Text = "Recherche par nom ou email";
            recher.ForeColor = Color.Gray;
            ChargerPersonnel();
            SetRoundedCorners(Ajout, 40); AjouterShadow(Ajout);
            SetRoundedCorners(btnModifier, 40); AjouterShadow(btnModifier);
            SetRoundedCorners(btnSupprimer, 40); AjouterShadow(btnSupprimer);
            SetRoundedCorners(recher, 40); AjouterShadow(recher);
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
            foreach (DataGridViewRow row in dgvPersonnel.Rows)
            {
                if (row.IsNewRow) continue;

                try
                {
                    int id = Convert.ToInt32(row.Cells["ID_PERSONNEL"].Value); // ✅ corrigé
                    string nom = row.Cells["NOM"].Value?.ToString();
                    string prenom = row.Cells["PRENOM"].Value?.ToString();
                    string mail = row.Cells["MAIL"].Value?.ToString();
                    string poste = row.Cells["POSTE"].Value?.ToString();
                    string role = row.Cells["ROLE"].Value?.ToString();

                    if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom))
                    {
                        erreurs++;
                        continue;
                    }

                    //  Mise à jour PERSONNEL
                    string queryPersonnel = @"UPDATE PERSONNEL 
                                  SET NOM=@nom, PRENOM=@prenom, MAIL=@mail, POSTE=@poste
                                  WHERE ID_PERSONNEL=@id";
                    SqlParameter[] parametresPersonnel = {
                                        new SqlParameter("@nom",    nom),
                                        new SqlParameter("@prenom", prenom),
                                        new SqlParameter("@mail",   mail),
                                        new SqlParameter("@poste",  poste),
                                        new SqlParameter("@id",     id)
                                         };
                    int result = DATABASE.ExecuterRequete(queryPersonnel, parametresPersonnel);
                    if (result > 0) succes++;

                    //  Mise à jour UTILISATEUR
                    string queryUtilisateur = @"UPDATE UTILISATEUR 
                                    SET NOM=@nom, PRENOM=@prenom, MAIL=@mail, ROLE=@role
                                    WHERE ID_UTILISATEUR=@id";
                    SqlParameter[] parametresUtilisateur = {
                                      new SqlParameter("@nom",    nom),
                                      new SqlParameter("@prenom", prenom),
                                      new SqlParameter("@mail",   mail),
                                      new SqlParameter("@role",   role),
                                      new SqlParameter("@id",     id)
                                    };
                    DATABASE.ExecuterRequete(queryUtilisateur, parametresUtilisateur);
                }
                catch (Exception ex)
                {
                    erreurs++;
                    MessageBox.Show(ex.Message, "Erreur détaillée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            if (erreurs == 0)
                MessageBox.Show($"{succes} modification(s) enregistrée(s).", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show($"{succes} succès, {erreurs} erreur(s).", "Résultat",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

            _modificationEnCours = false;
            btnModifier.Enabled = false;
            btnModifier.BackColor = Color.Silver;
            ChargerPersonnel();
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
        private void dgvPersonnel_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _modificationEnCours = true;
                btnModifier.Enabled = true;
                btnModifier.BackColor = Color.LightSeaGreen; // signaler visuellement qu'il y a des changements

            }
        }
        private void dgvPersonnel_SelectionChanged(object sender, EventArgs e)
        {
            bool ligneSelectionnee = dgvPersonnel.CurrentRow != null
                          && dgvPersonnel.CurrentRow.Index >= 0;
            btnSupprimer.Enabled = ligneSelectionnee;
        }
        private void dgvPersonnel_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colonne = dgvPersonnel.Columns[e.ColumnIndex].Name;
            string valeur = e.FormattedValue?.ToString().Trim();

            // === NOM et PRENOM : 1ère lettre en majuscule ===
            if (colonne == "NOM" || colonne == "PRENOM")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = $"{colonne} obligatoire.";
                    MessageBox.Show($"Le champ {colonne} ne peut pas être vide.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Corriger automatiquement la 1ère lettre en majuscule
                string corrige = char.ToUpper(valeur[0]) + valeur.Substring(1).ToLower();
                dgvPersonnel.CurrentCell.Value = corrige;
            }

            // === MAIL : minuscules + terminer par @ihec.ucar.tn ===
            if (colonne == "MAIL")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "Email obligatoire.";
                    MessageBox.Show("L'email est obligatoire.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier pas de majuscules
                if (valeur != valeur.ToLower())
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "Email ne doit pas contenir de majuscules.";
                    MessageBox.Show("L'email ne doit pas contenir de lettres majuscules.", "Email invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier qu'il termine par @ihec.ucar.tn
                if (!valeur.EndsWith("@ihec.ucar.tn"))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "Email doit terminer par @ihec.ucar.tn";
                    MessageBox.Show("L'email doit terminer par @ihec.ucar.tn\nEx: nom@ihec.ucar.tn", "Email invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier qu'il y a quelque chose avant le @
                string partieAvantArobase = valeur.Split('@')[0];
                if (string.IsNullOrWhiteSpace(partieAvantArobase))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "Email invalide.";
                    MessageBox.Show("Email invalide. Ex: nom@ihec.ucar.tn", "Email invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // === ROLE : Administrateur, Etudiant ou Personnel ===
            if (colonne == "POST")
            {
                string[] rolesAcceptes = { "Chef", "Sous-Chef", "Serveur", "Plongeur", "Caissier" };

                if (!rolesAcceptes.Contains(valeur))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "Rôle invalide.";
                    MessageBox.Show("Le rôle doit être : \n•Chef\n•Sous-Chef\n•Serveur\n•Plongeur\n•Caissier",
                        "Rôle invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // ID_UTILISATEUR  exactement 8 chiffres ===
            if (colonne == "ID_PERSONNEL")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "ID obligatoire.";
                    MessageBox.Show("L'ID est obligatoire.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier que c'est uniquement des chiffres
                if (!valeur.All(char.IsDigit))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "ID doit contenir uniquement des chiffres.";
                    MessageBox.Show("L'ID doit contenir uniquement des chiffres.", "ID invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier exactement 8 chiffres
                if (valeur.Length != 8)
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "ID doit contenir exactement 8 chiffres.";
                    MessageBox.Show($"L'ID doit contenir exactement 8 chiffres.\nVous avez entré {valeur.Length} chiffre(s).",
                        "ID invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (colonne == "TELEPHONE")
            {
                if (string.IsNullOrWhiteSpace(valeur))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "TEL obligatoire.";
                    MessageBox.Show("L'TEL est obligatoire.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier que c'est uniquement des chiffres
                if (!valeur.All(char.IsDigit))
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "TEL doit contenir uniquement des chiffres.";
                    MessageBox.Show("L'TEL doit contenir uniquement des chiffres.", "TEL invalide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Vérifier exactement 8 chiffres
                if (valeur.Length != 8)
                {
                    e.Cancel = true;
                    dgvPersonnel.Rows[e.RowIndex].ErrorText = "TEL doit contenir exactement 8 chiffres.";
                    MessageBox.Show($"L'TEL doit contenir exactement 8 chiffres.\nVous avez entré {valeur.Length} chiffre(s).",
                        "TEL invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
 
        private void dgvPersonnel_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvPersonnel.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        private void ChargerPersonnel()
        {
            string query = @"SELECT P.ID_PERSONNEL, P.NOM, P.PRENOM, P.MAIL, P.TELEPHONE, P.POSTE,
                            U.ROLE, U.MOT_DE_PASSE
                     FROM PERSONNEL P
                     INNER JOIN UTILISATEUR U ON U.ID_UTILISATEUR = P.ID_PERSONNEL";
            DataTable dt = DATABASE.ExecuterSelect(query);
            dgvPersonnel.DataSource = dt;
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

        private void Ajout_Click(object sender, EventArgs e)
        {
            ajout_per frmAcc = new ajout_per();
            frmAcc.Show();
            this.Hide();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée
            if (dgvPersonnel.CurrentRow == null)
            {
                MessageBox.Show("Veuillez sélectionner un personnel.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Forcer la fin de l'édition en cours
            dgvPersonnel.EndEdit();

            string nom = dgvPersonnel.CurrentRow.Cells["NOM"].Value?.ToString();
            string prenom = dgvPersonnel.CurrentRow.Cells["PRENOM"].Value?.ToString();
            int id = Convert.ToInt32(dgvPersonnel.CurrentRow.Cells["ID_PERSONNEL"].Value);

            var confirm = MessageBox.Show(
                $"Voulez-vous supprimer {prenom} {nom} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string query = "DELETE FROM PERSONNEL WHERE ID_PERSONNEL = @id " +
                    ";DELETE FROM UTILISATEUR  WHERE ID_UTILISATEUR = @id;";
                SqlParameter[] parametres = { new SqlParameter("@id", id) };
                int result = DATABASE.ExecuterRequete(query, parametres);

                if (result > 0)
                {
                    ChargerPersonnel();
                    btnSupprimer.Enabled = false;
                    MessageBox.Show("Personnel supprimé.", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
       
        }
       
        private void recher_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(recher.Text))
            {
                recher.Text = "Recherche par nom ou email";
                recher.ForeColor = Color.Gray;
            }

        }

        private void recher_Enter_1(object sender, EventArgs e)
        {
            if (recher.Text == "Recherche par nom ou email")
            {
                recher.Text = "";
                recher.ForeColor = Color.Black;
            }
        }

        private void recher_TextChanged(object sender, EventArgs e)
        {
            if (recher.Text == "Recherche par nom ou email")
                return;

            string motrecherche = recher.Text.Trim();

            string query = @"SELECT * 
                     FROM PERSONNEL
                     WHERE NOM LIKE @recherche
                     OR MAIL LIKE @recherche";

            SqlParameter[] parametres = { new SqlParameter("@recherche", "%" + motrecherche + "%") };

            DataTable dt = DATABASE.ExecuterSelect(query, parametres);

            dgvPersonnel.DataSource = dt;

        }

        private void gere_per_Load(object sender, EventArgs e)
        {

        }
    }
}

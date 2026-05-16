using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace Restaurant_ihec_carthage.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
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

        private bool mdpVisible = false;
        private void FormLogin_Load(object sender, EventArgs e)
        {
            SetRoundedCorners(btnAdmin, 40);
            SetRoundedCorners(btnPer, 40);
            SetRoundedCorners(btnEt, 40);
            AjouterShadow(btnAdmin);
            AjouterShadow(btnPer);
            AjouterShadow(btnEt);
            eye.Cursor = Cursors.Hand;
            eye.BackColor = Color.Transparent;
           
            txtEmail.Leave += (s, ev) =>
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    txtEmail.Text = "votre.email@ihec.ucar.tn";
                    txtEmail.ForeColor = Color.Gray;
                }
            };
        }
        private void txtEmail_Enter(object sender, EventArgs e)
        {
            
            if (txtEmail.Text == "votre.email@ihec.ucar.tn")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
         
        }

        private void txtMDP_Leave(object sender, EventArgs e)
        {
            if (txtMDP.Text == "")
            {
                txtMDP.Text = "    ●●●●●●●●●●●●●●●●●";
                txtMDP.ForeColor = Color.Gray;
            }
        }

        private void txtMDP_Enter(object sender, EventArgs e)
        {
            if (txtMDP.Text == "    ●●●●●●●●●●●●●●●●●")
            {
                txtMDP.Text = "";
                txtMDP.ForeColor = Color.Black;
            }
        }
        private void AjouterShadow(Button pic)
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

        private void eye_Click(object sender, EventArgs e)
        {
            mdpVisible = !mdpVisible;

            if (mdpVisible)
            {
                txtMDP.PasswordChar = '\0'; //  Mot de passe visible
            }
            else
            {
                txtMDP.PasswordChar = '●'; // Mot de passe invisible
            }
        }

        private async void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            bool isValid = Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@ihec\.ucar\.tn$");
            if (!isValid)
            {
                e.Cancel = true;
                panel1.BackColor = Color.FromArgb(255, 220, 220);
                remarque.Text = "❌ Email doit être de la forme email@ihec.ucar.tn";
                remarque.ForeColor = Color.Red;
                remarque.Visible = true;
                txtEmail.ForeColor = Color.Red;

            }
            else
            {
                e.Cancel = false;
                panel1.BackColor = Color.LightGreen;
                txtEmail.ForeColor = Color.Green;
                remarque.Text = "✅ Email Valide";
                remarque.ForeColor = Color.Green;
                remarque.Visible = true;

                // wait 3s
                await Task.Delay(2000);

                // 
                panel1.BackColor = Color.White;
                txtEmail.ForeColor = Color.Black;
                remarque.Text = "";
                remarque.Visible = false;
            }
        }

       
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtMDP.Text.Trim();


            // Vérifier que les champs ne sont pas vides
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                remarque.Text = "❌ Veuillez remplir tous les champs.";
                remarque.ForeColor = Color.Red;
                remarque.Visible = true;
                return;
            }

            string query = "SELECT COUNT(*) FROM UTILISATEUR WHERE MAIL = @email " +
                "AND MOT_DE_PASSE = @password AND ROLE =@role";

            SqlParameter[] parametres = new SqlParameter[]
            {
                 new SqlParameter("@email", email),
                 new SqlParameter("@password", password),
                 new SqlParameter("@role", "Administrateur")
            };

            try
            {
                //  Utiliser ExecuterSelect de votre classe
                DataTable dt = DATABASE.ExecuterSelect(query, parametres);

                int count = Convert.ToInt32(dt.Rows[0][0]);

                if (count > 0)
                {
                    //  Utilisateur trouvé ouvrir FormAccA
                    FormAccA frmAcc = new FormAccA();
                    frmAcc.Show();
                    this.Hide();
                }
                else
                {
                    // Email ou mot de passe incorrect
                    panel1.BackColor = Color.FromArgb(255, 220, 220);
                    remarque.Text = "❌ Email ou mot de passe incorrect.";
                    remarque.ForeColor = Color.Red;
                    remarque.Visible = true;
                    txtMDP.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPer_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtMDP.Text.Trim();


            //  Vérifier que les champs ne sont pas vides
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                remarque.Text = "❌ Veuillez remplir tous les champs.";
                remarque.ForeColor = Color.Red;
                remarque.Visible = true;
                return;
            }

            string query = "SELECT COUNT(*) FROM UTILISATEUR WHERE MAIL = @email AND MOT_DE_PASSE = @password AND ROLE =@role";

            SqlParameter[] parametres = new SqlParameter[]
            {
                 new SqlParameter("@email", email),
                 new SqlParameter("@password", password),
                 new SqlParameter("@role", "Personnel")
            };

            try
            {
                //  Utiliser ExecuterSelect de votre classe
                DataTable dt = DATABASE.ExecuterSelect(query, parametres);

                int count = Convert.ToInt32(dt.Rows[0][0]);

                if (count > 0)
                {
                    //  Utilisateur trouvé ouvrir FormAccA
                    FormAccP frmAcc = new FormAccP();
                    frmAcc.Show();
                    this.Hide();
                }
                else
                {
                    // Email ou mot de passe incorrect
                    panel1.BackColor = Color.FromArgb(255, 220, 220);
                    remarque.Text = "❌ Email ou mot de passe incorrect.";
                    remarque.ForeColor = Color.Red;
                    remarque.Visible = true;
                    txtMDP.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnEt_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtMDP.Text.Trim();
            Session.EmailE = email;
            Session.MDPE = password;


            //  Vérifier que les champs ne sont pas vides
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                remarque.Text = "❌ Veuillez remplir tous les champs.";
                remarque.ForeColor = Color.Red;
                remarque.Visible = true;
                return;
            }

            string query = "SELECT COUNT(*) FROM UTILISATEUR WHERE MAIL = @email AND MOT_DE_PASSE = @password AND ROLE =@role";

            SqlParameter[] parametres = new SqlParameter[]
            {
                 new SqlParameter("@email", email),
                 new SqlParameter("@password", password),
                 new SqlParameter("@role", "Etudiant")
            };

            try
            {
                //  Utiliser ExecuterSelect de votre classe
                DataTable dt = DATABASE.ExecuterSelect(query, parametres);

                int count = Convert.ToInt32(dt.Rows[0][0]);

                if (count > 0)
                {
                    //  Utilisateur trouvé ouvrir FormAccA
                    FormAccE frmAcc = new FormAccE();
                    frmAcc.Show();
                    this.Hide();
                }
                else
                {
                    // Email ou mot de passe incorrect
                    panel1.BackColor = Color.FromArgb(255, 220, 220);
                    remarque.Text = "❌ Email ou mot de passe incorrect.";
                    remarque.ForeColor = Color.Red;
                    remarque.Visible = true;
                    txtMDP.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

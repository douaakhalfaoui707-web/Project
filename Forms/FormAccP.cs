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
    public partial class FormAccP : Form
    {
        public FormAccP()
        {
            InitializeComponent();
            ChargerMenuDuJour();
            SetRoundedCorners(panel2, 40); AjouterShadow(panel2);
            SetRoundedCorners(panel4, 40); AjouterShadow(panel4);
            SetRoundedCorners(panel5, 40); AjouterShadow(panel5);
            SetRoundedCorners(panel6, 40); AjouterShadow(panel6);
            SetRoundedCorners(panel7, 40); AjouterShadow(panel7);
            SetRoundedCorners(panel9, 40); AjouterShadow(panel9);
            SetRoundedCorners(pictureBox5, 20);
            SetRoundedCorners(pictureBox2, 20);
            SetRoundedCorners(pictureBox1, 20);
            SetRoundedCorners(pictureBox6, 20);
            SetRoundedCorners(panel7, 40); SetRoundedCorners(panel21, 40);
            SetRoundedCorners(panel8, 40); SetRoundedCorners(panel9, 40);
            SetRoundedCorners(panel20, 40); SetRoundedCorners(panel16, 40);
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
        private void ChargerMenuDuJour()
        {
            //  Si dimanche → chercher lundi
            DayOfWeek jourActuel = DateTime.Now.DayOfWeek;
            if (jourActuel == DayOfWeek.Sunday)
                jourActuel = DayOfWeek.Monday;

            //  Mapping DayOfWeek → DATEPART SQL Server (DATEFIRST = 7)
            int jourSQL;
            switch (jourActuel)
            {
                case DayOfWeek.Monday: jourSQL = 2; break;
                case DayOfWeek.Tuesday: jourSQL = 3; break;
                case DayOfWeek.Wednesday: jourSQL = 4; break;
                case DayOfWeek.Thursday: jourSQL = 5; break;
                case DayOfWeek.Friday: jourSQL = 6; break;
                case DayOfWeek.Saturday: jourSQL = 7; break;
                default: jourSQL = 2; break;
            }

            //  Chercher par jour de la semaine, pas par date
            string query = "SET DATEFIRST 7; SELECT * FROM MENU WHERE DATEPART(WEEKDAY, DATE) = @jour";
            SqlParameter[] parametres = new SqlParameter[]
            {
                  new SqlParameter("@jour", jourSQL)
            };

            try
            {
                DataTable dt = DATABASE.ExecuterSelect(query, parametres);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    string idMenu = row["ID_MENU"].ToString();
                    int placesTotal = Convert.ToInt32(row["PLACE"]);

                    //  Compter réservations
                    string queryRes = "SELECT COUNT(*) FROM RESERVATION WHERE ID_MENU = @idMenu";
                    SqlParameter[] pRes = new SqlParameter[]
                    {
                         new SqlParameter("@idMenu", idMenu)
                    };
                    DataTable dtRes = DATABASE.ExecuterSelect(queryRes, pRes);
                    int nbReservations = Convert.ToInt32(dtRes.Rows[0][0]);
                    int placesDisponibles = placesTotal - nbReservations;

                    // Afficher la date et le jour depuis la BD
                    DateTime dateMenu = Convert.ToDateTime(row["DATE"]);
                    string[] nomsJours = { "Dimanche", "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi" };
                    jour.Text = nomsJours[(int)dateMenu.DayOfWeek];
                    date.Text = dateMenu.ToString("dd/MM/yyyy");

                    plat.Text = row["PLAT"].ToString();
                    dessert.Text = row["DESSERT"].ToString();
                    b.Text = row["BOISSON"].ToString();
                    prix.Text = Convert.ToDecimal(row["PRIX"]).ToString("0.00") + " DT";

                    if (placesDisponibles <= 0)
                        places.Text = "Complet";
                    else
                        places.Text = "Disponible   " + placesDisponibles + " places";
                }
                else
                {
                    jour.Text = "Aucun menu";
                    date.Text = "-";
                    plat.Text = "Non disponible";
                    dessert.Text = "Non disponible";
                    b.Text = "Non disponible";
                    prix.Text = "0.00 DT";
                    places.Text = "0 places";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_dec_Click(object sender, EventArgs e)
        {
            FormLogin frmAcc = new FormLogin();
            frmAcc.Show();
            this.Hide();

        }
        private void InitialiserTaches()
        {
            CheckBox[] taches = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6 };

            foreach (CheckBox chk in taches)
            {
                chk.CheckedChanged += (s, e) =>
                {
                    if (chk.Checked)
                    {
                        //  Coché  texte barré + gris
                        chk.Font = new Font(chk.Font, FontStyle.Strikeout);
                        chk.ForeColor = Color.LightGreen;
                    }
                    else
                    {
                        //  Décoché  texte normal
                        chk.Font = new Font(chk.Font, FontStyle.Regular);
                        chk.ForeColor = Color.FromArgb(30, 30, 30);
                    }
                };
            }
        }

        private void FormAccP_Load(object sender, EventArgs e)
        {
            InitialiserTaches();

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

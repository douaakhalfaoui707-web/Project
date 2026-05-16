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
    public partial class gere_menu : Form
    {
        public gere_menu()
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
        private void AjouterShadow(Panel pic)
        {

            Panel shadow = new Panel();
            shadow.Size = new Size(pic.Width, pic.Height);
            shadow.Location = new Point(pic.Left + 4, pic.Top + 4); // décalé de 4px
            shadow.BackColor = Color.FromArgb(80, 0, 0, 0); // noir transparent


            SetRoundedCorners(shadow, 40);


            pic.Parent.Controls.Add(shadow);
            pic.Parent.Controls.SetChildIndex(shadow,
            pic.Parent.Controls.GetChildIndex(pic) + 1); // derrière
        }
        private void ChargerMenuParJour(DayOfWeek jour, Label lblDate, Label lblPlat, Label lblDessert,
                                 Label lblBoisson, Label lblPlaces, Label lblPrix)
        {
            int jourSQL = ((int)jour + 0);
            string query = "SELECT * FROM MENU WHERE DATEPART(WEEKDAY, DATE) = @jour";
            SqlParameter[] parametres = new SqlParameter[] { new SqlParameter("@jour", jourSQL) };

            try
            {
                DataTable dt = DATABASE.ExecuterSelect(query, parametres);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    lblDate.Text = Convert.ToDateTime(row["DATE"]).ToString("dd/MM/yyyy");
                    lblPlat.Text = row["PLAT"].ToString();
                    lblDessert.Text = row["DESSERT"].ToString();
                    lblBoisson.Text = row["BOISSON"].ToString();

                    decimal prix = Convert.ToDecimal(row["PRIX"]);
                    lblPrix.Text = prix.ToString("0.00") + " DT";

                    int places = Convert.ToInt32(row["PLACE"]);
                    lblPlaces.Text = "Disponible                  " + places + " places";
                }
                else
                {
                    lblDate.Text = "Aucun menu";
                    lblPlat.Text = "Non disponible";
                    lblDessert.Text = "Non disponible";
                    lblBoisson.Text = "Non disponible";
                    lblPrix.Text = "0.00 DT";
                    lblPlaces.Text = "0 places";
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

        private void retour_Click(object sender, EventArgs e)
        {
            FormAccE frmAcc = new FormAccE();
            frmAcc.Show();
            this.Hide();

        }

        private void gere_menu_Load(object sender, EventArgs e)
        {
            ChargerMenuParJour(DayOfWeek.Monday, date_lun, plat_lun, des_lun, b_lun, dispo_lun, p_lun);
            ChargerMenuParJour(DayOfWeek.Tuesday, date_mar, plat_mar, des_mar, b_mar, dispo_mar, p_mar);
            ChargerMenuParJour(DayOfWeek.Wednesday, date_mer, plat_mer, des_mer, b_mer, dispo_mer, p_mer);
            ChargerMenuParJour(DayOfWeek.Thursday, date_jeu, plat_jeu, des_jeu, b_jeu, dispo_jeu, p_jeu);
            ChargerMenuParJour(DayOfWeek.Friday, date_vend, plat_ven, des_ven, b_ven, dispo_ven, p_ven);
            ChargerMenuParJour(DayOfWeek.Saturday, date_sam, plat_sam, des_sam, b_sam, dispo_sam, p_sam);
            SetRoundedCorners(panel12, 40); SetRoundedCorners(panel9, 40);
            SetRoundedCorners(panel2, 40); SetRoundedCorners(panel5, 40);
            SetRoundedCorners(panel15, 40); SetRoundedCorners(panel18, 40);
            AjouterShadow(panel12); AjouterShadow(panel9);
            AjouterShadow(panel5); AjouterShadow(panel2);
            AjouterShadow(panel15); AjouterShadow(panel18);

        }

        private void btn_lun_Click(object sender, EventArgs e)
        {
            modifier_menu frmAcc = new modifier_menu();
            frmAcc.Show();
            this.Hide();

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Restaurant_ihec_carthage.Forms
{
    public partial class FormAccA : Form
    {
        public FormAccA()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormAccA_Load(object sender, EventArgs e)
        {
            SetRoundedCorners(panel2, 40); AjouterShadow(panel2); 
            SetRoundedCorners(panel4, 40); AjouterShadow(panel4); SetRoundedCorners(panel5, 40); AjouterShadow(panel5);
            SetRoundedCorners(panel6, 40); AjouterShadow(panel6); SetRoundedCorners(panel8, 40); AjouterShadow(panel8);
            SetRoundedCorners(panel7, 40); AjouterShadow(panel7); SetRoundedCorners(panel14, 40); AjouterShadow(panel14);
            SetRoundedCorners(panel9, 40); AjouterShadow(panel9); SetRoundedCorners(panel10, 40); AjouterShadow(panel10);
            SetRoundedCorners(panel11, 40); AjouterShadow(panel11); SetRoundedCorners(panel12, 40); AjouterShadow(panel12);
            AfficherPieChart();
            SetRoundedCorners(pictureBox7, 20);
            SetRoundedCorners(pictureBox8, 20);
            SetRoundedCorners(pictureBox9, 20);
            SetRoundedCorners(pictureBox1, 20);
            SetRoundedCorners(pictureBox5, 20);
            SetRoundedCorners(pictureBox2, 20);
            SetRoundedCorners(pictureBox6, 20);
            AfficherHistogrammeMenus();

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
        void AfficherPieChart()
        {
            string query = @"SELECT ROLE, COUNT(*) AS NB
                     FROM UTILISATEUR
                     GROUP BY ROLE";

            DataTable dt = DATABASE.ExecuterSelect(query);

            chart1.Series.Clear();

            Series s = new Series("Roles");

            s.ChartType = SeriesChartType.Pie;

            s.IsValueShownAsLabel = true;

            s.Label = "#PERCENT";

            chart1.Palette = ChartColorPalette.Excel;

            foreach (DataRow row in dt.Rows)
            {
                int index = s.Points.AddXY(
                    row["ROLE"].ToString(),
                    row["NB"].ToString()
                );
                s.Points[index].LegendText = row["ROLE"].ToString();
            }

            chart1.Series.Add(s);

            chart1.Titles.Clear();
            

            s["PieLabelStyle"] = "Outside";
        }
        
        void AfficherHistogrammeMenus()
        {
            string query = @"

                        SET LANGUAGE French;

                        SELECT M.ID_MENU, DATENAME(WEEKDAY, M.DATE) AS JOUR, COUNT(R.ID_UTILISATEUR) * 100.0 / (SELECT COUNT(*) FROM RESERVATION) AS POURCENTAGE

                                   FROM MENU M

                        LEFT JOIN RESERVATION R
                        ON M.ID_MENU = R.ID_MENU

                        GROUP BY 
                        M.ID_MENU,
                        DATENAME(WEEKDAY, M.DATE),
                       M.DATE

                      ORDER BY M.DATE

                       ";

            DataTable dt = DATABASE.ExecuterSelect(query);

            chart2.Series.Clear();

            chart2.ChartAreas.Clear();

            chart2.Legends.Clear();

            chart2.ChartAreas.Add(new ChartArea());

            Series s = new Series("Menus");

            s.ChartType = SeriesChartType.Column;

            s.IsValueShownAsLabel = true;

            Random rnd = new Random();

            foreach (DataRow row in dt.Rows)
            {
                double p =
                    Math.Round(
                    Convert.ToDouble(row["POURCENTAGE"]), 2);

                string jour =
                    row["JOUR"].ToString();

                string menu =
                    row["ID_MENU"].ToString();

                int index = s.Points.AddXY(
                    jour,
                    p
                );

                // afficher %
                //s.Points[index].Label = p + " %";

                // couleurs
                s.Points[index].Color = Color.FromArgb(
                    rnd.Next(50, 255),
                    rnd.Next(50, 255),
                    rnd.Next(50, 255)
                );

                // légende
                s.Points[index].LegendText =
                    "Menu " + menu + " - " + jour;
            }

            chart2.Series.Add(s);

            // titre
            chart2.Titles.Clear();

            

            // axes
            chart2.ChartAreas[0].AxisX.Title = "Jour du menu";

            chart2.ChartAreas[0].AxisY.Title = "Pourcentage %";

            // enlever quadrillage
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            // largeur colonnes
            s["PointWidth"] = "0.6";

            // légende
            Legend legend = new Legend();

            legend.Docking = Docking.Right;

            

            chart2.Legends.Add(legend);
        }


       

        private void btn_dec_Click(object sender, EventArgs e)
        {
            FormLogin frmAcc = new FormLogin();
            frmAcc.Show();
            this.Hide();

        }

        private void btn_ut_Click(object sender, EventArgs e)
        {
            gere_utilisateur frmAcc = new gere_utilisateur();
            frmAcc.Show();
            this.Hide();
        }

        

        private void gere_per_Click(object sender, EventArgs e)
        {
            gere_per frmAcc = new gere_per();
            frmAcc.Show();
            this.Hide();


        }

        
        private void gere_menu_Click(object sender, EventArgs e)
        {
            gere_menu frmAcc = new gere_menu();
            frmAcc.Show();
            this.Hide();
        }
    }
}

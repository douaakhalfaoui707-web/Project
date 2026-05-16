using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_ihec_carthage.Forms
{
    public partial class FormAccE : Form
    {
        public FormAccE()
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
        private void FormAccE_Load(object sender, EventArgs e)
        {
            ChargerMenuParJour(DayOfWeek.Monday, date_lun, plat_lun, des_lun, b_lun, dispo_lun, p_lun, l_b, l_p, l_d, l_px, btn_lun, lun_ann, lun_con);
            ChargerMenuParJour(DayOfWeek.Tuesday, date_mar, plat_mar, des_mar, b_mar, dispo_mar, p_mar, m_b, m_p, m_d, m_px, btn_mar, mar_ann, mar_con);
            ChargerMenuParJour(DayOfWeek.Wednesday, date_mer, plat_mer, des_mer, b_mer, dispo_mer, p_mer, r_b, r_p, r_d, r_px, btn_mer, mer_ann, mer_con);
            ChargerMenuParJour(DayOfWeek.Thursday, date_jeu, plat_jeu, des_jeu, b_jeu, dispo_jeu, p_jeu, j_b, j_p, j_d, j_px, btn_jeu, jeu_ann, jeu_con);
            ChargerMenuParJour(DayOfWeek.Friday, date_vend, plat_ven, des_ven, b_ven, dispo_ven, p_ven, v_b, v_p, v_d, v_px, btn_ven, ven_ann, ven_con);
            ChargerMenuParJour(DayOfWeek.Saturday, date_sam, plat_sam, des_sam, b_sam, dispo_sam, p_sam, s_b, s_p, s_d, s_px, btn_sam, sam_ann, sam_con);

            SetRoundedCorners(panel12, 40); SetRoundedCorners(panel9, 40);
            SetRoundedCorners(panel2, 40); SetRoundedCorners(panel5, 40);
            SetRoundedCorners(panel15, 40); SetRoundedCorners(panel18, 40);
            AjouterShadow(panel12); AjouterShadow(panel9);
            AjouterShadow(panel5); AjouterShadow(panel2);
            AjouterShadow(panel15); AjouterShadow(panel18);
            SetRoundedCorners(panel21, 40); SetRoundedCorners(panel23, 40);
            SetRoundedCorners(panel25, 40); SetRoundedCorners(panel27, 40);
            SetRoundedCorners(panel31, 40); SetRoundedCorners(panel29, 40);
            AjouterShadow(panel21); AjouterShadow(panel23);
            AjouterShadow(panel25); AjouterShadow(panel27);
            AjouterShadow(panel31); AjouterShadow(panel29);
        }

        // ✅ CORRIGÉ : stocke ID par jour
        private void ChargerMenuParJour(DayOfWeek jour, Label lblDate, Label lblPlat, Label lblDessert,
                                         Label lblBoisson, Label lblPlaces, Label lblPrix,
                                         Label BoissonRes, Label PlatRes, Label DessertRes, Label PrixRes,
                                         Button btnReserver, Button btnAnnuler, Label lblStatut)
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
                    PlatRes.Text = lblPlat.Text;
                    DessertRes.Text = lblDessert.Text;
                    BoissonRes.Text = lblBoisson.Text;

                    decimal prix = Convert.ToDecimal(row["PRIX"]);
                    lblPrix.Text = prix.ToString("0.00") + " DT";
                    PrixRes.Text = lblPrix.Text;

                    int places = Convert.ToInt32(row["PLACE"]);
                    lblPlaces.Text = "Disponible                  " + places + " places";

                    //  Stocker ID par jour
                    string idMenu = row["ID_MENU"].ToString();
                    if (jour == DayOfWeek.Monday) Session.IDMENU_LUN = idMenu;
                    if (jour == DayOfWeek.Tuesday) Session.IDMENU_MAR = idMenu;
                    if (jour == DayOfWeek.Wednesday) Session.IDMENU_MER = idMenu;
                    if (jour == DayOfWeek.Thursday) Session.IDMENU_JEU = idMenu;
                    if (jour == DayOfWeek.Friday) Session.IDMENU_VEN = idMenu;
                    if (jour == DayOfWeek.Saturday) Session.IDMENU_SAM = idMenu;

                    if (places <= 0)
                    {
                        btnReserver.Enabled = false; btnReserver.BackColor = Color.Gray; btnReserver.Text = "Complet";
                        btnAnnuler.Enabled = false; btnAnnuler.BackColor = Color.Gray;
                        lblStatut.Visible = false;
                        PlatRes.Visible = false; DessertRes.Visible = false;
                        BoissonRes.Visible = false; PrixRes.Visible = false;
                    }
                    else if (VerifierReservationExiste(idMenu))
                    {
                        ActiverPanel(btnReserver, btnAnnuler, lblStatut, PlatRes, DessertRes, BoissonRes, PrixRes);
                    }
                    else
                    {
                        DesactiverPanel(btnReserver, btnAnnuler, lblStatut, PlatRes, DessertRes, BoissonRes, PrixRes);
                    }
                }
                else
                {
                    lblDate.Text = "Aucun menu"; lblPlat.Text = "Non disponible";
                    lblDessert.Text = "Non disponible"; lblBoisson.Text = "Non disponible";
                    lblPrix.Text = "0.00 DT"; lblPlaces.Text = "0 places";
                    btnReserver.Enabled = false; btnReserver.BackColor = Color.Gray; btnReserver.Text = "Complet";
                    btnAnnuler.Enabled = false; btnAnnuler.BackColor = Color.Gray;
                    lblStatut.Visible = false;
                    PlatRes.Visible = false; DessertRes.Visible = false;
                    BoissonRes.Visible = false; PrixRes.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  CORRIGÉ : même signature pour ActiverPanel et DesactiverPanel
        private void ActiverPanel(Button btnReserver, Button btnAnnuler, Label lblStatut,
                                   Label PlatRes, Label DessertRes, Label BoissonRes, Label PrixRes)
        {
            btnReserver.Enabled = false;
            btnReserver.BackColor = Color.Gray;

            btnAnnuler.Enabled = true;
            btnAnnuler.BackColor = Color.LightCoral;

            lblStatut.Visible = true;
            PlatRes.Visible = true;
            DessertRes.Visible = true;
            BoissonRes.Visible = true;
            PrixRes.Visible = true;
        }

        private void DesactiverPanel(Button btnReserver, Button btnAnnuler, Label lblStatut,
                                      Label PlatRes, Label DessertRes, Label BoissonRes, Label PrixRes)
        {
            btnReserver.Enabled = true;
            btnReserver.BackColor = Color.MediumPurple;

            btnAnnuler.Enabled = false;
            btnAnnuler.BackColor = Color.Gray;

            lblStatut.Visible = false;
            PlatRes.Visible = false;
            DessertRes.Visible = false;
            BoissonRes.Visible = false;
            PrixRes.Visible = false;
        }

        private bool VerifierReservationExiste(string idMenu)
        {
            string query = "SELECT COUNT(*) FROM RESERVATION WHERE ID_UTILISATEUR = @idUser AND ID_MENU = @idMenu";
            SqlParameter[] p = new SqlParameter[]
            {
        new SqlParameter("@idUser", Session.IdEtudiant),
        new SqlParameter("@idMenu", idMenu)
            };
            DataTable dt = DATABASE.ExecuterSelect(query, p);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        

        // 
        private void InsererReservation(string idMenu)
        {
            string query = "INSERT INTO RESERVATION (ID_UTILISATEUR, ID_MENU, DATE, PLACE) VALUES (@idUser," +
                " @idMenu, @date, @place)";
            SqlParameter[] p = new SqlParameter[]
            {
                new SqlParameter("@idUser", Session.IdEtudiant),
                new SqlParameter("@idMenu", idMenu),
                new SqlParameter("@date",   DateTime.Now.Date),
                new SqlParameter("@place",  "1")
            };
            DATABASE.ExecuterRequete(query, p);
        }

        private void SupprimerReservation(string idMenu)
        {
            string query = "DELETE FROM RESERVATION WHERE ID_UTILISATEUR = @idUser AND ID_MENU = @idMenu";
            SqlParameter[] p = new SqlParameter[]
            {
                 new SqlParameter("@idUser", Session.IdEtudiant),
                 new SqlParameter("@idMenu", idMenu)
            };
            DATABASE.ExecuterRequete(query, p);
        }
       
        

        private void btn_dec_Click_1(object sender, EventArgs e)
        {
            FormLogin frmAcc = new FormLogin();
            frmAcc.Show();
            this.Hide();

        }
        private void btn_lun_Click(object sender, EventArgs e)
        {
            InsererReservation(Session.IDMENU_LUN);
            ActiverPanel(btn_lun, lun_ann, lun_con, l_p, l_d, l_b, l_px);
        }


        private void btn_mar_Click_1(object sender, EventArgs e)
        {
            InsererReservation(Session.IDMENU_MAR);
            ActiverPanel(btn_mar, mar_ann, mar_con, m_p, m_d, m_b, m_px);
        }

        private void btn_mer_Click_1(object sender, EventArgs e)
        {
            InsererReservation(Session.IDMENU_MER);
            ActiverPanel(btn_mer, mer_ann, mer_con, r_p, r_d, r_b, r_px);
        }

        private void btn_jeu_Click_1(object sender, EventArgs e)
        {
            InsererReservation(Session.IDMENU_JEU);
            ActiverPanel(btn_jeu, jeu_ann, jeu_con, j_p, j_d, j_b, j_px);
        }

        private void btn_ven_Click_1(object sender, EventArgs e)
        {
            InsererReservation(Session.IDMENU_VEN);
            ActiverPanel(btn_ven, ven_ann, ven_con, v_p, v_d, v_b, v_px);
        }

        private void btn_sam_Click_1(object sender, EventArgs e)
        {
            InsererReservation(Session.IDMENU_SAM);
            ActiverPanel(btn_sam, sam_ann, sam_con, s_p, s_d, s_b, s_px);
        }
        private void lun_ann_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmer l'annulation ?", "Annulation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SupprimerReservation(Session.IDMENU_LUN);
            DesactiverPanel(btn_lun, lun_ann, lun_con, l_p, l_d, l_b, l_px);
        }
        private void mar_ann_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmer l'annulation ?", "Annulation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SupprimerReservation(Session.IDMENU_MAR);
            DesactiverPanel(btn_mar, mar_ann, mar_con, m_p, m_d, m_b, m_px);
        }

        private void mer_ann_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmer l'annulation ?", "Annulation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SupprimerReservation(Session.IDMENU_MER);
            DesactiverPanel(btn_mer, mer_ann, mer_con, r_p, r_d, r_b, r_px);
        }

        private void jeu_ann_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmer l'annulation ?", "Annulation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SupprimerReservation(Session.IDMENU_JEU);
            DesactiverPanel(btn_jeu, jeu_ann, jeu_con, j_p, j_d, j_b, j_px);
        }

        private void ven_ann_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmer l'annulation ?", "Annulation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SupprimerReservation(Session.IDMENU_VEN);
            DesactiverPanel(btn_ven, ven_ann, ven_con, v_p, v_d, v_b, v_px);
        }

        private void sam_ann_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmer l'annulation ?", "Annulation", MessageBoxButtons.YesNo) == DialogResult.No) return;
            SupprimerReservation(Session.IDMENU_SAM);
            DesactiverPanel(btn_sam, sam_ann, sam_con, s_p, s_d, s_b, s_px);
        }
    }
    
}

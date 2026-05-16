using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurant_ihec_carthage.Forms
{
    public partial class modifier_menu : Form
    {
        public modifier_menu()
        {
            InitializeComponent();
            plat.Enter += (s, e) => { if (plat.Text == "nom du plat") plat.Text = ""; };
            dessert.Enter += (s, e) => { if (dessert.Text == "nom de dessert") dessert.Text = ""; };
            boisson.Enter += (s, e) => { if (boisson.Text == "nom de boisson") boisson.Text = ""; };
            Prix.Enter += (s, e) => { if (Prix.Text == "prix en dt") Prix.Text = ""; };
            places.Enter += (s, e) => { if (places.Text == "nombre de place") places.Text = ""; };

            
            plat.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(plat.Text)) plat.Text = "nom du plat"; };
            dessert.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(dessert.Text)) dessert.Text = "nom de dessert"; };
            boisson.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(boisson.Text)) boisson.Text = "nom de boisson"; };
            Prix.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(Prix.Text)) Prix.Text = "prix en dt"; };
            places.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(places.Text)) places.Text = "nombre de place"; };
        }

        private void plat_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(plat.Text))
                plat.Text = char.ToUpper(plat.Text[0]) + plat.Text.Substring(1).ToLower();
        }

        private void dessert_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(dessert.Text))
                dessert.Text = char.ToUpper(dessert.Text[0]) + dessert.Text.Substring(1).ToLower();
        }

        private void boisson_Leave(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(boisson.Text))
                boisson.Text = char.ToUpper(boisson.Text[0]) + boisson.Text.Substring(1).ToLower();
        }
        private bool ValiderJourEtDate()
        {
            DayOfWeek jourChoisi;
            switch (jour.SelectedItem.ToString())
            {
                case "Lundi": jourChoisi = DayOfWeek.Monday; break;
                case "Mardi": jourChoisi = DayOfWeek.Tuesday; break;
                case "Mercredi": jourChoisi = DayOfWeek.Wednesday; break;
                case "Jeudi": jourChoisi = DayOfWeek.Thursday; break;
                case "Vendredi": jourChoisi = DayOfWeek.Friday; break;
                case "Samedi": jourChoisi = DayOfWeek.Saturday; break;
                default: jourChoisi = DayOfWeek.Monday; break;
            }

            if (date.Value.DayOfWeek != jourChoisi)
            {
                MessageBox.Show(
                    "La date choisie ne correspond pas au jour " + date.ToString() + ".",
                    "Date invalide",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void valider_Click(object sender, EventArgs e)
        {
            // si vide 
            if (string.IsNullOrWhiteSpace(plat.Text) ||
                string.IsNullOrWhiteSpace(dessert.Text) ||
                string.IsNullOrWhiteSpace(boisson.Text) ||
                string.IsNullOrWhiteSpace(Prix.Text) ||
                string.IsNullOrWhiteSpace(places.Text) ||
                jour.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Champs vides",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(Prix.Text, out decimal prix))
            {
                MessageBox.Show("Le prix doit être un nombre valide.", "Prix invalide",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Prix.Focus();
                return;
            }

            if (!int.TryParse(places.Text, out int place))
            {
                MessageBox.Show("Les places doivent être un nombre entier.", "Places invalides",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                places.Focus();
                return;
            }

            if (!ValiderJourEtDate()) return;

            // 
            int jourSQL;
            switch (jour.SelectedItem.ToString())
            {
                case "Lundi": jourSQL = 2; break;
                case "Mardi": jourSQL = 3; break;
                case "Mercredi": jourSQL = 4; break;
                case "Jeudi": jourSQL = 5; break;
                case "Vendredi": jourSQL = 6; break;
                case "Samedi": jourSQL = 7; break;
                default: jourSQL = 2; break;
            }

            // 
            DataTable dtMenu = DATABASE.ExecuterSelect(
                "SET DATEFIRST 7; SELECT ID_MENU FROM MENU WHERE DATEPART(WEEKDAY, DATE) = @jour",
                new SqlParameter[] { new SqlParameter("@jour", jourSQL) });

            if (dtMenu.Rows.Count == 0)
            {
                MessageBox.Show("Aucun menu trouvé pour ce jour.", "Introuvable",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idMenu = dtMenu.Rows[0]["ID_MENU"].ToString(); 

            try
            {
                string query = @"SET DATEFIRST 7;
                  UPDATE MENU SET
                 PLAT    = @plat,
                 DESSERT = @dessert,
                 BOISSON = @boisson,
                 PRIX    = @prix,
                 PLACE   = @place,
                 DATE    = @date
                   WHERE DATEPART(WEEKDAY, DATE) = @jour";

                SqlParameter[] p = new SqlParameter[]
                {
                      new SqlParameter("@plat",    plat.Text),
                      new SqlParameter("@dessert", dessert.Text),
                      new SqlParameter("@boisson", boisson.Text),
                      new SqlParameter("@prix",    prix),    
                      new SqlParameter("@place",   place),   
                      new SqlParameter("@date",    date.Value.Date),
                      new SqlParameter("@jour",    jourSQL)
                };

                int lignesModifiees = DATABASE.ExecuterRequete(query, p);

                if (lignesModifiees > 0)
                {
                    
                    DATABASE.ExecuterRequete(
                        "DELETE FROM RESERVATION WHERE ID_MENU = @idMenu",
                        new SqlParameter[] { new SqlParameter("@idMenu", idMenu) });

                    MessageBox.Show("Menu modifié avec succès !", "Succès",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Aucun menu trouvé pour ce jour.", "Introuvable",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void annuler_Click(object sender, EventArgs e)
        {
            gere_menu frmAcc = new gere_menu();
            frmAcc.Show();
            this.Hide();
        }
    }

}

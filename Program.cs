using Restaurant_ihec_carthage.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_ihec_carthage
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ✅ TEST DE CONNEXION
            if (DATABASE.TesterConnexion())
            {
                MessageBox.Show("✅ Connexion à la base de données réussie !",
                               "Succès",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                Application.Run(new FormLogin()); // lance l'app
            }
            else
            {
                MessageBox.Show("❌ Impossible de se connecter à la base de données !",
                               "Erreur",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }
    }
}

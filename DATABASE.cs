using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_ihec_carthage
{
    internal class DATABASE
    {
        private static string connectionString =
            "Data Source=DESKTOP-6G7HV92\\PROJECT;" +
            "Initial Catalog=RESTAURANT;" +
            "Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        
        // testt
        
        public static bool TesterConnexion()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true; // Connexion réussie
                }
            }
            catch
            {
                return false; // Connexion échouée
            }
        }
        // select
        public static DataTable ExecuterSelect(string query, SqlParameter[] parametres = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parametres != null)
                    cmd.Parameters.AddRange(parametres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt; 
        } 
        // insertion update supprimer 
        
        public static int ExecuterRequete(string query, SqlParameter[] parametres = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parametres != null)
                    cmd.Parameters.AddRange(parametres);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}

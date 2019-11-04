using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Navigation;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Laborki.Classes
{
    class DatabaseClass
    {

        public static string getConnectionString()
        {
            string strConString = ConfigurationManager.ConnectionStrings["conStringDB"].ToString();
            return strConString;
        }

        public static string sql;
        public static SqlConnection con = new SqlConnection();
        public static SqlCommand cmd = new SqlCommand("", con);
        public static SqlDataReader rd;
        public static DataTable dt;
        public static SqlDataAdapter da;

        public static void openConnection()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.ConnectionString = getConnectionString();
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Description: " + ex.Message.ToString(), "Failed to establish SQL Server connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Description: " + ex.Message.ToString(), "Failed to close SQL Server connection", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void saveToDB(string category, string subcategory, string from, string to, double initial, double result)
        {
            try
            {
                DateTime date = DateTime.Now;

                if (category == "Temperatura")
                {
                    subcategory = "null";
                }

                DatabaseClass.openConnection();

                DatabaseClass.sql = "INSERT into jipp values(@cat, @subcat, @from, @to, @date, @initial, @result)";
                DatabaseClass.cmd.CommandText = DatabaseClass.sql;

                DatabaseClass.cmd.Parameters.AddWithValue("@cat", category);
                DatabaseClass.cmd.Parameters.AddWithValue("@subcat", subcategory);
                DatabaseClass.cmd.Parameters.AddWithValue("@from", from);
                DatabaseClass.cmd.Parameters.AddWithValue("@to", to);
                DatabaseClass.cmd.Parameters.AddWithValue("@date", date);
                DatabaseClass.cmd.Parameters.AddWithValue("@initial", initial);
                DatabaseClass.cmd.Parameters.AddWithValue("@result", result);

                int a = DatabaseClass.cmd.ExecuteNonQuery();

                if (a != 1)
                {
                    MessageBox.Show("Coś... Coś sie popsuło i nie zapisałem danych do bazy :c");
                }

                // DatabaseClass.cmd.Parameters.Add(new SqlParameter("@subcat", ""));

                DatabaseClass.cmd.Parameters.Clear();

                DatabaseClass.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Description: " + ex.Message.ToString(), "Failed to insert data to database", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void showDB()
        {
            DatabaseClass.openConnection();

            DatabaseClass.sql = "SELECT * FROM jipp";
            DatabaseClass.cmd.CommandType = CommandType.Text;
            DatabaseClass.cmd.CommandText = DatabaseClass.sql;

            DatabaseClass.da = new SqlDataAdapter(DatabaseClass.cmd);
            DatabaseClass.dt = new DataTable();
            DatabaseClass.da.Fill(DatabaseClass.dt);

            ShowDB.DbWindow.DataGridShowDB.ItemsSource = DatabaseClass.dt.DefaultView;

            DatabaseClass.closeConnection();
        }

    }
}

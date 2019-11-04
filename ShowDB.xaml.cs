using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Configuration;

using System.Data;
using System.Data.SqlClient;
using Laborki.Classes;

namespace Laborki
{
    /// <summary>
    /// Interaction logic for ShowDB.xaml
    /// </summary>
    public partial class ShowDB : Window
    {
        public static ShowDB DbWindow;
        public ShowDB()
        {
            InitializeComponent();
            DbWindow = this;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            if (ConfigurationManager.AppSettings["Database"] == "AzureStorage")
            {
                AzureDatabaseClass AzureDatabaseClass = new AzureDatabaseClass();
                AzureDatabaseClass.showDB();
            } else
            {
                DatabaseClass DatabaseClass = new DatabaseClass();
                DatabaseClass.showDB();
            }


        }
    }
}

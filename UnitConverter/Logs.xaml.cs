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
using UnitConverter.DataBase;

namespace UnitConverter
{
    /// <summary>
    /// Logika interakcji dla klasy Logs.xaml
    /// </summary>
    public partial class Logs : Window
    {
        private Manager m = MainWindow.GetManager();
        
        public Logs()
        {
            InitializeComponent();


            using(DatabaseContext context = new DatabaseContext())
            {


                LogsGrid.ItemsSource = m.GetRepository().GetStatistics();
            }
            

        }
    }
}

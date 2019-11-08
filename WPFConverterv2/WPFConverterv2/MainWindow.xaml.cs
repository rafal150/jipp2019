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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFConverterv2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public static DataGrid datagrid;
        private IStatisticsRepository repository;

        public MainWindow(IStatisticsRepository repo)
        {
            InitializeComponent();
            Load();
            this.repository = repo;

            myDataGrid.ItemsSource = this.repository.GetStatistics();
            datagrid = myDataGrid;

        }

        private void Load()
        {
           

        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage Ipage = new InsertPage(repository);
            Ipage.ShowDialog();
        }
        
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            ///int Id = (myDataGrid.SelectedItem as members).id;
            //var deleteMember = _db.members.Where(m => m.id == Id).Single();
            //_db.members.Remove(deleteMember);
            //_db.SaveChanges();
            //myDataGrid.ItemsSource = _db.members.ToList();
            
        }
    }
}

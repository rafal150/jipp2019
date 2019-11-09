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

namespace UnitsConverter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.converterMain.ItemsSource = Listy.TypeList;
        

            this.LoadStatistics();
        }

        private void LoadStatistics()
        {
            List<masterEntities> masterEntities = null;

            using (ConverterContext context = new ConverterContext())
            {
               masterEntities = context.masterEntities.ToList();
            }

            this.statisticsDataGrid.ItemsSource = masterEntities;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ResultTextblock.Text =  ((int.Parse(this.InputTextBox.Text)) * 20).
              ToString();

            using(ConverterContext context = new ConverterContext())
            {
                masterEntities st = new masterEntities()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = this.FromCombobox.SelectedItem.ToString(),
                    Type = "Temperatura"
                };

                context.masterEntities.Add(st);
                context.SaveChanges();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.converterMain.SelectedItem == "temperatura")
            {
                this.FromCombobox.ItemsSource = Listy.TypeList;
                this.ToCombobox.ItemsSource = Listy.TypeList;
            }
            else if (this.converterMain.SelectedItem == "długość")
            {
                this.FromCombobox.ItemsSource = Listy.Longlist;
                this.ToCombobox.ItemsSource = Listy.Longlist;
            }
            else if (this.converterMain.SelectedItem == "masa")
            {
                this.FromCombobox.ItemsSource = Listy.WageList;
                this.ToCombobox.ItemsSource = Listy.WageList;
            };
        }
    }
}

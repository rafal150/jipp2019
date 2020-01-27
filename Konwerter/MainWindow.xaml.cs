using System;
using System.Collections.Generic;
using System.Configuration;
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
using Konwerter.Services;

namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(KonwerterServices conv)
        {
            InitializeComponent();
            this.loadStat();
            this.categoryComboBox.ItemsSource = conv.GetConverters();
        }

        private void categoryChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.categoryComboBox.SelectedItem != null)
            {
                this.UnitFromComboBox.ItemsSource = ((IKonwerter)this.categoryComboBox.SelectedItem).Units;
                this.UnitToComboBox.ItemsSource = ((IKonwerter)this.categoryComboBox.SelectedItem).Units;
            }
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.categoryComboBox.SelectedItem != null)
            {
                IKonwerter converter = (IKonwerter)this.categoryComboBox.SelectedItem;
                double result = converter.Convert(
                    this.UnitFromComboBox.SelectedItem.ToString(),
                    this.UnitToComboBox.SelectedItem.ToString(),
                    Convert.ToDouble(decimal.Parse(this.inputTextBox.Text)));

                this.resultLabel.Content = result.ToString();

                using (Model db = new Model())
                {
                    STATISTICS st = new STATISTICS()
                    {
                        CONVERTED_FROM_VAL = Convert.ToDouble(decimal.Parse(this.inputTextBox.Text)),
                        CONVERTED_TO_VAL = (float)result,
                        CONVERTED_FROM = this.UnitFromComboBox.SelectedItem.ToString(),
                        CONVERTED_TO = this.UnitToComboBox.SelectedItem.ToString(),
                        DATE = DateTime.Now,
                        TYPE = converter.Name.ToString()
                    };

                    db.STATISTICS.Add(st);
                    db.SaveChanges();
                }
                this.loadStat();
            }
        }

        

        public void loadStat()
        {
            List<STATISTICS> stat;
            using (Model db = new Model())
            {
                stat = db.STATISTICS.ToList();
            }
            this.statDataGrid.ItemsSource = stat;
        
        }

        private void WebKonwerterButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:53488/");
        }
    }
}

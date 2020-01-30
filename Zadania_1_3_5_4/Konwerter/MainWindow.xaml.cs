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
                    Convert.ToDouble(double.Parse(this.inputTextBox.Text)));

                this.resultLabel.Content = result.ToString();

              using (Model db = new Model())
                {
                    Kalkulator st = new Kalkulator()
                    {
                        Rodzaj = converter.Name.ToString(),
                        JednostkaWyjsciowa = this.UnitFromComboBox.SelectedItem.ToString(),
                        Wartosc = Convert.ToDouble(decimal.Parse(this.inputTextBox.Text)),
                        JednostkaDocelowa = this.UnitToComboBox.SelectedItem.ToString(),
                        Przekonwertowane = (float)result,
                        Data = DateTime.Now
                       
                    };

                    db.Kalkulator.Add(st);
                    db.SaveChanges();
                }
                this.loadStat(); 
            }
        }

        

        public void loadStat()
        {
            List<Kalkulator> stat;
            using (Model db = new Model())
            {
                stat = db.Kalkulator.ToList();
            }
            this.statDataGrid.ItemsSource = stat; 
        
        }
        
        private void WebKonwerterButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:43378/");
        }
    }
}

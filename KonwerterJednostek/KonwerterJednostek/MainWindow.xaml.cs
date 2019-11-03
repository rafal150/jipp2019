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

namespace KonwerterJednostek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FromCombox.ItemsSource = new List<string>(new[] { "C", "K", "F", "R" });

            this.LoadStatistics();
        }

        private void LoadStatistics()
        {
            List<Statistic> statistics = null;

            using (Converter context = new Converter())
            {
                statistics = context.Statistics.ToList();
            }

            this.StatisticsDataGrid.ItemsSource = statistics;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ResultTextBlock.Text = (int.Parse(this.InputTextbox.Text) * 2).ToString();

            using (Converter context = new Converter())
            {
                Statistic st = new Statistic()
                {
                    DateTime = DateTime.Now,
                    ValueToConvert = int.Parse(this.InputTextbox.Text),
                    ConvertedValue = 20,
                };

                context.Statistics.Add(st);
                context.SaveChanges();
            }
        }
    }
}

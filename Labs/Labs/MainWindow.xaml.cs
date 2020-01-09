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
using System.Configuration;
using Labs.Converters;

namespace Labs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private InterfaceRepository repository;
        private ConvertersApi converters;

        public MainWindow(ConvertersApi converters)
        {
            InitializeComponent();

            this.converters = converters;
            //this.repository = repo;
            this.DataGridData.ItemsSource = converters.GetValues();
            this.ComboBoxCategory.ItemsSource = converters.GetConverters();

            //MessageBox.Show("asdasd");
        }



        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBoxCategory.SelectedItem != null)
            {
                this.ComboBoxConvertFrom.ItemsSource = ((Converter)this.ComboBoxCategory.SelectedItem).Units;
                this.ComboBoxConvertTo.ItemsSource = ((Converter)this.ComboBoxCategory.SelectedItem).Units;
            }
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (this.ComboBoxCategory.SelectedItem != null)
            {
                Converter converter = (Converter)this.ComboBoxCategory.SelectedItem;
                decimal result = converters.Convert(
                    this.ComboBoxConvertFrom.SelectedItem.ToString(),
                    this.ComboBoxConvertTo.SelectedItem.ToString(),
                    this.TextBoxFrom.Text,
                    converter.Name);

                this.TextBoxResult.Text = result.ToString();

            }
        }
    }
}

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
        private InterfaceRepository repository;
        public MainWindow(InterfaceRepository repo, SConverters converters)
        {
            InitializeComponent();

            this.repository = repo;
            this.ComboBoxCategory.ItemsSource = converters.GetConverters();
            this.DataGridData.ItemsSource = repository.GetValues();

            //MessageBox.Show("asdasd");
        }



        private void ComboBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ComboBoxCategory.SelectedItem != null)
            {
                this.ComboBoxConvertFrom.ItemsSource = ((IConverter)this.ComboBoxCategory.SelectedItem).Units;
                this.ComboBoxConvertTo.ItemsSource = ((IConverter)this.ComboBoxCategory.SelectedItem).Units;
            }
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (this.ComboBoxCategory.SelectedItem != null)
            {
                IConverter conv = (IConverter)this.ComboBoxCategory.SelectedItem;
                double result = conv.Convert(this.ComboBoxConvertFrom.SelectedItem.ToString(), this.ComboBoxConvertTo.SelectedItem.ToString(), System.Convert.ToDouble(this.TextBoxFrom.Text));
                this.TextBoxResult.Text = result.ToString();

                Values values = new Values()
                {
                    DateTime = DateTime.Now,
                    category = ComboBoxCategory.SelectedItem.ToString(),
                    from = ComboBoxConvertFrom.SelectedItem.ToString(),
                    to = ComboBoxConvertTo.SelectedItem.ToString(),
                    initial = Double.Parse(TextBoxFrom.Text),
                    converted = Double.Parse(TextBoxResult.Text)
                };

                this.repository.AddCalcs(values);
                this.DataGridData.ItemsSource = repository.GetValues();
                
            }
        }
    }
}

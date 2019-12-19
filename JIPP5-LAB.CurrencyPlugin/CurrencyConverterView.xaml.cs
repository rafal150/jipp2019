using JIPP5_LAB.SDK;
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

namespace JIPP5_LAB.Plugin
{
    /// <summary>
    /// Interaction logic for EnergyConverterView.xaml
    /// </summary>
    public partial class CurrencyConverterView : UserControl, IView
    {
        private IConverterHelper ConverterHelper;

        public CurrencyConverterView()
        {
            InitializeComponent();
            ConverterHelper = new CurrencyConverterHelper();
            FromUnit.ItemsSource = ConverterHelper.UnitTypes;
            ToUnit.ItemsSource = ConverterHelper.UnitTypes;
        }

        public string Header => "Konwerter Walut";

        public event EventHandler<StatisticsDTO> ConvertedValueCompleted;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(FromInput.Text, out decimal result);
            ToResult.Text = new CurrencyConverterHelper().Convert(FromUnit.SelectedValue.ToString(), result, ToUnit.SelectedValue.ToString(), out decimal convertedValue);
            var stats = new StatisticsDTO()
            {
                Date = DateTime.Now,
                FromUnit = FromUnit.SelectedValue.ToString(),
                RawData = result,
                ToUnit = ToUnit.SelectedValue.ToString(),
                Converted = convertedValue
            };
            ConvertedValueCompleted.Invoke(this, stats);
        }
    }
}

using JIPP5_LAB.Constants;
using JIPP5_LAB.Helpers;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.Models;
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
using Unity;

namespace JIPP5_LAB.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LengthConverterView.xaml
    /// </summary>
    public partial class LengthConverterView : UserControl, ILengthConverterView
    {
        IDataHelper DataHelper { get; }
        IUnityContainer Container { get; }
        IConverterHelper ConverterHelper { get; }
        public LengthConverterView(IDataHelper dataHelper, IConverterHelper converterHelper, IUnityContainer unityContainer)
        {
            InitializeComponent();
            DataHelper = dataHelper;
            ConverterHelper = converterHelper;
            Container = unityContainer;
            var units = new List<Unit>() {
                ItemRepository.Milimeter,
                ItemRepository.Centymeter,
                ItemRepository.Meter,
                ItemRepository.Kilometer,
                ItemRepository.Cable,
                ItemRepository.Decimeter,
                ItemRepository.Foot,
                ItemRepository.Inch,
                ItemRepository.Mile,
                ItemRepository.NauticalMile,
                ItemRepository.Yard
            };
            FromUnit.ItemsSource = units;
            ToUnit.ItemsSource = units;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var fromUnit = FromUnit.SelectedItem as Unit;
            var toUnit = ToUnit.SelectedItem as Unit;
            decimal.TryParse(FromInput.Text, out decimal result);
            ToResult.Text = ConverterHelper.Convert(fromUnit, result, toUnit);
        }
    }
}

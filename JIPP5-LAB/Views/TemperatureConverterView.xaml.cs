using JIPP5_LAB.Constants;
using JIPP5_LAB.Interfaces;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace JIPP5_LAB.Views
{
    /// <summary>
    /// Interaction logic for TemperatureConverter.xaml
    /// </summary>
    public partial class TemperatureConverterView : UserControl, IView
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }
        private IConverterHelper ConverterHelper { get; }

        public string Header => UIElements.TemperatureConverter;

        public TemperatureConverterView(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            InitializeComponent();
            DataHelper = dataHelper;
            Container = unityContainer;
            ConverterHelper = Container.Resolve<IConverterHelper>("TemperatureConverterHelper");
            FromUnit.ItemsSource = ConverterHelper.UnitTypes;
            ToUnit.ItemsSource = ConverterHelper.UnitTypes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(FromInput.Text, out decimal result);
            ToResult.Text = ConverterHelper.Convert(FromUnit.SelectedValue.ToString(), result, ToUnit.SelectedValue.ToString());
        }
    }
}
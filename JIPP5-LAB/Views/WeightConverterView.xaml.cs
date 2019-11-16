using JIPP5_LAB.Constants;
using JIPP5_LAB.DataProviders;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace JIPP5_LAB.Views
{
    /// <summary>
    /// Interaction logic for WeightConverter.xaml
    /// </summary>
    public partial class WeightConverterView : UserControl, IView
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }
        private IConverterHelper ConverterHelper { get; }

        public event EventHandler<StatisticsDTO> ConvertedValueCompleted;

        public string Header => UIElements.WeightConverter;

        public WeightConverterView(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            InitializeComponent();
            DataHelper = dataHelper;
            Container = unityContainer;
            ConverterHelper = Container.Resolve<IConverterHelper>("WeightConverterHelper");
            FromUnit.ItemsSource = ConverterHelper.UnitTypes;
            ToUnit.ItemsSource = ConverterHelper.UnitTypes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(FromInput.Text, out decimal result);
            ToResult.Text = ConverterHelper.Convert(FromUnit.SelectedValue.ToString(), result, ToUnit.SelectedValue.ToString(), out decimal convertedValue);
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
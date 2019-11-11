using JIPP5_LAB.Constants;
using JIPP5_LAB.Interfaces;
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

        public string Header => UIElements.WeightConverter;

        public WeightConverterView(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            InitializeComponent();
            DataHelper = dataHelper;
            Container = unityContainer;
            ConverterHelper = Container.Resolve<IConverterHelper>("WeightConverterHelper");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(FromInput.Text, out decimal result);
            //ToResult.Text = ConverterHelper.Convert(fromUnit, result, toUnit);
        }
    }
}
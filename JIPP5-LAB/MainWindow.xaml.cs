using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Unity;

namespace JIPP5_LAB
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUnityContainer Container { get; }
        private IDataHelper DataHelper { get; }

        public MainWindow(IUnityContainer unityContainer, IDataHelper dataHelper)
        {
            InitializeComponent();
            Container = unityContainer;
            DataHelper = dataHelper;

            var views = Container.ResolveAll<IView>();

            foreach (var view in views)
            {
                view.ConvertedValueCompleted += View_ConvertedValueCompleted;
                TabControl.Items.Add(CreateTab(view, view.Header));
            }
        }

        private void View_ConvertedValueCompleted(object sender, StatisticsDTO e)
        {
            Task.Factory.StartNew(() => DataHelper.AddRecord(e));
        }

        private TabItem CreateTab(IView view, string header)
        {
            return new TabItem()
            {
                Content = view,
                Header = header
            };
        }
    }
}
using JIPP5_LAB.Interfaces;
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

        public MainWindow(IUnityContainer unityContainer)
        {
            InitializeComponent();
            Container = unityContainer;

            var views = Container.ResolveAll<IView>();

            foreach (var view in views)
            {
                TabControl.Items.Add(CreateTab(view, view.Header));
            }
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
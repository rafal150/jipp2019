using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using ConverterSDK;
using Logic;
using Logic.Commons;
using Logic.Convert;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string className;
        private IStatisticsRepository repository;
        private ConverterService converterService;
        private List<ConverterInterface> converterInterfaces;
        private ConverterApi converterApi;
        public List<string> GetListOfTypes()
        {
            List<string> listOfClasses = new List<string>();
            foreach (ConverterInterface converterInterface in this.converterInterfaces)
            {
                listOfClasses.Add(converterInterface.GetType().Name);
            }

            return listOfClasses;
        }
        public MainWindow(IStatisticsRepository repo, ConverterService converterService)
        {
            //this.repository = repo;
            this.converterApi = new ConverterApi();
            this.repository = new StatisticsSqlRepository();
            this.converterService = converterService;
            this.converterInterfaces = converterService.GetConverters();
            List<string> listOfTypes = GetListOfTypes();
            InitializeComponent();
            TypeSelector.ItemsSource = this.converterApi.GetConverters();
            //LoadInputTypes(listOfTypes.First());
            
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            this.StatisticData.ItemsSource = repository.GetStatistics();
            StatisticData.AutoGenerateColumns = true;
        }

        private void LoadInputTypes(string className)
        { 
                this.className = className;    
                //MethodInfo method = classType.GetMethod("GetListOfProperties");
                //List<string> propertiesList = (List<string>)method.Invoke(null, null);
                //Console.WriteLine(propertiesList.ToString());

                FillComboBox(FromUnitSelector, this.converterApi.GetUnits(className));
                FillComboBox(ToUnitSelector, this.converterApi.GetUnits(className));
        }

        private void FillComboBox(ComboBox comboBox, List<string> propertiesList)
        {
            comboBox.ItemsSource = propertiesList;
            comboBox.SelectedItem = propertiesList.First();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReturnValue.Text = ConvertValue();
            FillDataGrid();
        }

        private string ConvertValue()
        {

            string classType = TypeSelector.Text;
            double convertFromValue = Double.Parse(ConvertFromValue.Text.Replace(".", ","));
            string fromUnit = FromUnitSelector.Text;
            string toUnit = ToUnitSelector.Text;
            string convertedValue;
            
            //convertedValue = get.GetValue(classInstance).ToString();
            convertedValue = ConverterApi.Convert(fromUnit, toUnit, convertFromValue.ToString(), classType).ToString();
            DbLog(convertFromValue, fromUnit, toUnit, convertedValue);

            return convertedValue;
        }

        private void DbLog(double convertFromValue, string fromUnit, string toUnit, string convertedValue)
        {
            StatisticsObject statisticsObject = new StatisticsObject()
            {
                CL_Date = DateTime.Now,
                CL_UnitType = this.className,
                CL_UnitFrom = fromUnit,
                CL_UnitTo = toUnit,
                CL_ValueFrom = decimal.Parse(convertFromValue.ToString()),
                CL_ValueTo = decimal.Parse(convertedValue),

            };
            this.repository.AddStatistic(statisticsObject);
        }

        private void TypeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = TypeSelector.SelectedItem.ToString();
            LoadInputTypes(selected);


        }
    }
}


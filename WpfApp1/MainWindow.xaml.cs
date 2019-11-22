using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Commons;
using ConverterSDK;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Type classType;
        private IStatisticsRepository repository;
        private ConverterService converterService;
        private List<ConverterInterface> converterInterfaces;
        public List<string> GetListOfTypes()
        {
            List<string> listOfClasses = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            foreach (var type in assembly.GetTypes())
            {
                if (type.Namespace == "WpfApp1.Convert")
                {
                    listOfClasses.Add(type.Name);
                }
            }
            foreach (ConverterInterface converterInterface in converterInterfaces)
            {
                listOfClasses.Add(converterInterface.GetType().Name);
            }

            return listOfClasses;
        }
        public MainWindow(IStatisticsRepository repo, ConverterService converterService)
        {
            this.repository = repo;
            this.converterService = converterService;
            converterInterfaces = converterService.GetConverters();
            InitializeComponent();
            List<string> listOfTypes = GetListOfTypes();
            TypeSelector.ItemsSource = listOfTypes;
            LoadInputTypes(listOfTypes.First());
            
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            this.StatisticData.ItemsSource = repository.GetStatistics();
            StatisticData.AutoGenerateColumns = true;
        }

        private void LoadInputTypes(string className)
        {
            try
            {
                classType = Type.GetType("WpfApp1.Convert." + className);
                if (classType == null)
                
                {
                    foreach(ConverterInterface converterInterface in converterInterfaces)
                    {
                        if(converterInterface.GetType().Name == className)
                        {
                            classType = converterInterface.GetType();
                            break;
                        }
                    }
                }
                MethodInfo method = classType.GetMethod("GetListOfProperties");
                List<string> propertiesList = (List<string>)method.Invoke(null, null);
                FillComboBox(FromUnitSelector, propertiesList);
                FillComboBox(ToUnitSelector, propertiesList);
            }
            catch (Exception e){
                Console.WriteLine(e.StackTrace);
            }
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
            Object classInstance = classType.GetConstructor(new Type[] { }).Invoke(new object[] { });
            String value = FromUnitSelector.Text;
            double convertFromValue = Double.Parse(ConvertFromValue.Text.Replace(".", ","));
            string fromUnit = FromUnitSelector.Text;
            string toUnit = ToUnitSelector.Text;
            string convertedValue;
            PropertyInfo set = classType.GetProperty(fromUnit);
            PropertyInfo get = classType.GetProperty(toUnit);
            if (set == null || get == null)
            {
                throw new MethodAccessException();
            }
            set.SetValue(classInstance, convertFromValue);
            convertedValue = get.GetValue(classInstance).ToString();
            DbLog(convertFromValue, fromUnit, toUnit, convertedValue);
            return convertedValue;
        }

        private void DbLog(double convertFromValue, string fromUnit, string toUnit, string convertedValue)
        {
            StatisticsObject statisticsObject = new StatisticsObject()
            {
                CL_Date = DateTime.Now,
                CL_UnitType = classType.Name,
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
            Console.WriteLine(selected);
            LoadInputTypes(selected);


        }
    }
}


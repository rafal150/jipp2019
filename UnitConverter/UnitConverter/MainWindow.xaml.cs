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

namespace UnitConverter {
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private ConversionTypes.AbstractConversionType conversionType;

        public MainWindow() {
            InitializeComponent();
            // load statistics from database to data grid
            LoadStatistics();
        }

        private void LoadStatistics() {
            List<Statistic> statistics = null;
            using (Converter context = new Converter()) {
                statistics = context.Statistics.ToList();
            }
            StatisticsDataGrid.ItemsSource = statistics;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            try {
                // conversion type has to be selected
                if (ConversionType.SelectedIndex == 0) {
                    ConversionTypeError.Content = "Wybierz rodzaj konwersji";
                } else {
                    // unit from and unit to have to be selected and unit from value has to be fulfilled
                    UnitFromError.Content = (UnitFrom.SelectedIndex == 0) ? "Wybierz jednostkę" : ((ValueFrom.Text == "") ? "Wpisz wartość" : "");
                    UnitToError.Content = (UnitTo.SelectedIndex == 0) ? "Wybierz jednostkę" : "";
                    if (UnitFrom.SelectedIndex != 0 && UnitTo.SelectedIndex != 0 && ValueFrom.Text != "") {
                        // try to parse string to double
                        if (!double.TryParse(ValueFrom.Text, out double valueFrom)) {
                            UnitFromError.Content = "Podaj wartość numeryczną w formacie 000,00";
                        } else {
                            double valueTo = conversionType.Convert(UnitFrom.SelectedIndex, UnitTo.SelectedIndex, valueFrom);
                            // parse double to string and assign to TextBox
                            ValueTo.Text = valueTo.ToString();
                            // save to statistics to database
                            using (Converter context = new Converter()) {
                                Statistic statistic = new Statistic() {
                                    DateTime = DateTime.Now,
                                    ConversionType = ConversionType.Text,
                                    UnitFrom = UnitFrom.SelectedItem.ToString(),
                                    UnitTo = UnitTo.SelectedItem.ToString(),
                                    ValueFrom = valueFrom,
                                    ValueTo = valueTo
                                };
                                context.Statistics.Add(statistic);
                                // execute query - save changes
                                context.SaveChanges();
                                // load statistics to data grid
                                LoadStatistics();
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                ButtonError.Content = ex.Message;
            }
        }

        private void ConversionType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ConversionTypes.AbstractConversionType[] conversionTypes = new ConversionTypes.AbstractConversionType[] {
                null,
                new ConversionTypes.Temperature(),
                new ConversionTypes.Length(),
                new ConversionTypes.Mass(),
            };

            conversionType = conversionTypes[ConversionType.SelectedIndex];

            if (ConversionTypeError != null) {
                ConversionTypeError.Content = (conversionType == null) ? "Wybierz rodzaj konwersji" : "";
            }
            if (UnitFrom != null) {
                UnitFrom.Items.Clear();
                UnitFrom.Items.Add("select");
                UnitFrom.SelectedIndex = 0;
            }
            if (UnitTo != null) {
                UnitTo.Items.Clear();
                UnitTo.Items.Add("select");
                UnitTo.SelectedIndex = 0;
            }
            if (UnitFromError != null) {
                UnitFromError.Content = "";
            }
            if (UnitToError != null) {
                UnitToError.Content = "";
            }

            if (conversionType != null) {
                // set combobox items
                string[] comboboxItems = conversionType.ComboboxItems;
                if (comboboxItems.Count() > 0) {
                    for (int i = 0; i < comboboxItems.Count(); i++) {
                        UnitFrom.Items.Add(comboboxItems[i]);
                        UnitTo.Items.Add(comboboxItems[i]);
                    }
                }
            }
        }

        private void UnitFrom_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (UnitFromError != null) {
                UnitFromError.Content = (UnitFrom.SelectedIndex == 0) ? "Wybierz jednostkę" : "";
            }
            /* nie działa
            if (UnitTo != null && UnitFrom.Items.Contains(UnitTo.SelectedIndex)) {
                ((ComboBoxItem) UnitFrom.Items[UnitTo.SelectedIndex]).IsEnabled = false;
            }
            */
        }

        private void UnitTo_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (UnitToError != null) {
                UnitToError.Content = (UnitTo.SelectedIndex == 0) ? "Wybierz jednostkę" : "";
            }
            /* nie działa
            if (UnitFrom != null && UnitTo.Items.Contains(UnitFrom.SelectedIndex)) {
                ((ComboBoxItem) UnitTo.Items[UnitFrom.SelectedIndex]).IsEnabled = false;
            }
            */
        }
    }
}

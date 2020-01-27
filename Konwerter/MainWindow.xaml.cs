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


namespace Konwerter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<TypeClass> t = new List<TypeClass>();
            t.Add(new TypeClass() { idType=1, Type="Temperatury"});
            t.Add(new TypeClass() { idType=2, Type="Długości"});
            t.Add(new TypeClass() { idType=3, Type="Masy"});
            TypeComboBox.ItemsSource = t;
            TypeComboBox.DisplayMemberPath = "Type";

            this.loadStat();
        }

        public void loadStat()
        {
            List<STATISTICS> stat;
            using (Model db = new Model())
            {
                stat = db.STATISTICS.ToList();
            }

            this.statDataGrid.ItemsSource = stat;
        }

        private void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeClass tp = TypeComboBox.SelectedValue as TypeClass;
            if(Convert.ToInt32(tp.idType) == 1)
            {
                List<Values> t = new List<Values>();
                t.Add(new Values() { idVal = 1, Val = "C" });
                t.Add(new Values() { idVal = 2, Val = "F" });
                t.Add(new Values() { idVal = 3, Val = "K" });
                t.Add(new Values() { idVal = 4, Val = "R" });
                ValTypeComboBoxFrom.ItemsSource = t;
                ValTypeComboBoxFrom.DisplayMemberPath = "Val";
                ValTypeComboBoxTo.ItemsSource = t;
                ValTypeComboBoxTo.DisplayMemberPath = "Val";
            }
            else if (Convert.ToInt32(tp.idType) == 2)
            {
                List<Values> t = new List<Values>();
                t.Add(new Values() { idVal = 1, Val = "mm" });
                t.Add(new Values() { idVal = 2, Val = "cm" });
                t.Add(new Values() { idVal = 3, Val = "dcm" });
                t.Add(new Values() { idVal = 4, Val = "m" });
                t.Add(new Values() { idVal = 5, Val = "km" });
                t.Add(new Values() { idVal = 6, Val = "cal" });
                t.Add(new Values() { idVal = 7, Val = "stop" });
                t.Add(new Values() { idVal = 8, Val = "jard" });
                t.Add(new Values() { idVal = 9, Val = "mila" });
                t.Add(new Values() { idVal = 10, Val = "kabel" });
                t.Add(new Values() { idVal = 11, Val = "mila morska" });
                ValTypeComboBoxFrom.ItemsSource = t;
                ValTypeComboBoxFrom.DisplayMemberPath = "Val";
                ValTypeComboBoxTo.ItemsSource = t;
                ValTypeComboBoxTo.DisplayMemberPath = "Val";
            }
            else if (Convert.ToInt32(tp.idType) == 3)
            {
                List<Values> t = new List<Values>();
                t.Add(new Values() { idVal = 1, Val = "mg" });
                t.Add(new Values() { idVal = 2, Val = "g" });
                t.Add(new Values() { idVal = 3, Val = "dkg" });
                t.Add(new Values() { idVal = 4, Val = "kg" });
                t.Add(new Values() { idVal = 5, Val = "T" });
                t.Add(new Values() { idVal = 6, Val = "uncja" });
                t.Add(new Values() { idVal = 7, Val = "funt" });
                t.Add(new Values() { idVal = 8, Val = "karat" });
                t.Add(new Values() { idVal = 9, Val = "kwintal" });
                ValTypeComboBoxFrom.ItemsSource = t;
                ValTypeComboBoxFrom.DisplayMemberPath = "Val";
                ValTypeComboBoxTo.ItemsSource = t;
                ValTypeComboBoxTo.DisplayMemberPath = "Val";
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double valueToConvert = int.Parse(IntConvertTextBox.Text);
            Values val1 = ValTypeComboBoxFrom.SelectedValue as Values;
            Values val2 = ValTypeComboBoxTo.SelectedValue as Values;

            double valueConverted = 0;

            TypeClass tp = TypeComboBox.SelectedValue as TypeClass;

            //temperatura
            if (Convert.ToInt32(tp.idType) == 1)
            {
                Temperature tem = new Temperature();

                //przekonwertowanie pierwotnej wartości na celciusze
                if(val1.idVal == 2)
                {
                    valueConverted= tem.FarenheitToCelsiusz(valueToConvert);
                }
                if(val1.idVal == 3)
                {
                    valueConverted = tem.KelvinToCelsiusz(valueToConvert);
                }
                if(val1.idVal == 4)
                {
                    valueConverted = tem.RankineToCelsiusz(valueToConvert);
                }
                if(val1.idVal == 1)
                {
                    valueConverted = valueToConvert;
                }
                
                //przekonwertowanie docelowej wartości z celciuszy na docelową wartość
                if(val2.idVal ==2)
                {
                    ResultLabel.Content = tem.CelsiuszToFarenheit(valueConverted).ToString();
                }
                if(val2.idVal == 3)
                {
                    ResultLabel.Content = tem.CelsiuszToKelvin(valueConverted).ToString();
                }
                if(val2.idVal == 4)
                {
                    ResultLabel.Content = tem.CelsiuszToRankine(valueConverted).ToString();
                }
                if(val2.idVal == 1)
                {
                    ResultLabel.Content = valueConverted.ToString();
                }
            }
            //dlugosci
            if (Convert.ToInt32(tp.idType) == 2)
            {
                Dlugosci dlu = new Dlugosci();

                //przekonwertowanie pierwotnej wartości
                if (val1.idVal == 1)
                {
                    valueConverted = dlu.mmToM(valueToConvert);
                }
                if (val1.idVal == 2)
                {
                    valueConverted = dlu.cmToM(valueToConvert);
                }
                if (val1.idVal == 3)
                {
                    valueConverted = dlu.dcmToM(valueToConvert);
                }
                if (val1.idVal == 4)
                {
                    valueConverted = valueToConvert;
                }
                if (val1.idVal == 5)
                {
                    valueConverted = dlu.kmToM(valueToConvert);
                }
                if (val1.idVal == 6)
                {
                    valueConverted = dlu.calToM(valueToConvert);
                }
                if (val1.idVal == 7)
                {
                    valueConverted = dlu.stopToM(valueToConvert);
                }
                if (val1.idVal == 8)
                {
                    valueConverted = dlu.jardToM(valueToConvert);
                }
                if (val1.idVal == 9)
                {
                    valueConverted = dlu.milaToM(valueToConvert);
                }
                if (val1.idVal == 10)
                {
                    valueConverted = dlu.kabelToM(valueToConvert);
                }
                if (val1.idVal == 11)
                {
                    valueConverted = dlu.MilaMorskaToM(valueToConvert);
                }

                //przekonwertowanie docelowej wartości na docelową wartość
                if (val2.idVal == 1)
                {
                    ResultLabel.Content = dlu.mToMm(valueConverted).ToString();
                }
                if (val2.idVal == 2)
                {
                    ResultLabel.Content = dlu.mToCm(valueConverted).ToString();
                }
                if (val2.idVal == 3)
                {
                    ResultLabel.Content = dlu.mToDcm(valueConverted).ToString();
                }
                if (val2.idVal == 4)
                {
                    ResultLabel.Content = valueConverted.ToString();
                }
                if (val2.idVal == 5)
                {
                    ResultLabel.Content = dlu.mToKm(valueConverted).ToString();
                }
                if (val2.idVal == 6)
                {
                    ResultLabel.Content = dlu.mToCal(valueConverted).ToString();
                }
                if (val2.idVal == 7)
                {
                    ResultLabel.Content = dlu.mToStop(valueConverted).ToString();
                }
                if (val2.idVal == 8)
                {
                    ResultLabel.Content = dlu.mToJard(valueConverted).ToString();
                }
                if (val2.idVal == 9)
                {
                    ResultLabel.Content = dlu.mToMila(valueConverted).ToString();
                }
                if (val2.idVal == 10)
                {
                    ResultLabel.Content = dlu.mToKabel(valueConverted).ToString();
                }
                if (val2.idVal == 11)
                {
                    ResultLabel.Content = dlu.mToMilaMorska(valueConverted).ToString();
                }
            }
            //masa
            if (Convert.ToInt32(tp.idType) == 3)
            {
                Masa mas = new Masa();

                //przekonwertowanie pierwotnej wartości na celciusze
                if (val1.idVal == 1)
                {
                    valueConverted = mas.mgToKg(valueToConvert);
                }
                if (val1.idVal == 2)
                {
                    valueConverted = mas.gToKg(valueToConvert);
                }
                if (val1.idVal == 3)
                {
                    valueConverted = mas.dkgToKg(valueToConvert);
                }
                if (val1.idVal == 4)
                {
                    valueConverted = valueToConvert;
                }
                if (val1.idVal == 5)
                {
                    valueConverted = mas.tToKg(valueToConvert);
                }
                if (val1.idVal == 6)
                {
                    valueConverted = mas.uncjaToKg(valueToConvert);
                }
                if (val1.idVal == 7)
                {
                    valueConverted = mas.funtToKg(valueToConvert);
                }
                if (val1.idVal == 8)
                {
                    valueConverted = mas.karatToKg(valueToConvert);
                }
                if (val1.idVal == 9)
                {
                    valueConverted = mas.kwintalToKg(valueToConvert);
                }

                //przekonwertowanie docelowej wartości z celciuszy na docelową wartość
                if (val2.idVal == 1)
                {
                    ResultLabel.Content = mas.kgToMg(valueConverted).ToString();
                }
                if (val2.idVal == 2)
                {
                    ResultLabel.Content = mas.kgToG(valueConverted).ToString();
                }
                if (val2.idVal == 3)
                {
                    ResultLabel.Content = mas.kgToDkg(valueConverted).ToString();
                }
                if (val2.idVal == 4)
                {
                    ResultLabel.Content = valueConverted.ToString();
                }
                if (val2.idVal == 5)
                {
                    ResultLabel.Content = mas.kgToT(valueConverted).ToString();
                }
                if (val2.idVal == 6)
                {
                    ResultLabel.Content = mas.kgToUncja(valueConverted).ToString();
                }
                if (val2.idVal == 7)
                {
                    ResultLabel.Content = mas.kgToFunt(valueConverted).ToString();
                }
                if (val2.idVal == 8)
                {
                    ResultLabel.Content = mas.kgToKarat(valueConverted).ToString();
                }
                if (val2.idVal == 9)
                {
                    ResultLabel.Content = mas.kgToKwintal(valueConverted).ToString();
                }
            }

            double Result = Convert.ToDouble(ResultLabel.Content);

            using (Model db = new Model())
            {
                STATISTICS st = new STATISTICS()
                {
                    CONVERTED_FROM_VAL = (float)valueToConvert,
                    CONVERTED_TO_VAL = (float)Result,
                    CONVERTED_FROM = val1.Val.ToString(),
                    CONVERTED_TO = val2.Val.ToString(),
                    DATE = DateTime.Now,
                    TYPE = tp.Type.ToString()
                };

                db.STATISTICS.Add(st);
                db.SaveChanges();
            }
            this.loadStat();
        }
    }
}

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
                ValTypeComboBoxFrom.ItemsSource = t;
                ValTypeComboBoxFrom.DisplayMemberPath = "Val";
                ValTypeComboBoxTo.ItemsSource = t;
                ValTypeComboBoxTo.DisplayMemberPath = "Val";
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Result.Text =
            //    ((int.Parse(this.IntConvertTextBox.Text)) * 7).ToString();
            Values val1 = ValTypeComboBoxFrom.SelectedValue as Values;
            Values val2 = ValTypeComboBoxTo.SelectedValue as Values;


            TypeClass tp = TypeComboBox.SelectedValue as TypeClass;
            if (Convert.ToInt32(tp.idType) == 1)
            {
               if(val1.idVal == 1 && val2.idVal == 2)
                {
                    this.Result.Text =
               ((int.Parse(this.IntConvertTextBox.Text)) * 1).ToString();
                    //przeliczanie C na F
                }
               else if(val1.idVal == 1 && val2.idVal == 3)
                {
                    this.Result.Text =
               ((int.Parse(this.IntConvertTextBox.Text)) * 2).ToString();
                    //przeliczanie C na K
                }
                else if (val1.idVal == 1 && val2.idVal == 4)
                {
                    this.Result.Text =
               ((int.Parse(this.IntConvertTextBox.Text)) * 3).ToString();
                    //przeliczanie C na R
                }else if (val1.idVal == 1 && val2.idVal == 1)
                {
                    MessageBox.Show("wybierz inną jednostke konwertowanych danych");
                }
            }
            else if (Convert.ToInt32(tp.idType) == 2)
            {
                if (val1.idVal == 1 && val2.idVal == 2)
                {
                    this.Result.Text =
               ((decimal.Parse(this.IntConvertTextBox.Text)) / 10).ToString();
                    //przeliczanie mm na cm
                }
                else if (val1.idVal == 1 && val2.idVal == 3)
                {
                    this.Result.Text =
               ((decimal.Parse(this.IntConvertTextBox.Text)) / 100).ToString();
                    //przeliczanie mm na cm
                }
                else if (val1.idVal == 1 && val2.idVal == 4)
                {
                    this.Result.Text =
               ((decimal.Parse(this.IntConvertTextBox.Text)) / 1000).ToString();
                    //przeliczanie mm na dm
                }
                else if (val1.idVal == 1 && val2.idVal == 1)
                {
                    MessageBox.Show("wybierz inną jednostke konwertowanych danych");
                }
                else if (val1.idVal == 1 && val2.idVal == 5)
                {
                    this.Result.Text =
               ((decimal.Parse(this.IntConvertTextBox.Text)) / 1000000).ToString();
                    //przeliczanie mm na km
                }
            }
            else if (Convert.ToInt32(tp.idType) == 3)
            {
                MessageBox.Show("prace techniczne v2");
            }
            //double valueTB = int.Parse(IntConvertTextBox.Text);
            //Values val1 = ValTypeComboBoxFrom.SelectedValue as Values;
           // Values val2 = ValTypeComboBoxTo.SelectedValue as Values;

            //string v1 = val1.Val.ToString();
            //string v2 = val2.Val.ToString();
            //string v3 = v1 + v2;

            //TypeClass tp = TypeComboBox.SelectedValue as TypeClass;
            //if (Convert.ToInt32(tp.idType) == 1)
            //{
            //    Temperature tem = new Temperature();

            //    if (val1.idVal == 1 && val2.idVal == 2)
            //    {
            //        //MessageBox.Show(v1+v2);
            //        //tem.GetType().GetMethod(v3).Invoke(this, new object[] { valueTB });

            //        //.Content = tem.CF(valueTB);
            //    }


            //}
            //ResultLabel.Content = Convert.ToInt32(val1.idVal.Replace("X", valueTB.ToString()));
            //ResultLabel.Content = value.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Konwerter.UnitsConverterDataSet unitsConverterDataSet = ((Konwerter.UnitsConverterDataSet)(this.FindResource("unitsConverterDataSet")));
            // Załaduj dane do tabeli Statistics_tk. Możesz modyfikować ten kod w razie potrzeby.
            Konwerter.UnitsConverterDataSetTableAdapters.Statistics_tkTableAdapter unitsConverterDataSetStatistics_tkTableAdapter = new Konwerter.UnitsConverterDataSetTableAdapters.Statistics_tkTableAdapter();
            unitsConverterDataSetStatistics_tkTableAdapter.Fill(unitsConverterDataSet.Statistics_tk);
            System.Windows.Data.CollectionViewSource statistics_tkViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("statistics_tkViewSource")));
            statistics_tkViewSource.View.MoveCurrentToFirst();
        }
    }
}

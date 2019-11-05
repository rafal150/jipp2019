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
using System.Data.SqlClient;
using System.Data.Sql;

namespace Konwenter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();

            // comboBoxes temperatura

            this.comboBox_temp_z.ItemsSource = new List<string>(new[]
            {
            "C", "K", "F", "R"
            }
            );

            this.comboBox_temp_do.ItemsSource = new List<string>(new[]
            {
            "C", "K", "F", "R"
            }
            );


            //comboBoxes długość

            this.comboBox_dlug_z.ItemsSource = new List<string>(new[]
            {
            "mm", "cm", "dcm", "m", "km", "cal", "stop", "jard", "mila", "kabel", "mila morska"
            }
            );

            this.comboBox_dlug_do.ItemsSource = new List<string>(new[]
            {
            "mm", "cm", "dcm", "m", "km", "cal", "stop", "jard", "mila", "kabel", "mila morska"
            }
            );

            //comboBoxes masa

            this.comboBox_masa_z.ItemsSource = new List<string>(new[]
            {
            "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal"
            }
            );

            this.comboBox_masa_do.ItemsSource = new List<string>(new[]
            {
            "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal"
            }
            );

        }


        private void LoadData()
        {
            using (KonwenterEntities3 db = new KonwenterEntities3())
            {
                dataGrid.ItemsSource = db.Conventer3.ToList();
                dataGrid.DataContext = db.Conventer3.ToList();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_temp_Click(object sender, RoutedEventArgs e)
        {

            TemperaturaKonwenter tk = new TemperaturaKonwenter();


            this.textBox_temp_output.Text = tk.Konwersja(Convert.ToDouble(this.textBox_temp_input.Text), comboBox_temp_z.Text, comboBox_temp_do.Text);
            using (KonwenterEntities3 db = new KonwenterEntities3())
            {
                Conventer3 converter = new Conventer3();
                converter.inputValue = textBox_temp_input.Text + comboBox_temp_z.Text;
                converter.outputValue = textBox_temp_output.Text;
                converter.date = DateTime.Now;
                db.Conventer3.Add(converter);
                db.SaveChanges();
            }
            LoadData();
        }

        private void Button_dlug_Click(object sender, RoutedEventArgs e)
        {
            DlugoscKonwenter dk = new DlugoscKonwenter();


            this.textBox_dlug_output.Text = dk.Konwersja(Convert.ToDouble(this.textBox_dlug_input.Text), comboBox_dlug_z.Text, comboBox_dlug_do.Text);


            using (KonwenterEntities3 db = new KonwenterEntities3())
            {
                Conventer3 converter = new Conventer3();
                converter.inputValue = textBox_dlug_input.Text + comboBox_dlug_z.Text;
                converter.outputValue = textBox_dlug_output.Text;
                converter.date = DateTime.Now;
                db.Conventer3.Add(converter);
                db.SaveChanges();
            }
            LoadData();
        }

        private void Button_masa_Click(object sender, RoutedEventArgs e)
        {
            MasaKonwenter mk = new MasaKonwenter();


            this.textBox_masa_output.Text = mk.Konwersja(Convert.ToDouble(this.textBox_masa_input.Text), comboBox_masa_z.Text, comboBox_masa_do.Text);

            using (KonwenterEntities3 db = new KonwenterEntities3())
            {
                Conventer3 converter = new Conventer3();
                converter.inputValue = textBox_masa_input.Text + comboBox_masa_z.Text;
                converter.outputValue = textBox_masa_output.Text;
                converter.date = DateTime.Now;
                db.Conventer3.Add(converter);
                db.SaveChanges();
            }
            LoadData();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

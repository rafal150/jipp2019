﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Validation;
using System.Diagnostics;
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

namespace UnitsConverter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private int value;
        // private IStatisticsRepository repository;

        private ConvertersApi convertersapi;

        public MainWindow( ConvertersApi converters)
        {
            convertersapi = converters;

            InitializeComponent();

            //this.repository = repo;
            //this.statisticsDataGrid.ItemsSource = repository.GetStatistics();
            this.converterMain.ItemsSource = converters.GetConverters();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.converterMain.SelectedItem != null)
            {
                Converter converter  = (Converter)this.converterMain.SelectedItem;
                decimal result = convertersapi.Convert(
                    this.FromCombobox.SelectedItem.ToString(),
                    this.ToCombobox.SelectedItem.ToString(),
                    this.InputTextBox.Text,
                    converter.Name);

                this.ResultTextblock.Text = result.ToString();
                //StatisticDTO st = new StatisticDTO()
                //{
                //    DateTime = DateTime.Now,
                //    FromUnit = this.FromCombobox.SelectedItem.ToString(),
                //    Type = this.converterMain.SelectedItem.ToString(),
                //    FromTo = this.ToCombobox.SelectedItem.ToString(),
                //    ConvertedValue = this.ResultTextblock.Text
                //};
                // this.repository.AddStatistic(st);
                //this.statisticsDataGrid.ItemsSource = repository.GetStatistics();

            }

        }

            private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (this.converterMain.SelectedItem != null)
                {
                    this.FromCombobox.ItemsSource = ((Converter)this.converterMain.SelectedItem).Units;
                    this.ToCombobox.ItemsSource = ((Converter)this.converterMain.SelectedItem).Units;
                }
            }
    }
}



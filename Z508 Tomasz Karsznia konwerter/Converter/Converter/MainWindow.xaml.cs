using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Converter.Calculator;
using Microsoft.EntityFrameworkCore;
using UnitConverter4;

namespace Converter
{
    public partial class MainWindow : INotifyPropertyChanged
    {

        private IList<string> _units;

        private Type currentType;

        private List<CalculationResultDTO> _results;

        private ICalcRepository repository;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow(ICalcRepository repository, CalculatorService converters)
        {
            this.DataContext = this;
            InitializeComponent();
            this.repository = repository;
            this.TypeCombobox.ItemsSource = converters.GetConverters();
        }

        public IList<string> Units
        {
            get { return _units; }
            set
            {
                _units = value;
                RaisePropertyChanged(nameof(Units));
            }
        }

        public List<CalculationResultDTO> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                RaisePropertyChanged(nameof(Results));
            }
        }


        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void TypeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.TypeCombobox.SelectedItem != null)
            {
                this.FromCombobox.ItemsSource = ((ICalculator)this.TypeCombobox.SelectedItem).Units;
                this.FromCombobox.SelectedIndex = 0;
                this.ToCombobox.ItemsSource = ((ICalculator)this.TypeCombobox.SelectedItem).Units;
                this.ToCombobox.SelectedIndex = 0;
            }
        }

        private async void CalculateButtonClick(object sender, RoutedEventArgs e)
        {

            bool areInputsSet = this.TypeCombobox.SelectedItem != null && this.ToCombobox.SelectedItem != null 
                                 && this.FromCombobox.SelectedItem != null && decimal.TryParse(this.InputTextBox.Text, out _);
            if (areInputsSet)
            {
                decimal inputValue = decimal.Parse(this.InputTextBox.Text);

                ICalculator converter = (ICalculator)this.TypeCombobox.SelectedItem;
                decimal value = converter.Convert(
                    this.FromCombobox.SelectedItem.ToString(),
                    this.ToCombobox.SelectedItem.ToString(),
                    inputValue);

                this.OutputTextBox.Text = value.ToString();

                CalculationResultDTO result = new CalculationResultDTO()
                {
                    UnitType = ((ICalculator)TypeCombobox.SelectionBoxItem).Name,
                    FromValue = inputValue,
                    ToValue = value,
                    ToUnit = this.ToCombobox.Text,
                    FromUnit = this.FromCombobox.Text,
                    
                };

                await this.Save(result);
            }
        }

        private async Task Save(CalculationResultDTO result)
        {
            await this.repository.AddResult(result);
            await this.GetResults();
        }

        public async Task<List<CalculationResultDTO>> GetResults()
        {
            this.Results = await repository.GetResults();
            return this.Results;
        }

        private async void StatisticsDataGrid_OnLoaded(object sender, RoutedEventArgs e)
        {
            var test = await this.repository.GetResults();
            this.StatisticsDataGrid.ItemsSource = test;
        }
    }
}

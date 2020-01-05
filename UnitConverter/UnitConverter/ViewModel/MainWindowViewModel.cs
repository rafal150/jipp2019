using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UnitConversion;

namespace UnitConversion
{
    public class MainWindowViewModel : ViewModelBase
    {
        //private readonly IServiceRepository serviceRepository;

        private ConvertersApi converter;
        public ConvertersApi Converter
        {
            get
            {
                return converter;
            }
            set
            {
                converter = value;
                NotifyPropertyChanged(nameof(Converter));
            }
        }

        public ObservableCollection<ConversionHistory> ConversionHistory { get; set; }
        private ObservableCollection<UnitConverter> unitConverters = null;
        public ObservableCollection<UnitConverter> UnitConverters
        {
            get
            {
                if (unitConverters == null) ReloadUnitConverters();
                return unitConverters;
            }

        }

        private void ReloadUnitConverters()
        {
            unitConverters = new ObservableCollection<UnitConverter>();
            foreach (UnitConverter uc in Converter.GetConverters())
                unitConverters.Add(uc);
        }

        private UnitConverter selectedUnitConverter;
        public UnitConverter SelectedUnitConverter
        {
            get
            {
                return selectedUnitConverter;
            }
            set
            {
                selectedUnitConverter = value;
                NotifyPropertyChanged(nameof(SelectedUnitConverter));
            }
        }
        public string InputValue { get; set; }

        public bool CanExecuteConvert
        {
            get
            {
                return SelectedUnitConverter != null && SelectedUnitConverter.SourceUnit != null && SelectedUnitConverter.TargetUnit != null;
            }
        }

        private decimal result;
        public decimal Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                NotifyPropertyChanged(nameof(Result));
            }
        }

        public ICommand convertCommand;
        public ICommand ConvertCommand
        {
            get { return convertCommand ?? (convertCommand = new Command(() => Convert(), () => CanExecuteConvert)); }
        }

        private void Convert()
        {
            decimal result = Converter.Convert(SelectedUnitConverter.SourceUnit, SelectedUnitConverter.TargetUnit, InputValue, SelectedUnitConverter.Name);
            Result = result;
            ReloadHistory();
            //if(Converter.Convert(SelectedUnitConverter, InputValue, out result))
            //{
            //    Result = result;
            //    ReloadHistory();
            //}
        }

        public MainWindowViewModel(ConvertersApi converters)
        {
            //this.serviceRepository = serviceRepository;
            Converter = converters;
            ConversionHistory = new ObservableCollection<ConversionHistory>();
            ReloadHistory();
        }

        private void ReloadHistory()
        {
            ConversionHistory.Clear();
            foreach (ConversionHistory ch in Converter.GetConversionHistory())
            {
                ConversionHistory.Add(ch);
            }
        }
    }
}

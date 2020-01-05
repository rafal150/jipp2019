using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace UnitConversion
{
    public class MainWindowViewModel : ViewModelBase
    {
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

        private string inputValue;
        public string InputValue
        {
            get { return inputValue; }
            set
            {
                inputValue = value;
                ConvertCommand.CanExecute(null);
            }
        }

        public bool CanExecuteConvert
        {
            get
            {
               return SelectedUnitConverter != null && SelectedUnitConverter.SourceUnit != null && SelectedUnitConverter.TargetUnit != null && decimal.TryParse(InputValue.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val);
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
        }

        public MainWindowViewModel(ConvertersApi converters)
        {
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

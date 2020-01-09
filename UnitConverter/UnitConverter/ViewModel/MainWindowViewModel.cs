using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
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
            if (unitConverters == null)
                unitConverters = new ObservableCollection<UnitConverter>();
            else
                unitConverters.Clear();
            foreach (UnitConverter uc in Converter.GetConverters())
                unitConverters.Add(uc);
        }

        private ObservableCollection<UserConverter> userConverters = null;
        public ObservableCollection<UserConverter> UserConverters
        {
            get
            {
                if (userConverters == null) ReloadUserConverters();
                return userConverters;
            }

        }

        private void ReloadUserConverters()
        {
            if (userConverters == null)
                userConverters = new ObservableCollection<UserConverter>();
            else
                userConverters.Clear();
            foreach (UserConverter uc in Converter.GetUserConverters())
                userConverters.Add(uc);
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

        private UserConverter selectedUserConverter;
        public UserConverter SelectedUserConverter
        {
            get
            {
                return selectedUserConverter;
            }
            set
            {
                selectedUserConverter = value;
                NotifyPropertyChanged(nameof(SelectedUserConverter));
            }
        }

        //private UserConverterUnit selectedUserConverterUnit;
        //public UserConverterUnit SelectedUserConverterUnit
        //{
        //    get
        //    {
        //        return selectedUserConverterUnit;
        //    }
        //    set
        //    {
        //        selectedUserConverterUnit = value;
        //        NotifyPropertyChanged(nameof(SelectedUserConverterUnit));
        //    }
        //}

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

        #region Commands
        public bool CanExecuteConvert
        {
            get
            {
               return SelectedUnitConverter != null && SelectedUnitConverter.SourceUnit != null && SelectedUnitConverter.TargetUnit != null && decimal.TryParse(InputValue.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal val);
            }
        }

        public ICommand convertCommand;
        public ICommand ConvertCommand
        {
            get { return convertCommand ?? (convertCommand = new Command(() => Convert(), () => CanExecuteConvert)); }
        }

        public bool CanExecuteSaveConverter
        {
            get
            {
                return SelectedUserConverter != null && string.IsNullOrWhiteSpace(SelectedUserConverter.Name) == false;
            }
        }

        public ICommand saveConverterCommand;
        public ICommand SaveConverterCommand
        {
            get { return saveConverterCommand ?? (saveConverterCommand = new Command(() => SaveConverter(), () => CanExecuteSaveConverter)); }
        }

        public bool CanExecuteSaveConverterUnit
        {
            get
            {
                return SelectedUserConverter != null && SelectedUserConverter.SelectedUserConverterUnit != null && string.IsNullOrWhiteSpace(SelectedUserConverter.SelectedUserConverterUnit.Name) == false
                    && string.IsNullOrWhiteSpace(SelectedUserConverter.SelectedUserConverterUnit.ConversionFromBaseValueFormula) == false 
                    && string.IsNullOrWhiteSpace(SelectedUserConverter.SelectedUserConverterUnit.ConversionToBaseValueFormula) == false;
            }
        }

        public ICommand saveConverterUnitCommand;
        public ICommand SaveConverterUnitCommand
        {
            get { return saveConverterUnitCommand ?? (saveConverterUnitCommand = new Command(() => SaveConverterUnit(), () => CanExecuteSaveConverterUnit)); }
        }

        public ICommand createNewConverterCommand;
        public ICommand CreateNewConverterCommand
        {
            get { return createNewConverterCommand ?? (createNewConverterCommand = new Command(() => CreateNewConverter(), () => true)); }
        }

        public ICommand createNewConverterUnitCommand;
        public ICommand CreateNewConverterUnitCommand
        {
            get { return createNewConverterUnitCommand ?? (createNewConverterUnitCommand = new Command(() => CreateNewConverterUnit(), () => true)); }
        }


        public bool CanExecuteDeleteConverter
        {
            get
            {
                return SelectedUserConverter != null;
            }
        }
        public ICommand deleteConverterCommand;
        public ICommand DeleteConverterCommand
        {
            get { return deleteConverterCommand ?? (deleteConverterCommand = new Command(() => DeleteConverter(), () => CanExecuteDeleteConverter)); }
        }


        public bool CanExecuteDeleteConverterUnit
        {
            get
            {
                return SelectedUserConverter != null && SelectedUserConverter.SelectedUserConverterUnit != null;
            }
        }
        public ICommand deleteConverterUnitCommand;
        public ICommand DeleteConverterUnitCommand
        {
            get { return deleteConverterUnitCommand ?? (deleteConverterUnitCommand = new Command(() => DeleteConverterUnit(), () => CanExecuteDeleteConverterUnit)); }
        }
        #endregion

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

        private void Convert()
        {
            decimal result = Converter.Convert(SelectedUnitConverter.SourceUnit, SelectedUnitConverter.TargetUnit, InputValue, SelectedUnitConverter.Name);
            Result = result;
            ReloadHistory();
        }

        private void SaveConverter()
        {
            Converter.SaveConverter(SelectedUserConverter.OldName, SelectedUserConverter.Name);
            ReloadUserConverters();
            ReloadUnitConverters();
        }

        private void SaveConverterUnit()
        {
            Converter.SaveConverterUnit(SelectedUserConverter.Name, SelectedUserConverter.SelectedUserConverterUnit.OldName, SelectedUserConverter.SelectedUserConverterUnit.Name,
                SelectedUserConverter.SelectedUserConverterUnit.ConversionToBaseValueFormula, SelectedUserConverter.SelectedUserConverterUnit.ConversionFromBaseValueFormula);
            ReloadUserConverters();
            ReloadUnitConverters();
        }

        private void CreateNewConverter()
        {
            UserConverter newConverter = new UserConverter(true);
            UserConverters.Add(newConverter);
            SelectedUserConverter = newConverter;
        }

        private void CreateNewConverterUnit()
        {
            UserConverterUnit newConverterUnit = new UserConverterUnit(true);
            newConverterUnit.Converter = SelectedUserConverter;
            SelectedUserConverter.Units.Add(newConverterUnit);
            SelectedUserConverter.SelectedUserConverterUnit = newConverterUnit;
        }

        private void DeleteConverter()
        {
            UserConverter userConverter = SelectedUserConverter;
            SelectedUserConverter = null;
            Converter.DeleteConverter(userConverter.OldName);
            ReloadUserConverters();
            ReloadUnitConverters();
        }

        private void DeleteConverterUnit()
        {
            UserConverter userConverter = SelectedUserConverter;
            UserConverterUnit converterUnit = userConverter.SelectedUserConverterUnit;
            userConverter.SelectedUserConverterUnit = null;
            Converter.DeleteConverterUnit(userConverter.OldName, converterUnit.OldName);
            ReloadUserConverters();
            ReloadUnitConverters();
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
            foreach (ConversionHistory ch in Converter.GetConversionHistory().OrderByDescending(x => x.Created))
            {
                ConversionHistory.Add(ch);
            }
        }
    }
}

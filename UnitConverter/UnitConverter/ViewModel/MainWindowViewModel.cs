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
        private readonly IServiceRepository serviceRepository;

        private ConverterService converter;
        public ConverterService Converter
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

        public ObservableCollection<ConversionHistoryDTO> ConversionHistory { get; set; }

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
        public decimal InputValue { get; set; }

        public bool CanExecuteConvert
        {
            get
            {
                return SelectedUnitConverter != null && SelectedUnitConverter.BaseUnit != null && SelectedUnitConverter.TargetUnit != null;
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
            decimal result = -1;
            if(Converter.Convert(SelectedUnitConverter, InputValue, out result))
            {
                Result = result;
                ReloadHistory();
            }
        }

        public MainWindowViewModel(IServiceRepository serviceRepository, ConverterService service)
        {
            this.serviceRepository = serviceRepository;
            Converter = service;
            ConversionHistory = new ObservableCollection<ConversionHistoryDTO>();
            ReloadHistory();
        }

        private void ReloadHistory()
        {
            ConversionHistory.Clear();
            foreach (ConversionHistoryDTO ch in serviceRepository.GetConversionHistory())
            {
                ConversionHistory.Add(ch);
            }
        }
    }
}

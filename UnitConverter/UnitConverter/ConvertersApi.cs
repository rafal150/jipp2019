using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Text;
using System.Web;

namespace UnitConversion
{
    public class ConvertersApi
    {
        public List<UnitConverter> GetConverters()
        {
            string url = @"http://localhost:50189/api/converters";
            return new List<UnitConverter>(GetObjectApiResponse<UnitConverter[]>(url));
        }

        public List<UserConverter> GetUserConverters()
        {
            string url = @"http://localhost:50189/api/converters/userconverters";
            return new List<UserConverter>(GetObjectApiResponse<UserConverter[]>(url));
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            string url = @"http://localhost:50189/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlParam = url + queryString.ToString();
                string value = client.DownloadString(urlParam);
                return decimal.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        public List<ConversionHistory> GetConversionHistory()
        {
            string url = @"http://localhost:50189/api/conversionhistory";
            return new List<ConversionHistory>(GetObjectApiResponse<ConversionHistory[]>(url));
        }

        public void SaveConverter(string converterType, string Name)
        {
            string url = @"http://localhost:50189/api/converters/saveconverter?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("converterType", converterType);
            queryString.Add("Name", Name);
            using (WebClient client = new WebClient())
            {
                string urlParam = url + queryString.ToString();
                string value = client.DownloadString(urlParam);
            }
        }

        public void DeleteConverter(string converterType)
        {
            string url = @"http://localhost:50189/api/converters/deleteconverter?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("converterType", converterType);
            using (WebClient client = new WebClient())
            {
                string urlParam = url + queryString.ToString();
                string value = client.DownloadString(urlParam);
            }
        }

        public void SaveConverterUnit(string converterType, string ConverterUnitName, string Name, string ConversionToBaseValueFormula, string ConversionFromBaseValueFormula)
        {
            string url = @"http://localhost:50189/api/converters/saveconverterunit?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("converterType", converterType);
            queryString.Add("ConverterUnitName", ConverterUnitName);
            queryString.Add("Name", Name);
            queryString.Add("ConversionToBaseValueFormula", ConversionToBaseValueFormula);
            queryString.Add("ConversionFromBaseValueFormula", ConversionFromBaseValueFormula);
            using (WebClient client = new WebClient())
            {
                string urlParam = url + queryString.ToString();
                string value = client.DownloadString(urlParam);
            }
        }

        public void DeleteConverterUnit(string converterType, string unitName)
        {
            string url = @"http://localhost:50189/api/converters/saveconverterunit?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("converterType", converterType);
            queryString.Add("unitName", unitName);
            using (WebClient client = new WebClient())
            {
                string urlParam = url + queryString.ToString();
                string value = client.DownloadString(urlParam);
            }
        }

        private T GetObjectApiResponse<T>(string url)
        {
            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                return JsonConvert.DeserializeObject<T>(json);
            }
        }

    }

    public class UnitConverter
    {
        public string Name { get; set; }
        public List<string> Units { get; set; }

        public string SourceUnit { get; set; }

        public string TargetUnit { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class UserConverter : ViewModelBase
    {
        public DateTime? Created { get; set; }
        public bool IsNew { get; private set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (OldName == string.Empty && IsNew == false)
                    OldName = name;
            }
        }

        public string OldName { get; private set; } = string.Empty;

        public ObservableCollection<UserConverterUnit> Units { get; set; }

        private UserConverterUnit selectedUserConverterUnit;
        public UserConverterUnit SelectedUserConverterUnit
        {
            get { return selectedUserConverterUnit; }
            set
            {
                selectedUserConverterUnit = value;
                NotifyPropertyChanged(nameof(SelectedUserConverterUnit));
            }
        }

        public UserConverter()
        {

        }

        public UserConverter(bool isNew)
        {
            IsNew = isNew;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class UserConverterUnit
    {
        public UserConverter Converter { get; set; }
        public bool IsNew { get; private set; }
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (OldName == string.Empty && IsNew == false)
                    OldName = name;
            }
        }

        public string OldName { get; private set; } = string.Empty;

        public string ConversionToBaseValueFormula { get; set; }

        public string ConversionFromBaseValueFormula { get; set; }

        public UserConverterUnit()
        {

        }

        public UserConverterUnit(bool isNew)
        {
            IsNew = isNew;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ConversionHistory
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

        public string ConversionType { get; set; }

        public string BaseUnit { get; set; }

        public decimal BaseValue { get; set; }

        public string TargetUnit { get; set; }

        public decimal TargetValue { get; set; }
    }
}

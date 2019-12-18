using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Services;
using Newtonsoft.Json;
using System.Globalization;

namespace EuroConverterPlugin
{
    public class EuroConverter : IConverter
    {
        public string Name => "Waluta";
        public List<string> Units => new List<string>(new[] { "PLN", "EUR" });
        double wyjscie = 0;
        //double kurs = 0; //działamy dalej
        public double PobierzKurs(string code)
        {
            double kurs = 0;
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);
                if (tables.Length > 0)
                {
                    //RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();
                    RateObject rate = tables[0].Rates.Where(r => r.Code == code).FirstOrDefault();
                    if (rate != null)
                    {
                        //kurs = Double.Parse(rate.Mid) ;
                        kurs = double.Parse(rate.Mid, CultureInfo.InvariantCulture);
                        //return kurs;
                    }
                }
                return kurs;
            }
        }
        public class TableObject
        {
            public string Table { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public RateObject[] Rates { get; set; }
        }

        public class RateObject
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public string Mid { get; set; }
        }
        public double Liczenie(string z, string na, double wartosc)
        {

            double wartosc_pocz = wartosc;
            //PobierzKurs("EUR");
            if (z != na)
            {
                switch (na)
                {
                    case "PLN":
                        wartosc = wartosc * PobierzKurs("EUR"); //przeliczanie z eur na pln
                        wartosc = Math.Round(wartosc, 2);
                        wyjscie = wartosc;
                        break;
                    case "EUR":
                        wartosc = wartosc / PobierzKurs("EUR"); //przeliczanie z pln na eur
                        wartosc = Math.Round(wartosc, 2);   
                        wyjscie = wartosc;
                        break;
                }
            }
            else
            {
                wyjscie = wartosc_pocz;
            }
            return wyjscie;
        }
    }
}

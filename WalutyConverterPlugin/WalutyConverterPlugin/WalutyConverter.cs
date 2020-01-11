using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitConverteAZ.Services;

namespace WalutyConverterPlugin
{
    public class WalutyConverter : IConverter
    {
        public string Name => "Waluty";

        public List<string> Units => getUnitsNames();

        public double Convert(string unitFrom, string unitTo, double value)
        {
            double calcuatedValue = 0;
            var units = getUnits();
            double indicator = 0;

            foreach (var k in units)
            {
                if (k.Key == unitFrom)
                {
                    indicator = k.Value;
                }

            }
            calcuatedValue = (value * indicator);

            foreach (var k in units)
            {
                if (k.Key == unitTo)
                {
                    indicator = k.Value;
                }

            }
            calcuatedValue = calcuatedValue / indicator;

            return calcuatedValue;
        }



        public static double PodajKurs(string waluta)
        {
            double kurs;
            //string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == waluta).FirstOrDefault();

                    if (rate != null)
                    {
                        kurs = double.Parse(rate.Mid, CultureInfo.InvariantCulture);
                        Console.WriteLine(rate.Mid);

                        return kurs;
                    }
                }
            }
            return 0;
        }




        private static Dictionary<string, double> getUnits()
        {
            var units = new Dictionary<string, double>();
            double kurs = PodajKurs("EUR");

            units.Add("PLN", 1);
            units.Add("EURO", kurs);


            return units;
        }

        public static List<string> getUnitsNames()
        {
            var units = getUnits();
            var list = new List<string>();
            foreach (var k in units)
            {
                list.Add(k.Key);
            }
            return list;

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
    }

}


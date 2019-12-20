using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.SDK;


namespace WpfApp1
{
    public class CurrencyMeasure : IGetMeasures
    {
        double eur_c = Double.Parse(Nbp_curr_web_srv.Getcourse(), System.Globalization.CultureInfo.InvariantCulture);
        private string nam = "currencies";
        public string Nam { get => nam; }
        public List<string> Units => new List<string>(new[] { "PLN", "EUR" });
        public double Convert(string from, string to, double value_from)
        {

            switch (from)
            {
                case "PLN":
                    break;
                case "EUR":
                    value_from *= eur_c;
                    break;
            }
            switch (to)
            {
                case "PLN":
                    break;
                case "EUR":
                    value_from /= eur_c;
                    break;
            }
            return value_from;
        }
    }
}
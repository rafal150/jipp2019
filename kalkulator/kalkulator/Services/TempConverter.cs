using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator.Services
{
    class TempConverter : IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>(new[] { "C", "K", "F", "R" });

        public double Convert(int pier, int drug, double wart)
        {
            if ((pier == 0) && (drug == 1)) return (wart + 273);
            if ((pier == 1) && (drug == 0)) return (wart - 273);
            if ((pier == 0) && (drug == 2)) return (wart * 1.8000 + 32.00);
            if ((pier == 2) && (drug == 0)) return ((wart - 32) / 1.8000);
            if ((pier == 0) && (drug == 3)) return ((wart * 1.8) + 491.67);
            if ((pier == 3) && (drug == 0)) return ((wart - 491.67) / 1.8);
            if ((pier == 1) && (drug == 2)) return ((wart - 273.15) * 1.8000 + 32.00);
            if ((pier == 2) && (drug == 1)) return ((wart - 32) / 1.8000 + 273.15);
            if ((pier == 1) && (drug == 3)) return ((wart - 273.15) * 1.8000 + 491.67);
            if ((pier == 3) && (drug == 1)) return ((wart - 491.67) / 1.8000 + 273.15);
            if ((pier == 2) && (drug == 3)) return ((wart - 32) + 491.67);
            if ((pier == 3) && (drug == 2)) return ((wart - 491.67) + 32.00);
            return 0;
        }
    }
}

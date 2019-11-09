using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Jednostki
{
    static class ErrorMessages
    {
        public static string ErrorStatistic = "Nie można wyświetlić statystyk. Brak połączenia z bazą danych.";
        public static string ErrorInput = "Obliczenia zostały wykonane bez wpisu do bazy danych. Brak połączenia z bazą danych.";
        public static string ErrorData = "Podałeś dane w złym formacie. Podaj liczbe całkowitą lub zmiennoprzecinkową wg przykładu poniżej. \n 34 \n -56 \n -3.45 \n 99.9987";
    }
}

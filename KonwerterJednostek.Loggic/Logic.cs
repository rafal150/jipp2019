using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Logic : ILogic
    {
        private IPolaczenie connect;
        private IEnumerable<IKonwertuj> przelicznik;
        private List<Miara> listaMiar;
        private List<Przeliczanie_miar> listaPrzelicznikow;
        public int InputTypID { get; private set; }
        public int OutputTypID { get; private set; }

        public void Inicjalizuj(IPolaczenie repo, ConvertersService converters)
        {
            przelicznik = converters.GetConverters();

            listaPrzelicznikow = new List<Przeliczanie_miar>();
            listaMiar = new List<Miara>();
            foreach (var p in przelicznik)
            {
                listaMiar.AddRange(p.Lista_Miar);
                listaPrzelicznikow.AddRange(p.Lista_Przeliczanie_miar);
            }

            InputTypID = 0;
            OutputTypID = 0;
            connect = repo;
        }

        public string Konwertuj(string value, Miara inputMiara, Miara outputMiara)
        {
            var output = Konwerter.Konwertuj(Convert.ToDouble(value), InputTypID, OutputTypID, listaPrzelicznikow.Distinct()).ToString();
            var nazwa_typu = przelicznik.Select(x => x.Pobierz_nazwe_typu(outputMiara.Typ_ID)).Where(x => x != "").First();
            connect.Dodaj_statystyke(new Statystyka(DateTime.Now, nazwa_typu, inputMiara.Nazwa_miary, Convert.ToDouble(value), outputMiara.Nazwa_miary, Convert.ToDouble(output)));
            return output;
        }

        public IEnumerable<Statystyka> PobierzStatystyki()
        {
            return connect.PobierzStatystykiAsync();
        }

        public void UstawOutputTypID(int value)
        {
            OutputTypID = value;
        }

        public void UstawInputTypID(int value)
        {
            InputTypID = value;
        }

        public IEnumerable<Miara> PobierzListeInputowychMiar()
        {
            return listaMiar.Distinct();
        }

        public IEnumerable<Miara> PobierzListeOutputowychMiar(int typID)
        {
            return listaMiar.Where(x => x.Typ_ID == (typID)).Distinct();
        }
    }
}

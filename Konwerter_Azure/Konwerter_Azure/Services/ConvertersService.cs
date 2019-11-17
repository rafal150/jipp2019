using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Konwerter_Azure.Services
{
    public class ConvertersService // zwraca liste konwerterow
    {
        ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope) //rejestracja typu ConvertersService
        {
            this.scope = scope;// pozwala uzyc funkcji Resolve - do wykrycia zarejestrowanych konwerterow
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> mojeKonwertery = new List<IConverter>();

            mojeKonwertery.AddRange(this.scope.Resolve<IEnumerable<IConverter>>());// wszystkie klasy ktore implementuja interfejs IConverter i sa zarejestrowane

            //mojeKonwertery.Add(new PrzeliczMaseKonwerter());
            //mojeKonwertery.Add(new PrzelicztemperatureKonwerter());

            return mojeKonwertery;
        }
    }
}

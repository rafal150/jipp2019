using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    public class ListaTypowKonwersji
    {
        ILifetimeScope zakres;

        public ListaTypowKonwersji(ILifetimeScope zakres)
        {
            this.zakres = zakres;
        }
        public List<IKonwersja> DajKonwenter()
        {
            List<IKonwersja> listaKonwenterow = new List<IKonwersja>();
            listaKonwenterow.AddRange(this.zakres.Resolve<IEnumerable<IKonwersja>>());

            return listaKonwenterow;
        }
    }
}

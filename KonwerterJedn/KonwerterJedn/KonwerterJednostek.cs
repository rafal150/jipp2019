using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    public class KonwerterJednostek
    {
        ILifetimeScope scope;

        public KonwerterJednostek(ILifetimeScope scope) //obiekt specjalny
        {
            this.scope = scope;
        }

        //metoda trzymająca (po interfejsie) wszystkie konwertery
        public List<IConverter> GetConverters()
        {
            
            List<IConverter> konwertery = new List<IConverter>();

            konwertery.AddRange(this.scope.Resolve<IEnumerable<IConverter>>());

           //konwertery.Add(new Temp());
           // konwertery.Add(new Odl());
           //konwertery.Add(new Mas());

            return konwertery;
        }
    }
}

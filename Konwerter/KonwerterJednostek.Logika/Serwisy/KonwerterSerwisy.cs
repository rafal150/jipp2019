using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Serwisy
{
    public class KonwerterSerwisy
    {
        ILifetimeScope scope;

        public KonwerterSerwisy(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public IEnumerable<IKonwerter> WczytajKonwertery()
        {
            List<IKonwerter> converters = new List<IKonwerter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IKonwerter>>());

            //converters.Add(new WeightConverter());
            //converters.Add(new LenghtConverter());

            return converters;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Konwerter.Services
{
    public class KonwerterServices
    {
        ILifetimeScope scope;

        public KonwerterServices(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IKonwerter> GetConverters()
        {
            List<IKonwerter> converters = new List<IKonwerter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IKonwerter>>());

            //converters.Add(new MasaKonwerter());
            //converters.Add(new TemperaturaKonwerter());
            //converters.Add(new DlugoscKonwerter());
            //converters.Add(new PojemnoscKonwerter());

            return converters;
        }
    }
}

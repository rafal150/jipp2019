using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek.Services
{
    public class ConvertersService
    {
        ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<iKonwerter> GetConverters()
        {
            List<iKonwerter> converters = new List<iKonwerter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<iKonwerter>>());

            //converters.Add(new WeightConverter());
            //converters.Add(new LenghtConverter());

            return converters;
        }
    }
}

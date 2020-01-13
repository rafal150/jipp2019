using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Services
{
    public class ConvertersService
    {
        ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<InterfejsKonwerter> GetConverters()
        {
            List<InterfejsKonwerter> converters = new List<InterfejsKonwerter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<InterfejsKonwerter>>());


            return converters;
        }
    }
}

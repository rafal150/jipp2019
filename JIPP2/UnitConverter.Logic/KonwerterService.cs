using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using KonwerterSDK;

namespace WpfApp7
{
    public class KonwerterService
    {
        ILifetimeScope scope;
        public KonwerterService(ILifetimeScope scope)
        {
            this.scope = scope;
        }
        public List<InterfejsKonwerter> GetConverters()
        {
            List<InterfejsKonwerter> converters = new List<InterfejsKonwerter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<InterfejsKonwerter>>());
            converters.Add(new KonwerterWaluty.KonwertujWalute());

            return converters;
        }
    }
}

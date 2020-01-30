using Autofac;
using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class ConvertersService
    {
        private ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IKonwerter> GetConverters()
        {
            List<IKonwerter> converters = new List<IKonwerter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IKonwerter>>());

            return converters;
        }
    }
}
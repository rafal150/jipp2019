using Autofac;
using System.Collections.Generic;
using IConvertible = ConverterSDK.IConvertible;

namespace WPFKonwerter.Services
{
    public class KonwerterService
    {
        ILifetimeScope scope;
        public KonwerterService(ILifetimeScope lifetimeScope)
        {
            scope = lifetimeScope;
        }
        public List<IConvertible> GetConverters()
        {
            List<IConvertible> converters = new List<IConvertible>();
           
            converters.AddRange(scope.Resolve<IEnumerable<IConvertible>>());
            return converters;
        }

    }
}

using Autofac;
using System;
using System.Collections.Generic;
using KonwerterSDK;
using IConvertible = KonwerterSDK.IConvertible;

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

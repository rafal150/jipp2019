using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ConverterSDK;
using Logic.Convert;

namespace Logic.Commons
{
    public class ConverterService
    {
        ILifetimeScope scope;
        public ConverterService(ILifetimeScope scope)
        {
            this.scope = scope;

        }
        public List<ConverterInterface> GetConverters()
        {
            Console.WriteLine("Registering new Types");
            List<ConverterInterface> converters = new List<ConverterInterface>();

            converters.AddRange(this.scope.Resolve<IEnumerable<ConverterInterface>>());
            converters.Add(new KursWalut.CurrencyConverter());
            return converters;
        }

        public Type getType(string className)
        {
            return Type.GetType(className, true, true);
        }
    }
}

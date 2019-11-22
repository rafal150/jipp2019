using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ConverterSDK;
namespace WpfApp1.Commons
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
            List<ConverterInterface> converters = new List<ConverterInterface>();

            converters.AddRange(this.scope.Resolve<IEnumerable<ConverterInterface>>());
            

            //converters.Add(new WeightConverter());
            //converters.Add(new LenghtConverter());

            return converters;
        }
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kalkulator.Services
{
    public class ConvService
    {
        ILifetimeScope scope;

        public ConvService(ILifetimeScope scope)
        {
          
            this.scope = scope;
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = new List<IConverter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IConverter>>());

            //converters.Add(new TempConverter());
            //converters.Add(new LenghtConverter());

            return converters;
        }
    }
}

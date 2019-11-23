using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter.Services
{
    public class ConvServices
    {
        ILifetimeScope scope;
        
        public ConvServices(ILifetimeScope scope)
        {
            this.scope = scope;
        }
        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = new List<IConverter>();

            converters.AddRange(scope.Resolve<IEnumerable<IConverter>>());

            //converters.Add(new MasyKonwerter());
            //converters.Add(new DlugosciKonwerter());
            return converters;
        }
    }
}

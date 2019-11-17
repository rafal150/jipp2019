using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class ConvertersService
    {
        ILifetimeScope scope;
        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IConverting> GetConverters()
        {
            List<IConverting> converters = new List<IConverting>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IConverting>>());

            return converters;
        }
    }
}

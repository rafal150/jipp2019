using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace UnitConverter.Converters {
    public class Converters {
        ILifetimeScope scope;
        public Converters(ILifetimeScope scope) {
            this.scope = scope;
        }
        public List<IConverter> GetConverters() {
            List<IConverter> converters = new List<IConverter>();
            // add all classes that implement IConverter and are registered in App.xaml.cs
            converters.AddRange(scope.Resolve<IEnumerable<IConverter>>());

            return converters;
        }
    }
}

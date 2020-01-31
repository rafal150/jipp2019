using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace Converter.Calculator
{
    public class CalculatorService
    {
        ILifetimeScope scope;

        public CalculatorService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<ICalculator> GetConverters()
        {
            List<ICalculator> converters = new List<ICalculator>();

            converters.AddRange(this.scope.Resolve<IEnumerable<ICalculator>>());

            return converters;
        }
        
    }
}

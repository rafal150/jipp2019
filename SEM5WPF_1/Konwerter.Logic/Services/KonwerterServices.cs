using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Threading.Tasks;
using SEM5WPF_1.Services;

namespace SEM5WPF_1.Services
{
    public class KonwerterServices
    {
        ILifetimeScope scope;

        public KonwerterServices(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IKonwerter> GetKonwerters()
        {
            List<IKonwerter> konwerters = new List<IKonwerter>();
            konwerters.AddRange(this.scope.Resolve<IEnumerable<IKonwerter>>());

            return konwerters;
        }

    }
}

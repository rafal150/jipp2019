using Autofac;
using System.Collections.Generic;
using System.Linq;
using WpfApp1.Units;

namespace WpfApp1
{
    public class UnitManager
    {
        ILifetimeScope scope;
        List<UnitsContainer> containers;


        public UnitManager(ILifetimeScope scope) {
            this.scope = scope;
            this.containers = scope.Resolve<IEnumerable<UnitsContainer>>().ToList();
        }

        public UnitManager() {
        }

        public List<UnitsContainer> GetContainers() {
            //var containers = scope.Resolve<IEnumerable<UnitsContainer>>().ToList();
            return containers;
        }

    }
}
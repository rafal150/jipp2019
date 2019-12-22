using System.Collections.Generic;
using Autofac;


namespace Konwerter5.Logic.Uslugi
{
    public class Konwerter5Usluga
    {
        ILifetimeScope scope;
        public Konwerter5Usluga(ILifetimeScope scope)
        {
            this.scope = scope;
        }
        public List<IKonwerter5> PobierzKonwertery()
        {
            List<IKonwerter5> konwertery = new List<IKonwerter5>();
            konwertery.AddRange(scope.Resolve<IEnumerable<IKonwerter5>>());
            return konwertery;
        }
    }
}

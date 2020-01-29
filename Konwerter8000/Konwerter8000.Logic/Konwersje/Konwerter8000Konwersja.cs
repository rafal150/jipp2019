using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace Konwerter8000.Konwersje
{
   public class Konwerter8000Konwersja
    {
        ILifetimeScope LifetimeScope;

        public Konwerter8000Konwersja (ILifetimeScope lifetimeScope)
        {
            LifetimeScope = lifetimeScope;
        }
        public List<IKonwerter8000> PobierzKonwertery()
        {
            List<IKonwerter8000> konwertery = new List<IKonwerter8000>();
            konwertery.AddRange(LifetimeScope.Resolve<IEnumerable<IKonwerter8000>>());
            return konwertery;
        }
    }
}

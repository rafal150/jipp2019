using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class Wybor_konwertera
    {
        ILifetimeScope scope;

        public Wybor_konwertera(ILifetimeScope scope)
        {
            this.scope = scope;
        } 
        
        public List<IKonwersja> GetConverters()
        {
            List<IKonwersja> konwertery = new List<IKonwersja>();

           konwertery.AddRange(this.scope.Resolve<IEnumerable<IKonwersja>>());

           // konwertery.Add(new Konwersja_dl());
            //konwertery.Add(new Konwersja_masa());

            return konwertery;
        }
    }
}

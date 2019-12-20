using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Newtonsoft.Json;
using WpfApp1.SDK;

namespace WpfApp1.Logic
{
    public class GetMeasuresObj
    {
        ILifetimeScope mscope;

        public GetMeasuresObj(ILifetimeScope scope)
        {
            this.mscope = scope;
        }

        public List<IGetMeasures> GetMesasures()
        {
            List<IGetMeasures> measures = new List<IGetMeasures>();

            measures.AddRange(this.mscope.Resolve<IEnumerable<IGetMeasures>>());
            return measures;
        }
    }
}

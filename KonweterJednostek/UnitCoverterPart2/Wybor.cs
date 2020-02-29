using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Wybor
    {
        public int id_wyboru { get; set; }
        public string typ { get; set; }
        public Wybor(int x, string y)
        {
            id_wyboru = x;
            typ = y;
        }
    }
}

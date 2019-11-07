using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    
    class wyborTypuKonwersji
    {
        BazaNazw bn = new BazaNazw();
        List<string> jednostka = new List<string>();
        public List<string> wypelnienieJednostek(string nazwaKategorii)
        {            
            if (nazwaKategorii==bn.getKategoria().ElementAt(0))
            {
                jednostka = bn.getJednostkiTemp();
            }
            else if (nazwaKategorii == bn.getKategoria().ElementAt(1))
            {
                jednostka = bn.getJednostkiDlug();
            }
            else if (nazwaKategorii == bn.getKategoria().ElementAt(2))
            {
                jednostka = bn.getJednostkiMasy();
            }
            return jednostka;
        }
    }
}

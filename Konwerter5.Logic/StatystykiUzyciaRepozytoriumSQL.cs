using System.Collections.Generic;
using System.Linq;
using Konwerter5.ModelDanych;

namespace Konwerter5
{
   public class StatystykiUzyciaRepozytoriumSQL : IRepozytoriumStatystykUzycia
    {
        public void DodajStatystykiUzycia(StatystykiUzyciaDTO StatystykiUzycia)
        {
            using (StatystykiUzyciaModel kontekst = new StatystykiUzyciaModel())
            {
                kontekst.StatystykiUzycia.Add(new StatystykiUzycia()
                {
                    TypKonwersji = StatystykiUzycia.TypKonwersji,
                    Data = StatystykiUzycia.Data,
                    Id = StatystykiUzycia.Id,
                    ZJednostki = StatystykiUzycia.ZJednostki,
                    DoJednostki = StatystykiUzycia.DoJednostki,
                    WartoscDoPrzeliczen = StatystykiUzycia.WartoscDoPrzeliczen,
                    WartoscPrzeliczona = StatystykiUzycia.WartoscPrzeliczona
                });

                kontekst.SaveChanges();
            }
        }

        public IEnumerable<StatystykiUzyciaDTO> PobierzStatystykiUzycia()
        {
            using (StatystykiUzyciaModel kontekst = new StatystykiUzyciaModel())
            {
                return kontekst.StatystykiUzycia.Select
                    (
                    obj => new StatystykiUzyciaDTO()
                    {
                        Data = obj.Data,
                        TypKonwersji = obj.TypKonwersji,
                        Id = obj.Id,
                        ZJednostki = obj.ZJednostki,
                        DoJednostki = obj.DoJednostki,
                        WartoscPrzeliczona = obj.WartoscPrzeliczona,
                        WartoscDoPrzeliczen = obj.WartoscDoPrzeliczen
                    }
                    ).ToList();    
            }
        }
    }
}

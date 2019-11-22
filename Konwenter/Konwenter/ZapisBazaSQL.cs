using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    public class ZapisBazaSQL:IBazyDanych
    {
       
        //public void zapis(string typKonwersji, string jednostkaWejsc, string jednostkaWyjsc, string wartoscWejsc, string wartoscWynik)
        //{
        //    var db = new BazaKonwerter();
        //    Statystyki st = new Statystyki()
        //    {
        //        DataZapisu = DateTime.Now,
        //        TypKonwersji = typKonwersji,
        //        ZJednostki = jednostkaWejsc,
        //        NaJednostke = jednostkaWyjsc,
        //        DaneWejsc = decimal.Parse(wartoscWejsc),
        //        DaneWyjsc = decimal.Parse(wartoscWynik)
        //    };
        //    db.Statystyki.Add(st);
        //    db.SaveChanges();
        //}
        public void zapisDoBazy(ZapisBazaDTO stat)
        {
            using (BazaKonwerter bk = new BazaKonwerter())
            {
                bk.Statystyki.Add(new Statystyki()
                {
                    id_statystyki = stat.id,
                    DataZapisu = stat.dataZapisu,
                    TypKonwersji = stat.typKonwersji,
                    ZJednostki = stat.zJednostki,
                    NaJednostke = stat.naJednostke,
                    DaneWejsc = stat.daneWejsc,
                    DaneWyjsc = stat.daneWyjsc
                });
                bk.SaveChanges();
            }
        }
        public IEnumerable<ZapisBazaDTO> wyswietlStatystyki()
        {           
            using (BazaKonwerter bk = new BazaKonwerter())
            {
                return bk.Statystyki.
                    Select(x => new ZapisBazaDTO()
                    {
                        id = x.id_statystyki,
                        dataZapisu = x.DataZapisu,
                        typKonwersji = x.TypKonwersji,
                        zJednostki = x.ZJednostki,
                        naJednostke = x.NaJednostke,
                        daneWejsc = x.DaneWejsc,
                        daneWyjsc = x.DaneWyjsc
                    }).
                        ToList();
            }
            
        }
    }
}

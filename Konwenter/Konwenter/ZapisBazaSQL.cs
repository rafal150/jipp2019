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
        public void zapisDoBazy(ZapisBazaPosrednik statystyki)
        {
            using (BazaKonwerter bk = new BazaKonwerter())
            {
                bk.Statystyki.Add(new Statystyki()
                {
                    id_statystyki = statystyki.id,
                    DataZapisu = statystyki.dataZapisu,
                    TypKonwersji = statystyki.typKonwersji,
                    ZJednostki = statystyki.zJednostki,
                    NaJednostke = statystyki.naJednostke,
                    DaneWejsc = statystyki.daneWejsc,
                    DaneWyjsc = statystyki.daneWyjsc
                });
                bk.SaveChanges();
            }
        }
        public IEnumerable<ZapisBazaPosrednik> wyswietlStatystyki()
        {           
            using (BazaKonwerter bk = new BazaKonwerter())
            {
                return bk.Statystyki.
                    Select(x => new ZapisBazaPosrednik()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEM5WPF_1.Model;
using System.Threading.Tasks;

namespace SEM5WPF_1
{
    public class StatystykiSqlRepozytorium: IStatystykiRepozytorium
    {
        public void DodajStatystyki(StatystykiDTO statystyki)
        {
            using (ModelStatystyki db = new ModelStatystyki())
            {
                db.Statystyki.Add(new Statystyki()
                {
                    Data = statystyki.Data,
                    JednostkaA = statystyki.JednostkaA,
                    JednostkaB = statystyki.JednostkaB,
                    NumerPrzeliczenia = statystyki.NumerPrzeliczenia,
                    WartoscA = statystyki.WartoscA,
                    WartoscB = statystyki.WartoscB,
                    WartoscPodstawowa = statystyki.WartoscPodstawowa,
                    WartoscPoKonwersji = statystyki.WartoscPoKonwersji
                });
                db.SaveChanges();
            }
        }

        public IEnumerable<StatystykiDTO> GetStatystykis()
        {
            using (ModelStatystyki db = new ModelStatystyki())
            {
                return db.Statystyki.Select(obj => new StatystykiDTO()
                {
                    Data = obj.Data,
                    JednostkaA = obj.JednostkaA,
                    JednostkaB = obj.JednostkaB,
                    NumerPrzeliczenia = obj.NumerPrzeliczenia,
                    WartoscA = obj.WartoscA,
                    WartoscB = obj.WartoscB,
                    WartoscPodstawowa = obj.WartoscPodstawowa,
                    WartoscPoKonwersji = obj.WartoscPoKonwersji
                }).ToList();
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Konwerter8000.Model;

namespace Konwerter8000
{
    class LogDoSQL : ILog
    {
        public void DodajLog(LogDTO Log)
        {
            
            using (LogModel kontekst = new LogModel())
            {
                kontekst.Log.Add(new Log()
                {
        
                    Data = Log.Data,
                    Id = Log.Id,
                    ZJednostki = Log.ZJednostki,
                    DoJednostki = Log.DoJednostki,
                    WartoscDoPrzeliczen = Log.WartoscDoPrzeliczen,
                    WartoscPrzeliczona = Log.WartoscPrzeliczona
                });

                kontekst.SaveChanges();
            }
        }

        public IEnumerable<LogDTO> PobierzLog()
        {
            using (LogModel kontekst = new LogModel())
            {
                return kontekst.Log.Select
                    (
                    obj => new LogDTO()
                    {
                        Data = obj.Data,
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

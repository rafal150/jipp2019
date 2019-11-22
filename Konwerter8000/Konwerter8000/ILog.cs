using System.Collections.Generic;

namespace Konwerter8000
{
    public interface ILog
    {
        void DodajLog(LogDTO log);
        IEnumerable<LogDTO> PobierzLog();
    }
}

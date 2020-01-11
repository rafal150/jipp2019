using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public interface ILogic
    {
        int InputTypID { get; }
        int OutputTypID { get; }

        void Inicjalizuj(IPolaczenie repo, ConvertersService converters);
        string Konwertuj(string value, Miara inputMiara, Miara outputMiara);
        IEnumerable<Statystyka> PobierzStatystyki();
        void UstawOutputTypID(int value);
        void UstawInputTypID(int value);
        IEnumerable<Miara> PobierzListeInputowychMiar();
        IEnumerable<Miara> PobierzListeOutputowychMiar(int typID);
    }
}

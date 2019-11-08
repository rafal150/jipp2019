using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator
{
    public class combobombo
    {
        public List<string> GetUnittypes()
        {  return new List<string>(new[]
           { "Temperatury","Metryczne","Anglosaskie","Morskie","MasyMetryczne","MasyAnglosaskie","MasyInne"});
        }
        public List<string> GetUnittemp()
        { return new List<string>(new[]
            { "C","K","F","R"});
        }
        public List<string> GetUnitmet()
        {
            return new List<string>(new[]
              { "mm","cm","dcm","m","km"});
        }
        public List<string> GetUnitang()
        {
            return new List<string>(new[]
              { "cal","stop","jard","mila"});
        }
        public List<string> GetUnitmor()
        {
            return new List<string>(new[]
              { "kabel","mila morska"});
        }
        public List<string> GetUnitmmet()
        {
            return new List<string>(new[]
              { "mg","g","dkg","kg","t"});
        }
        public List<string> GetUnitmang()
        {
            return new List<string>(new[]
              { "uncja","funt"});
        }
        public List<string> GetUnitother()
        {
            return new List<string>(new[]
              { "karat","kwintal"});
        }
    }
}

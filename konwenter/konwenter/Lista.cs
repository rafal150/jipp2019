using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwenter
{
    public class Lista
    {
        public List<string> GetUnittypyjednostki()
        {
            return new List<string>(new[]
            { "Temperatura np. C,K,itd.","Metryczne np. mm,cm,idt.","Anglosaskie np. cal,mila,itd.","Morskie np. kabel,mila morska",
                "Masy np. mg,g,itd.","MasyAnglosaskie np. uncja, funt","Inne np. karat,kwintal"});
        }
        public List<string> GetUnittemperatura()
        {
            return new List<string>(new[]
              { "C","K","F","R"});
        }
        public List<string> GetUnitmetryczne()
        {
            return new List<string>(new[]
              { "mm","cm","dcm","m","km"});
        }
        public List<string> GetUnitanglo()
        {
            return new List<string>(new[]
              { "cal","stopa","jard","mila"});
        }
        public List<string> GetUnitmorskie()
        {
            return new List<string>(new[]
              { "kabel","mila morska"});
        }
        public List<string> GetUnitmasy()
        {
            return new List<string>(new[]
              { "mg","g","dkg","kg","t"});
        }
        public List<string> GetUnitmanglosaskie()
        {
            return new List<string>(new[]
              { "uncja","funt"});
        }
        public List<string> GetUnitinne()
        {
            return new List<string>(new[]
              { "karat","kwintal"});
        }

    };


        }
    


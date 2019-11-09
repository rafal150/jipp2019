using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Jednostki
{

    class ListsofUnits
    {
        public List<UnitTypes> lsWeight;
        public List<UnitTypes> lsLength;
        public List<UnitTypes> lsTemperature;
        public List<UnitTypes> lsUnits;
 
        public ListsofUnits()
        {
            lsWeight = new List<UnitTypes>();
            lsLength = new List<UnitTypes>();
            lsTemperature = new List<UnitTypes>();
            lsUnits = Enum.GetValues(typeof(UnitTypes)).OfType<UnitTypes>().ToList();
            foreach (UnitTypes val in Enum.GetValues(typeof(UnitTypes)).OfType<UnitTypes>().ToList())
            {
                if (val.GetEnumDescription() == "Weight")
                    this.lsWeight.Add(val);
                else if (val.GetEnumDescription() == "Length")
                    this.lsLength.Add(val);
                else if (val.GetEnumDescription() == "Temperature")
                    this.lsTemperature.Add(val);
            }

        }

    }

    static class UnitsList
    {

        public static ListsofUnits L1 = new ListsofUnits();

        public static List<UnitTypes> lsUnits = L1.lsUnits;
        public static List<UnitTypes> lsWeight = L1.lsWeight;
        public static List<UnitTypes> lsLength = L1.lsLength;
        public static List<UnitTypes> lsTemperature = L1.lsTemperature;
        public static List<String> lsTypes = new List<string> { "Weight", "Length", "Temperature" };



    }
}

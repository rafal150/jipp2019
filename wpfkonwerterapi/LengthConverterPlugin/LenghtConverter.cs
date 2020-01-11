using System;
using System.Collections.Generic;
using ConverterSDK;
namespace LengthConverterPlugin
{
    public class LengthConverter : ConverterSDK.IConvertible
    {
        public string ConverterName => "Długość";
        public List<string> Units =>
                new List<string>()
                {
                    "milimetr",
                    "centymetr",
                    "decymetr",
                    "metr",
                    "kilometr",
                    "cal",
                    "stopa",
                    "jard",
                    "mila",
                    "kabel",
                    "mila morska"
                };
        public string Convert(string unitFrom, string UnitTo, double value)
        {
            //"kilometr", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
            if (unitFrom.Equals(UnitTo))
                return value.ToString();
            //////////////////////
            //k->c
            else if (unitFrom.Equals("kilometr") && UnitTo.Equals("cal"))
                return (value / 25.4).ToString();
            //c->k
            else if (unitFrom.Equals("cal") && UnitTo.Equals("kilometr"))
                return (value * 25.4).ToString();
            ///////////////////
            //k->s
            else if (unitFrom.Equals("kilometr") && UnitTo.Equals("stopa"))
                return (value * 3280.84).ToString();
            ///////////////////
            //s->k
            else if (unitFrom.Equals("stopa") && UnitTo.Equals("kilometr"))
                return (value / 3280.84).ToString();
            ///////////////////
            //k->j
            else if (unitFrom.Equals("kilometr") && UnitTo.Equals("jard"))
                return (value * 1093.61).ToString();
            ///////////////////
            //j->k
            else if (unitFrom.Equals("jard") && UnitTo.Equals("kilometr"))
                return (value / 1093.61).ToString();
            ///////////////////
            //k->m
            else if (unitFrom.Equals("kilometr") && UnitTo.Equals("mila"))
                return (value * 0.62).ToString();
            ///////////////////
            //m->k
            else if (unitFrom.Equals("mila") && UnitTo.Equals("kilometr"))
                return (value / 0.62).ToString();
            ///////////////////
            //k->kb
            else if (unitFrom.Equals("kilometr") && UnitTo.Equals("kabel"))
                return (value * 0.18).ToString();
            ///////////////////
            //kb->k
            else if (unitFrom.Equals("kabel") && UnitTo.Equals("kilometr"))
                return (value / 0.18).ToString();
            ///////////////////
            //k->mm
            else if (unitFrom.Equals("kilometr") && UnitTo.Equals("milimetr"))
                return (value * 0.54).ToString();
            ///////////////////
            //mm->k
            else if (unitFrom.Equals("milimetr") && UnitTo.Equals("kilometr"))
                return (value / 0.54).ToString();
            ///////////////////
            //c->s
            else if (unitFrom.Equals("cal") && UnitTo.Equals("stopa"))
                return (value * 0.08).ToString();
            ///////////////////
            //s->c
            else if (unitFrom.Equals("stopa") && UnitTo.Equals("cal"))
                return (value / 0.08).ToString();
            ///////////////////
            //c->j
            else if (unitFrom.Equals("cal") && UnitTo.Equals("jard"))
                return (value * 0.03).ToString();
            ///////////////////
            //j->c
            else if (unitFrom.Equals("jard") && UnitTo.Equals("cal"))
                return (value / 0.03).ToString();
            ///////////////////
            //c->m
            else if (unitFrom.Equals("cal") && UnitTo.Equals("mila"))
                return (value * 0.000016).ToString();
            ///////////////////
            //m->c
            else if (unitFrom.Equals("mila") && UnitTo.Equals("cal"))
                return (value / 0.000016).ToString();
            ///////////////////
            //c->kb
            else if (unitFrom.Equals("cal") && UnitTo.Equals("kabel"))
                return (value * 0.00013).ToString();
            ///////////////////
            //kb->c
            else if (unitFrom.Equals("kabel") && UnitTo.Equals("cal"))
                return (value / 0.00013).ToString();
            ///////////////////
            //c->mm
            else if (unitFrom.Equals("cal") && UnitTo.Equals("milimetr"))
                return (value * 0.000014).ToString();
            ///////////////////
            //mm->c
            else if (unitFrom.Equals("milimetr") && UnitTo.Equals("cal"))
                return (value / 0.000014).ToString();
            ///////////////////
            //s->j
            else if (unitFrom.Equals("stopa") && UnitTo.Equals("jard"))
                return (value * 0.33).ToString();
            ///////////////////
            //j->s
            else if (unitFrom.Equals("jard") && UnitTo.Equals("stopa"))
                return (value / 0.33).ToString();
            ///////////////////
            //s->m
            else if (unitFrom.Equals("stopa") && UnitTo.Equals("mila"))
                return (value * 0.00018).ToString();
            ///////////////////
            //m->s
            else if (unitFrom.Equals("mila") && UnitTo.Equals("stopa"))
                return (value / 0.00018).ToString();
            ///////////////////
            //s->kb
            else if (unitFrom.Equals("stopa") && UnitTo.Equals("kabel"))
                return (value * 0.0016).ToString();
            ///////////////////
            //kb->s
            else if (unitFrom.Equals("kabel") && UnitTo.Equals("stopa"))
                return (value / 0.0016).ToString();
            ///////////////////
            //s->mm
            else if (unitFrom.Equals("stopa") && UnitTo.Equals("milimetr"))
                return (value * 0.00016).ToString();
            ///////////////////
            //mm->s
            else if (unitFrom.Equals("milimetr") && UnitTo.Equals("stopa"))
                return (value / 0.00016).ToString();
            ///////////////////
            //j->m
            else if (unitFrom.Equals("jard") && UnitTo.Equals("mila"))
                return (value * 0.0005).ToString();
            ///////////////////
            //m->j
            else if (unitFrom.Equals("mila") && UnitTo.Equals("jard"))
                return (value / 0.0005).ToString();
            ///////////////////
            //j->kb
            else if (unitFrom.Equals("jard") && UnitTo.Equals("kabel"))
                return (value * 0.004).ToString();
            ///////////////////
            //kb->j
            else if (unitFrom.Equals("kabel") && UnitTo.Equals("jard"))
                return (value / 0.004).ToString();
            ///////////////////
            //j->mm
            else if (unitFrom.Equals("jard") && UnitTo.Equals("milimetr"))
                return (value * 0.0004).ToString();
            ///////////////////
            //mm->j
            else if (unitFrom.Equals("milimetr") && UnitTo.Equals("jard"))
                return (value / 0.0004).ToString();
            ///////////////////
            //m->kb
            else if (unitFrom.Equals("mila") && UnitTo.Equals("kabel"))
                return (value * 8.68).ToString();
            ///////////////////
            //kb->m
            else if (unitFrom.Equals("kabel") && UnitTo.Equals("mila"))
                return (value / 8.68).ToString();
            ///////////////////
            //m->mm
            else if (unitFrom.Equals("mila") && UnitTo.Equals("milimetr"))
                return (value * 0.86).ToString();
            ///////////////////
            //mm->m
            else if (unitFrom.Equals("milimetr") && UnitTo.Equals("mila"))
                return (value / 0.86).ToString();
            ///////////////////
            //kb->mm
            else if (unitFrom.Equals("kabel") && UnitTo.Equals("milimetr"))
                return (value * 0.1).ToString();
            ///////////////////
            //mm->kb
            else //if (indexFrom == 6 && indexTo == 5)
                return (value / 0.1).ToString();
            ///////////////////

            //return null;
        }
    }
}

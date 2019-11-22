using System;
using System.Collections.Generic;
using KonwerterSDK;
namespace LengthConverterPlugin
{
    public class LengthConverter : KonwerterSDK.IConvertible
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
        public string Convert(int indexFrom, int indexTo, double value)
        {
            //"kilometr", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
            if (indexFrom == indexTo)
                return value.ToString();
            //////////////////////
            //k->c
            else if (indexFrom == 0 && indexTo == 1)
                return (value / 25.4).ToString();
            //c->k
            else if (indexFrom == 1 && indexTo == 0)
                return (value * 25.4).ToString();
            ///////////////////
            //k->s
            else if (indexFrom == 0 && indexTo == 2)
                return (value * 3280.84).ToString();
            ///////////////////
            //s->k
            else if (indexFrom == 2 && indexTo == 0)
                return (value / 3280.84).ToString();
            ///////////////////
            //k->j
            else if (indexFrom == 0 && indexTo == 3)
                return (value * 1093.61).ToString();
            ///////////////////
            //j->k
            else if (indexFrom == 3 && indexTo == 0)
                return (value / 1093.61).ToString();
            ///////////////////
            //k->m
            else if (indexFrom == 0 && indexTo == 4)
                return (value * 0.62).ToString();
            ///////////////////
            //m->k
            else if (indexFrom == 4 && indexTo == 0)
                return (value / 0.62).ToString();
            ///////////////////
            //k->kb
            else if (indexFrom == 0 && indexTo == 5)
                return (value * 0.18).ToString();
            ///////////////////
            //kb->k
            else if (indexFrom == 5 && indexTo == 0)
                return (value / 0.18).ToString();
            ///////////////////
            //k->mm
            else if (indexFrom == 0 && indexTo == 6)
                return (value * 0.54).ToString();
            ///////////////////
            //mm->k
            else if (indexFrom == 6 && indexTo == 0)
                return (value / 0.54).ToString();
            ///////////////////
            //c->s
            else if (indexFrom == 1 && indexTo == 2)
                return (value * 0.08).ToString();
            ///////////////////
            //s->c
            else if (indexFrom == 2 && indexTo == 1)
                return (value / 0.08).ToString();
            ///////////////////
            //c->j
            else if (indexFrom == 1 && indexTo == 3)
                return (value * 0.03).ToString();
            ///////////////////
            //j->c
            else if (indexFrom == 3 && indexTo == 1)
                return (value / 0.03).ToString();
            ///////////////////
            //c->m
            else if (indexFrom == 1 && indexTo == 4)
                return (value * 0.000016).ToString();
            ///////////////////
            //m->c
            else if (indexFrom == 4 && indexTo == 1)
                return (value / 0.000016).ToString();
            ///////////////////
            //c->kb
            else if (indexFrom == 1 && indexTo == 5)
                return (value * 0.00013).ToString();
            ///////////////////
            //kb->c
            else if (indexFrom == 5 && indexTo == 1)
                return (value / 0.00013).ToString();
            ///////////////////
            //c->mm
            else if (indexFrom == 1 && indexTo == 6)
                return (value * 0.000014).ToString();
            ///////////////////
            //mm->c
            else if (indexFrom == 6 && indexTo == 1)
                return (value / 0.000014).ToString();
            ///////////////////
            //s->j
            else if (indexFrom == 2 && indexTo == 3)
                return (value * 0.33).ToString();
            ///////////////////
            //j->s
            else if (indexFrom == 3 && indexTo == 2)
                return (value / 0.33).ToString();
            ///////////////////
            //s->m
            else if (indexFrom == 2 && indexTo == 4)
                return (value * 0.00018).ToString();
            ///////////////////
            //m->s
            else if (indexFrom == 4 && indexTo == 2)
                return (value / 0.00018).ToString();
            ///////////////////
            //s->kb
            else if (indexFrom == 2 && indexTo == 5)
                return (value * 0.0016).ToString();
            ///////////////////
            //kb->s
            else if (indexFrom == 5 && indexTo == 2)
                return (value / 0.0016).ToString();
            ///////////////////
            //s->mm
            else if (indexFrom == 2 && indexTo == 6)
                return (value * 0.00016).ToString();
            ///////////////////
            //mm->s
            else if (indexFrom == 6 && indexTo == 2)
                return (value / 0.00016).ToString();
            ///////////////////
            //j->m
            else if (indexFrom == 3 && indexTo == 4)
                return (value * 0.0005).ToString();
            ///////////////////
            //m->j
            else if (indexFrom == 4 && indexTo == 3)
                return (value / 0.0005).ToString();
            ///////////////////
            //j->kb
            else if (indexFrom == 3 && indexTo == 5)
                return (value * 0.004).ToString();
            ///////////////////
            //kb->j
            else if (indexFrom == 5 && indexTo == 3)
                return (value / 0.004).ToString();
            ///////////////////
            //j->mm
            else if (indexFrom == 3 && indexTo == 6)
                return (value * 0.0004).ToString();
            ///////////////////
            //mm->j
            else if (indexFrom == 6 && indexTo == 3)
                return (value / 0.0004).ToString();
            ///////////////////
            //m->kb
            else if (indexFrom == 4 && indexTo == 5)
                return (value * 8.68).ToString();
            ///////////////////
            //kb->m
            else if (indexFrom == 5 && indexTo == 4)
                return (value / 8.68).ToString();
            ///////////////////
            //m->mm
            else if (indexFrom == 4 && indexTo == 6)
                return (value * 0.86).ToString();
            ///////////////////
            //mm->m
            else if (indexFrom == 6 && indexTo == 4)
                return (value / 0.86).ToString();
            ///////////////////
            //kb->mm
            else if (indexFrom == 5 && indexTo == 6)
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

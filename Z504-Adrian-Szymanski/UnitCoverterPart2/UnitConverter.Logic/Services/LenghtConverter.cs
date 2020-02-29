using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class LenghtConverter : IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopy", "jard", "mila", "mila morska", "kabel" });

        public double Convert(string unitFrom, string unitTo, double value)
        {

            //MILIMETRY NA INNE JEDNOSTKI
            if (unitFrom == "mm" && unitTo == "mm")        //mm na mm
            {

                value = (value * 1);

            }

            if (unitFrom == "mm" && unitTo == "cm")        //mm na cm
            {

                value = (value * 0.1);

            }

            if (unitFrom == "mm" && unitTo == "dcm")        //mm na dcm
            {

                value = (value * 0.01);

            }

            if (unitFrom == "mm" && unitTo == "m")        //mm na m
            {

                value = (value * 0.001);

            }

            if (unitFrom == "mm" && unitTo == "km")        //mm na km
            {

                value = (value * 0.000001);

            }

            if (unitFrom == "mm" && unitTo == "cal")        //mm na cal
            {

                value = (value * 0.039370);

            }

            if (unitFrom == "mm" && unitTo == "stopy")        //mm na stopy
            {

                value = (value * 0.0032808);

            }

            if (unitFrom == "mm" && unitTo == "jard")        //mm na jard
            {

                value = (value * 0.001093);

            }

            if (unitFrom == "mm" && unitTo == "mila")        //mm na mila
            {

                value = (value * 0.0000006214);

            }

            if (unitFrom == "mm" && unitTo == "mila morska")        //mm na mila morska
            {

                value = (value * 0.00000054);

            }

            if (unitFrom == "mm" && unitTo == "kabel")        //mm na KABEL
            {

                value = (value * 0.00000054 * 0.1);

            }

            //CENTYMETRY NA INNE JEDNOSTKI
            if (unitFrom == "cm" && unitTo == "mm")        //cm na mm
            {

                value = (value * 10);

            }

            if (unitFrom == "cm" && unitTo == "cm")        //cm na cm
            {

                value = (value * 1);

            }

            if (unitFrom == "cm" && unitTo == "dcm")        //cm na dcm
            {

                value = (value * 0.1);

            }

            if (unitFrom == "cm" && unitTo == "m")        //cm na m
            {

                value = (value * 0.01);

            }

            if (unitFrom == "cm" && unitTo == "km")        //cm na km
            {

                value = (value * 0.00001);

            }

            if (unitFrom == "cm" && unitTo == "cal")        //cm na cal
            {

                value = (value * 0.39370);

            }

            if (unitFrom == "cm" && unitTo == "stopy")        //cm na stopy
            {

                value = (value * 0.032808);

            }

            if (unitFrom == "cm" && unitTo == "jard")        //cm na jard
            {

                value = (value * 0.01093);

            }

            if (unitFrom == "cm" && unitTo == "mila")        //cm na mila
            {

                value = (value * 0.000006214);

            }

            if (unitFrom == "cm" && unitTo == "mila morska")        //cm na mila morska
            {

                value = (value * 0.0000054);

            }

            if (unitFrom == "cm" && unitTo == "kabel")        //cm na KABEL
            {

                value = (value * 0.0000054 * 0.1);

            }

            //DECYMETRY NA INNE JEDNOSTKI
            if (unitFrom == "dcm" && unitTo == "mm")        //dcm na mm
            {

                value = (value * 100);

            }

            if (unitFrom == "dcm" && unitTo == "cm")        //dcm na cm
            {

                value = (value * 10);

            }

            if (unitFrom == "dcm" && unitTo == "dcm")        //dcm na dcm
            {

                value = (value * 1);

            }

            if (unitFrom == "dcm" && unitTo == "m")        //dcm na m
            {

                value = (value * 0.1);

            }

            if (unitFrom == "dcm" && unitTo == "km")        //dcm na km
            {

                value = (value * 0.0001);

            }

            if (unitFrom == "dcm" && unitTo == "cal")        //dcm na cal
            {

                value = (value * 3.9370);

            }

            if (unitFrom == "dcm" && unitTo == "stopy")        //dcm na stopy
            {

                value = (value * 0.32808);

            }

            if (unitFrom == "dcm" && unitTo == "jard")        //dcm na jard
            {

                value = (value * 0.1093);

            }

            if (unitFrom == "dcm" && unitTo == "mila")        //dcm na mila
            {

                value = (value * 0.00006214);

            }

            if (unitFrom == "dcm" && unitTo == "mila morska")        //dcm na mila morska
            {

                value = (value * 0.000054);

            }

            if (unitFrom == "dcm" && unitTo == "kabel")        //dcm na KABEL
            {

                value = (value * 0.000054 * 0.1);

            }

            //METRY NA INNE JEDNOSTKI
            if (unitFrom == "m" && unitTo == "mm")        //m na mm
            {

                value = (value * 1000);

            }

            if (unitFrom == "m" && unitTo == "cm")        //m na cm
            {

                value = (value * 100);

            }

            if (unitFrom == "m" && unitTo == "dcm")        //m na dcm
            {

                value = (value * 10);

            }

            if (unitFrom == "m" && unitTo == "m")        //m na m
            {

                value = (value * 1);

            }

            if (unitFrom == "m" && unitTo == "km")        //m na km
            {

                value = (value * 0.001);

            }

            if (unitFrom == "m" && unitTo == "cal")        //m na cal
            {

                value = (value * 39.370);

            }

            if (unitFrom == "m" && unitTo == "stopy")        //m na stopy
            {

                value = (value * 3.2808);

            }

            if (unitFrom == "m" && unitTo == "jard")        //m na jard
            {

                value = (value * 1.093);

            }

            if (unitFrom == "m" && unitTo == "mila")        //m na mila
            {

                value = (value * 0.0006214);

            }

            if (unitFrom == "m" && unitTo == "mila morska")        //m na mila morska
            {

                value = (value * 0.00054);

            }

            if (unitFrom == "m" && unitTo == "kabel")        //m na KABEL
            {

                value = (value * 0.00054 * 0.1);

            }

            //KILOMETRY NA INNE JEDNOSTKI
            if (unitFrom == "km" && unitTo == "mm")        //km na mm
            {

                value = (value * 1000000);

            }

            if (unitFrom == "km" && unitTo == "cm")        //km na cm
            {

                value = (value * 100000);

            }

            if (unitFrom == "km" && unitTo == "dcm")        //km na cm
            {

                value = (value * 10000);

            }

            if (unitFrom == "km" && unitTo == "m")        //km na m
            {

                value = (value * 1000);

            }

            if (unitFrom == "km" && unitTo == "km")        //km na km
            {

                value = (value * 1);

            }

            if (unitFrom == "km" && unitTo == "cal")        //km na cal
            {

                value = (value * 39370);

            }

            if (unitFrom == "km" && unitTo == "stopy")        //km na stopy
            {

                value = (value * 3280.8);

            }

            if (unitFrom == "km" && unitTo == "jard")        //km na jard
            {

                value = (value * 1093);

            }

            if (unitFrom == "km" && unitTo == "mila")        //km na mila
            {

                value = (value * 0.6214);

            }

            if (unitFrom == "km" && unitTo == "mila morska")        //km na mila morska
            {

                value = (value * 0.54);

            }

            if (unitFrom == "km" && unitTo == "kabel")        //km na KABEL
            {

                value = (value * 0.54 * 0.1);

            }

            //CAL NA INNE JEDNOSTKI
            if (unitFrom == "cal" && unitTo == "mm")        //cal na mm
            {

                value = (value * 25.4);

            }

            if (unitFrom == "cal" && unitTo == "cm")        //cal na cm
            {

                value = (value * 2.54);

            }

            if (unitFrom == "cal" && unitTo == "dcm")        //cal na dcm
            {

                value = (value * 0.254);

            }

            if (unitFrom == "cal" && unitTo == "m")        //cal na m
            {

                value = (value * 0.0254);

            }

            if (unitFrom == "cal" && unitTo == "km")        //cal na km
            {

                value = (value * 0.0000254);

            }

            if (unitFrom == "cal" && unitTo == "cal")        //cal na cal
            {

                value = (value * 1);

            }

            if (unitFrom == "cal" && unitTo == "stopy")        //cal na stopy
            {

                value = (value * 0.833);

            }

            if (unitFrom == "cal" && unitTo == "jard")        //cal na jard
            {

                value = (value * 0.0277);

            }

            if (unitFrom == "cal" && unitTo == "mila")        //cal na mila
            {

                value = (value * 0.00001578);

            }

            if (unitFrom == "cal" && unitTo == "mila morska")        //cal na mila morska
            {

                value = (value * 0.0000137);

            }

            if (unitFrom == "cal" && unitTo == "kabel")        //cal na KABEL
            {

                value = (value * 0.0000137 * 0.1);

            }

            //STOPY NA INNE JEDNOSTKI
            if (unitFrom == "stopy" && unitTo == "mm")        //stopy na mm
            {

                value = (value * 304.8);

            }

            if (unitFrom == "stopy" && unitTo == "cm")        //stopy na cm
            {

                value = (value * 30.48);

            }

            if (unitFrom == "stopy" && unitTo == "dcm")        //stopy na dcm
            {

                value = (value * 3.048);

            }

            if (unitFrom == "stopy" && unitTo == "m")        //stopy na m
            {

                value = (value * 0.3048);

            }

            if (unitFrom == "stopy" && unitTo == "km")        //stopy na km
            {

                value = (value * 0.0003048);

            }

            if (unitFrom == "stopy" && unitTo == "cal")        //stopy na cal
            {

                value = (value * 12);

            }

            if (unitFrom == "stopy" && unitTo == "stopy")        //stopy na stopy
            {

                value = (value * 1);

            }

            if (unitFrom == "stopy" && unitTo == "jard")        //stopy na jard
            {

                value = (value * 0.3333);

            }

            if (unitFrom == "stopy" && unitTo == "mila")        //stopy na mila
            {

                value = (value * 0.00018939);

            }

            if (unitFrom == "stopy" && unitTo == "mila morska")        //stopy na mila morska
            {

                value = (value * 0.000164);

            }

            if (unitFrom == "stopy" && unitTo == "kabel")        //stopy na KABEL
            {

                value = (value * 0.000164 * 0.1);

            }

            //JARDY NA INNE JEDNOSTKI
            if (unitFrom == "jard" && unitTo == "mm")        //jardy na mm
            {

                value = (value * 914.4);

            }

            if (unitFrom == "jard" && unitTo == "cm")        //jardy na cm
            {

                value = (value * 91.44);

            }

            if (unitFrom == "jard" && unitTo == "dcm")        //jardy na dcm
            {

                value = (value * 9.144);

            }

            if (unitFrom == "jard" && unitTo == "m")        //jardy na m
            {

                value = (value * 0.9144);

            }

            if (unitFrom == "jard" && unitTo == "km")        //jardy na km
            {

                value = (value * 0.0009144);

            }

            if (unitFrom == "jard" && unitTo == "cal")        //jardy na cal
            {

                value = (value * 36);

            }

            if (unitFrom == "jard" && unitTo == "stopy")        //jardy na stopy
            {

                value = (value * 3);

            }

            if (unitFrom == "jard" && unitTo == "jard")        //jardy na jard
            {

                value = (value * 1);

            }

            if (unitFrom == "jard" && unitTo == "mila")        //jardy na mila
            {

                value = (value * 0.0005681);

            }

            if (unitFrom == "jard" && unitTo == "mila morska")        //jardy na mila morska
            {

                value = (value * 0.0004937);

            }

            if (unitFrom == "jard" && unitTo == "kabel")        //jardy na KABEL
            {

                value = (value * 0.0004937 * 0.1);

            }

            //Mile NA INNE JEDNOSTKI
            if (unitFrom == "mila" && unitTo == "mm")        //mile na mm
            {

                value = (value * 1609344);

            }

            if (unitFrom == "mila" && unitTo == "cm")        //mile na cm
            {

                value = (value * 160934.4);

            }

            if (unitFrom == "mila" && unitTo == "dcm")        //mile na dcm
            {

                value = (value * 16093.44);

            }

            if (unitFrom == "mila" && unitTo == "m")        //mile na m
            {

                value = (value * 1609.344);

            }

            if (unitFrom == "mila" && unitTo == "km")        //mile na km
            {

                value = (value * 1.609344);

            }

            if (unitFrom == "mila" && unitTo == "cal")        //mile na cal
            {

                value = (value * 63360);

            }

            if (unitFrom == "mila" && unitTo == "stopy")        //mile na stopy
            {

                value = (value * 5280);

            }

            if (unitFrom == "mila" && unitTo == "jard")        //mile na jard
            {

                value = (value * 1760);

            }

            if (unitFrom == "mila" && unitTo == "mila")        //mile na mile
            {

                value = (value * 1);

            }

            if (unitFrom == "mila" && unitTo == "mila morska")        //mile na mila morska
            {

                value = (value * 0.8689);

            }

            if (unitFrom == "mila" && unitTo == "kabel")        //mile na KABEL
            {

                value = (value * 0.8689 * 0.1);

            }

            //KABEL NA INNE JEDNOSTKI
            if (unitFrom == "kabel" && unitTo == "mm")        //kabel na mm
            {

                value = (value * 185200);

            }

            if (unitFrom == "kabel" && unitTo == "cm")        //kabel na cm
            {

                value = (value * 18520);

            }

            if (unitFrom == "kabel" && unitTo == "dcm")        //kabel na dcm
            {

                value = (value * 18520);

            }

            if (unitFrom == "kabel" && unitTo == "m")        //kabel na m
            {

                value = (value * 1852);

            }

            if (unitFrom == "kabel" && unitTo == "km")        //kabel na km
            {

                value = (value * 1.852);

            }

            if (unitFrom == "kabel" && unitTo == "cal")        //kabel na cal
            {

                value = (value * 7291);

            }

            if (unitFrom == "kabel" && unitTo == "stopy")        //kabel na stopy
            {

                value = (value * 607.6);

            }

            if (unitFrom == "kabel" && unitTo == "jard")        //kabel na jard
            {

                value = (value * 202.5);

            }

            if (unitFrom == "kabel" && unitTo == "mila")        //kabel na mile
            {

                value = (value * 0.115);

            }

            if (unitFrom == "kabel" && unitTo == "mila morska")        //kabel na mila morska
            {

                value = (value * 0.1);

            }

            if (unitFrom == "kabel" && unitTo == "kabel")        //kabel na KABEL
            {

                value = (value * 1);

            }

            //Mile NA INNE JEDNOSTKI
            if (unitFrom == "mila morska" && unitTo == "mm")        //mile na mm
            {

                value = (value * 1852000);

            }

            if (unitFrom == "mila morska" && unitTo == "cm")        //mila morska na cm
            {

                value = (value * 185200);

            }

            if (unitFrom == "mila morska" && unitTo == "dcm")        //mila morska na dcm
            {

                value = (value * 18520);

            }

            if (unitFrom == "mila morska" && unitTo == "m")        //mila morska na m
            {

                value = (value * 1852);

            }

            if (unitFrom == "mila morska" && unitTo == "km")        //mila morska na km
            {

                value = (value * 1.852);

            }

            if (unitFrom == "mila morska" && unitTo == "cal")        //mila morska na cal
            {

                value = (value * 72913.4);

            }

            if (unitFrom == "mila morska" && unitTo == "stopy")        //mila morska na stopy
            {

                value = (value * 6076);

            }

            if (unitFrom == "mila morska" && unitTo == "jard")        //mila morska na jard
            {

                value = (value * 2025.4);

            }

            if (unitFrom == "mila morska" && unitTo == "mila")        //mila morska na mile
            {

                value = (value * 1.15);

            }

            if (unitFrom == "mila morska" && unitTo == "mila morska")        //mila morska na mila morska
            {

                value = (value * 1);

            }

            if (unitFrom == "mila morska" && unitTo == "kabel")        //mila morska na KABEL
            {

                value = (value * 10);

            }
            return value;
        }
    }
}

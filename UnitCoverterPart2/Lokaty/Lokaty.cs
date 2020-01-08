using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lokaty
{
    public class Lokaty
    {
        static Lokaty instance;

        List<int> typyLokat = new List<int>() { 1, 3, 6, 12};
        List<double> oprocLokat = new List<double>() { 0.6, 0.8, 1, 1.1};

        public static Lokaty GetInstance()
        {
            if (instance == null)
                instance = new Lokaty();

            return instance;
        }

        double dajOproc(int lokata)
        {
            for (int i = 0; i < typyLokat.Count; i++)
                if (lokata == typyLokat[i])
                    return oprocLokat[i];

            return 0;
        }

        public List<int> GetLokaty()
        {
            return typyLokat;
        }

        public double policzKapital(int lokata, int ileMiesiecy, double value)
        {
            for(int i=1; i<=(int)ileMiesiecy/lokata; i++)
            {
                value += value * (dajOproc(lokata)/12);
            }

            return value;
        }
    }
}

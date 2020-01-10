using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConverterSDK;

namespace Speed
{
    public class SpeedConverter : ConverterInterface
    {
        public double speed;
        public double kmph
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public double mph
        {
            get { return this.speed / 1.609344; }
            set { this.speed = value * 1.609344; }
        }

        public double meph
        {
            get { return this.speed / 3.6; }
            set { this.speed = value * 3.6; }
        }

        public static List<string> GetListOfProperties()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(SpeedConverter).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.SDK;

namespace WpfApp1
{
    public class BytesMeasure : IGetMeasures
    {
        private string nam = "bytes";
        public string Nam { get => nam; }
        public List<string> Units => new List<string>(new[] { "byte", "kbit", "mbit" });
        public double Convert(string from, string to, double value_from)
        {
            switch (from)
            {
                case "byte":
                    break;
                case "kbit":
                    value_from *= 1024;
                    break;
                case "mbit":
                    value_from *= (1024 * 1024);
                    break;
            }
            switch (to)
            {
                case "byte":
                    break;
                case "kbit":
                    value_from /= 1024;
                    break;
                case "mbit":
                    value_from /= (1024 * 1024);
                    break;
            }
            return value_from;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter
{
    public class StatDTO
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }
    }
}

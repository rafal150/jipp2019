using JIPP5_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Interfaces
{
    public interface IConverterHelper
    {
        string Convert(Unit fromUnit, decimal input, Unit toUnit);
    }
}

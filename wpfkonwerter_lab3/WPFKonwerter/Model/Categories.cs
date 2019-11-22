using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFKonwerter.Model
{
    public class Categories
    {
        public List<string> Category { get; set; }

        public Categories()
        {
            Category = new List<string>() { "Temperatura", "Długość", "Masa" };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    class MainMenu
    {
        private List<Unit> units_of_choice = new List<Unit>();
        private List<Unit> units_of_temp = new List<Unit>();
        private List<Unit> units_of_lenght = new List<Unit>();
        private List<Unit> unints_of_weight = new List<Unit>();

        public List<Unit> Units_of_choice { get => units_of_choice; set => units_of_choice = value; }
        public List<Unit> Units_of_temp { get => units_of_temp; set => units_of_temp = value; }
        public List<Unit> Units_of_lenght { get => units_of_lenght; set => units_of_lenght = value; }
        public List<Unit> Unints_of_weight { get => unints_of_weight; set => unints_of_weight = value; }

        public void Populate()
        {
            Units_of_temp.Add(new Cels());
            Units_of_temp.Add(new Kelv());
            Units_of_temp.Add(new Fahr());
            Units_of_temp.Add(new Rank());
            Units_of_lenght.Add(new Mmetr());
            Units_of_lenght.Add(new Cmetr());
            Units_of_lenght.Add(new Dmetr());
            Units_of_lenght.Add(new Metr());
            Units_of_lenght.Add(new Inch());
            Units_of_lenght.Add(new Foot());
            Units_of_lenght.Add(new Yard());
            Units_of_lenght.Add(new Mile());
            Units_of_lenght.Add(new Nauticalm());
            Units_of_lenght.Add(new Nauticalcable());
            Unints_of_weight.Add(new Kilogram());
            Unints_of_weight.Add(new Gram());
            Unints_of_weight.Add(new Dgram());
            Unints_of_weight.Add(new Tonne());
            Unints_of_weight.Add(new Ounce());
            Unints_of_weight.Add(new Pound());
            Unints_of_weight.Add(new Carat());
            Unints_of_weight.Add(new Quintal());
        }
    }
}

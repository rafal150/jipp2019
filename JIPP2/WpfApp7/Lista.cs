using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppJIPP
{

    public class Mainlist
    {
        private List<Jednostki> wybor_miary = new List<Jednostki>();
        private List<Jednostki> jedn_temp = new List<Jednostki>();
        private List<Jednostki> jedn_dlugosci = new List<Jednostki>();
        private List<Jednostki> jedn_masy = new List<Jednostki>(); 

        public List<Jednostki> Wybor_miary
        {
            get => wybor_miary;
            set => wybor_miary = value;
        }
        public List<Jednostki> Jedn_temp
        {
            get => jedn_temp;
            set => jedn_temp = value;
        }
        public List<Jednostki> Jedn_dlugosci
        {
            get => jedn_dlugosci;
            set => jedn_dlugosci = value;
        }
        public List<Jednostki> Jedn_masy
        {
            get => jedn_masy;
            set => jedn_masy = value;
        }

        public void kolekcja()
        {
            Jedn_temp.Add(new Celsjusz());
            Jedn_temp.Add(new Kelvin());
            Jedn_temp.Add(new Rankine());
            Jedn_temp.Add(new Fahrenheit());

            Jedn_masy.Add(new Kilogram());
            Jedn_masy.Add(new Tona());
            Jedn_masy.Add(new Gram());
            Jedn_masy.Add(new Dekagram());
            Jedn_masy.Add(new Karat());
            Jedn_masy.Add(new Uncja());
            Jedn_masy.Add(new Kwintal());
            Jedn_masy.Add(new Funt());

            Jedn_dlugosci.Add(new Metr());
            Jedn_dlugosci.Add(new Milimetr());
            Jedn_dlugosci.Add(new Centymetr());
            Jedn_dlugosci.Add(new Decymetr());
            Jedn_dlugosci.Add(new Kilometr());
            Jedn_dlugosci.Add(new Mila());
            Jedn_dlugosci.Add(new Jard());
            Jedn_dlugosci.Add(new Cal());
            Jedn_dlugosci.Add(new Stopa());
            Jedn_dlugosci.Add(new Milamorska());
            Jedn_dlugosci.Add(new Kabel());
            
        }
    }
}

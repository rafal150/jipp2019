using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Shapes;

namespace SEM5WPF_1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IStatystykiRepozytorium repozytorium;
        public MainWindow(IStatystykiRepozytorium repo)
        {

            InitializeComponent();
            this.repozytorium = repo;
            this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();

            ListaDaneA();
            ListaDaneB();
            ListaMiarA();
            ListaMass();
           // PobierzTabele();       
        }


        public void ListaDaneA()
        {
            this.CboxListA.ItemsSource = new List<string>(new[]
            {
                "Celsjusze","Kelviny","Farainhaity","Rinkine'a",
            });

        }
        public void ListaDaneB()
        {
            this.CboxListB.ItemsSource = new List<string>(new[]
            {
                "Celsjusze","Kelviny","Farainhaity","Rinkine'a",
            });

        }

        public void ListaMiarA()
        {
            this.CboxListMeasureA.ItemsSource = new List<string>(new[]
            {
                "Metryczne","Anglosaskie","Morskie",
           });
            this.CboxListMeasureB.ItemsSource = new List<string>(new[]
           {
                "Metryczne","Anglosaskie","Morskie",
           });


        }

        public void ListaMass()
        {
            this.CboxListMassA.ItemsSource = new List<string>(new[]
            {
                "Metryczne","Anglosaskie","Inne"
            });
            this.CboxListMassB.ItemsSource = new List<string>(new[]
            {
                "Metryczne","Anglosaskie","Inne"
            });
        }


        private void ButtonCount_Click(object sender, RoutedEventArgs e)
        {
            double K = 273.15;
            double W, Z;
            Z = double.Parse(TextValue.Text);
            string wartoscA = this.CboxListA.SelectedItem.ToString();
            string wartoscB = this.CboxListB.SelectedItem.ToString();

            switch (wartoscA)
            {
                case "Celsjusze":

                    if (wartoscA == "Celsjusze" && wartoscB == "Kelviny")
                    {
                        W = Z + K; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Celsjusze" && wartoscB == "Farainhaity")
                    {
                        W = (Z * 1.8) + 32; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Celsjusze" && wartoscB == "Rinkine'a")
                    {
                        W = (Z + K) * 1.8; TextScore.Text = W.ToString();
                    }
                    break;

                case "Kelviny":
                    if (wartoscA == "Kelviny" && wartoscB == "Celsjusze")
                    {
                        W = Z - K; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Kelviny" && wartoscB == "Farainhaity")
                    {
                        W = ((Z - K) * 1.8) + 32; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Kelviny" && wartoscB == "Rinkine'a")
                    {
                        W = ((Z - K) * 1.8) + 491.67; TextScore.Text = W.ToString();
                    }
                    break;
                case "Farainhaity":
                    if (wartoscA == "Farainhaity" && wartoscB == "Celsjusze")
                    {
                        W = (Z - 32) * 5 / 9; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Farainhaity" && wartoscB == "Kelviny")
                    {
                        W = (Z + 459.67) * 5 / 9; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Farainhaity" && wartoscB == "Rinkine'a")
                    {
                        W = Z + 459.67; TextScore.Text = W.ToString();
                    }
                    break;
                case "Rinkine'a":
                    if (wartoscA == "Rinkine'a" && wartoscB == "Celsjusze")
                    {
                        W = (Z / 1.8) - K; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Rinkine'a" && wartoscB == "Kelviny")
                    {
                        W = (Z / 1.8) + K; TextScore.Text = W.ToString();
                    }
                    else if (wartoscA == "Rinkine'a" && wartoscB == "Farainhaity")
                    {
                        W = Z - 459.67; TextScore.Text = W.ToString();
                    }
                    break;
                default:
                    break;
            }

            StatystykiDTO sDTO = new StatystykiDTO()
            {
                WartoscPodstawowa = double.Parse(TextValue.Text),
                WartoscPoKonwersji = double.Parse(TextScore.Text),
                WartoscA = CboxListA.Text,
                WartoscB = CboxListB.Text,
                Data = DateTime.Now
            };
            this.repozytorium.DodajStatystyki(sDTO);
            this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();

        }

        private void CboxListMeasureA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wartoscC = this.CboxListMeasureA.SelectedItem.ToString();

            if (wartoscC == "Metryczne")
            {
                this.CboxListUnits.ItemsSource = new List<string>(new[]
           {
                "mm","cm","dm","m","km"
            });
            }
            else if (wartoscC == "Anglosaskie")
            {
                this.CboxListUnits.ItemsSource = new List<string>(new[]
       {
                "cal","stopa","yard","mila",
            });
            }
            else
            {
                this.CboxListUnits.ItemsSource = new List<string>(new[]
                {
                "kabel","mila morska",
            });
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double Z, W, Y = 1.09361, Ft = 3.28, Inch = 39.37;
            string wartoscA = this.CboxListUnits.SelectedItem.ToString();
            string wartoscB = this.CboxListUnitsB.SelectedItem.ToString();
            Z = double.Parse(TextValue2.Text);

            switch (wartoscA)
            {
                case "mm":
                    if (wartoscB == "yard")
                    {
                        W = (Z / 1000) * Y; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = (Z / 1000) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = (Z / 1000) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.000000621); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z / 1000) * 0.0053993; TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z / 1000) * 0.000539957; TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "cm":
                    if (wartoscB == "yard")
                    {
                        W = (Z / 100) * Y; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = (Z / 100) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = (Z / 100) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.00000621); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z / 100) * 0.0053993; TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z / 100) * 0.000539957; TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "dm":
                    if (wartoscB == "yard")
                    {
                        W = (Z / 10) * Y; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = (Z / 10) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = (Z / 10) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.0000621); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z / 10) * 0.0053993; TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z / 10) * 0.000539957; TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "m":
                    if (wartoscB == "yard")
                    {
                        W = Z * Y; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = Z * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = Z * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.000621); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = Z * 0.0053993; TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = Z * 0.000539957; TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "km":
                    if (wartoscB == "yard")
                    {
                        W = (Z * 1000) * Y; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = (Z * 1000) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = (Z * 1000) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.621); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z * 1000) * 0.0053993; TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 1000) * 0.000539957; TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "cal":
                    if (wartoscB == "mm")
                    {
                        W = (Z * 25.4); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cm")
                    {
                        W = (Z * 2.54) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "dm")
                    {
                        W = (Z * 0.254) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "m")
                    {
                        W = (Z * 0.0254); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.00001578); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z * 0.0001371); TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 0.00001371); TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "stopa":
                    if (wartoscB == "mm")
                    {
                        W = (Z * 304.8); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cm")
                    {
                        W = (Z * 30.48); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "dm")
                    {
                        W = (Z * 3.048) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "m")
                    {
                        W = (Z * 0.3048); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.00018939); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z * 608); TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 0.00016458); TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "yard":
                    if (wartoscB == "mm")
                    {
                        W = (Z * 914.4); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cm")
                    {
                        W = (Z * 91.4) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "dm")
                    {
                        W = (Z * 9.144) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "m")
                    {
                        W = (Z * 0.9144); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "mila")
                    {
                        W = (Z * 0.00056818); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z * 0.0049374); TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 0.00049374); TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "mila":
                    if (wartoscB == "mm")
                    {
                        W = (Z * 1609344); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cm")
                    {
                        W = (Z * 160934.4) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "dm")
                    {
                        W = (Z * 16093.44) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "m")
                    {
                        W = (Z * 1609.344); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "kabel")
                    {
                        W = (Z * 8.6897624); TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 0.86897624); TextScoreUnits.Text = W.ToString();
                    }
                    break;
                case "kabel":
                    if (wartoscB == "mm")
                    {
                        W = (Z * 185200); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cm")
                    {
                        W = (Z * 18520) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "dm")
                    {
                        W = (Z * 1852) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "m")
                    {
                        W = (Z * 185.2); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "km")
                    {
                        W = (Z * 1852); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = (Z * 7291.3392); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = (Z * 607.6116); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "yard")
                    {
                        W = (Z * 202.5372); TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 0.1151); TextScoreUnits.Text = W.ToString();
                    }

                    break;
                case "mila morska":
                    if (wartoscB == "mm")
                    {
                        W = (Z * 1852000); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cm")
                    {
                        W = (Z * 185200) * Ft; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "dm")
                    {
                        W = (Z * 18520) * Inch; TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "m")
                    {
                        W = (Z * 1852); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "km")
                    {
                        W = (Z * 1.852); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "cal")
                    {
                        W = (Z * 72913.3848); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "stopa")
                    {
                        W = (Z * 6076.1155); TextScoreUnits.Text = W.ToString();
                    }
                    else if (wartoscB == "yard")
                    {
                        W = (Z * 2025.3718); TextScoreUnits.Text = W.ToString();
                    }
                    else
                    {
                        W = (Z * 1.1508); TextScoreUnits.Text = W.ToString();
                    }
                    break;



            }

            StatystykiDTO sDTO = new StatystykiDTO()
            {
                WartoscPodstawowa = double.Parse(TextValue2.Text),
                WartoscPoKonwersji = double.Parse(TextScoreUnits.Text),
                WartoscA = CboxListMeasureA.Text,
                WartoscB = CboxListMeasureB.Text,
                JednostkaA = CboxListUnits.Text,
                JednostkaB = CboxListUnitsB.Text,
                Data = DateTime.Now
            };
            this.repozytorium.DodajStatystyki(sDTO);
            this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();

         
        }


        private void CboxListUnitsB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
  
        }

        private void CboxListMeasureB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wartoscD = this.CboxListMeasureB.SelectedItem.ToString();

            if (wartoscD == "Metryczne")
            {
                this.CboxListUnitsB.ItemsSource = new List<string>(new[]
           {
                "mm","cm","dm","m","km"
            });
            }
            else if (wartoscD == "Anglosaskie")
            {
                this.CboxListUnitsB.ItemsSource = new List<string>(new[]
       {
                "cal","stopa","yard","mila",
            });
            }
            else
            {
                this.CboxListUnitsB.ItemsSource = new List<string>(new[]
                {
                "kabel","mila morska",
            });
            }
        }

        private void CboxListUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // double wartoscA;
            //  string wartoscA = this.CboxListUnits.SelectedItem.ToString();


        }



        private void PobierzTabele()
        {
            this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {      }

        private void ButtonCount3_Click(object sender, RoutedEventArgs e)
        {
            double Z, W;
            string wartoscA = this.CboxListUnitsMass.SelectedItem.ToString();
            string wartoscB = this.CboxListUnitsMassB.SelectedItem.ToString();
            Z = double.Parse(TextValue3.Text);

            if (wartoscB == "uncja")
            {
                W = (Z * 0.0031274);
            }
            else if (wartoscB == "funt")
            {
                W = (Z / 0.00022046);
            }
            else if (wartoscB == "karat")
            {
                W = (Z * 0.5);
            }
            else
            {
                W = (Z * 0.000001);
            }

            switch (wartoscA)
            {

                case "mg":
                    W = W * 1; TextScoreUnitsMass.Text = W.ToString();                  
                    break;
                case "g":
                    W = W * 10; TextScoreUnitsMass.Text = W.ToString();
                    break;
                case "dkg":
                    W = W * 100; TextScoreUnitsMass.Text = W.ToString();
                    break;
                case "kg":
                    W = W * 10000; TextScoreUnitsMass.Text = W.ToString();
                    break;
                case "t":
                    W = W * 100000; TextScoreUnitsMass.Text = W.ToString();
                    break;
            }

            StatystykiDTO sDTO = new StatystykiDTO()
            {
                WartoscPodstawowa = double.Parse(TextValue3.Text),
                WartoscPoKonwersji = double.Parse(TextScoreUnitsMass.Text),
                WartoscA = CboxListMassA.Text,
                WartoscB = CboxListMassB.Text,
                JednostkaA = CboxListUnitsMass.Text,
                JednostkaB = CboxListUnitsMassB.Text,
                Data = DateTime.Now
            };
            this.repozytorium.DodajStatystyki(sDTO);
            this.DataGrid1.ItemsSource = repozytorium.GetStatystykis();

        }

        private void CboxListMassA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wartoscE = this.CboxListMassA.SelectedItem.ToString();
            if (wartoscE == "Metryczne")
            {
                this.CboxListUnitsMass.ItemsSource = new List<string>(new[]
                {
                    "mg","g","dkg","kg","t"
                });
            }
            else if (wartoscE == "Anglosaskie")
            {
                this.CboxListUnitsMass.ItemsSource = new List<string>(new[]
               {
                    "uncja","funt"
                });
            }
            else
            {
                this.CboxListUnitsMass.ItemsSource = new List<string>(new[]
              {
                    "karat","kwintal"
                });
            }

        }

        private void CboxListMassB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string wartoscE = this.CboxListMassB.SelectedItem.ToString();
            if (wartoscE == "Metryczne")
            {
                this.CboxListUnitsMassB.ItemsSource = new List<string>(new[]
                {
                    "mg","g","dkg","kg","t"
                });
            }
            else if (wartoscE == "Anglosaskie")
            {
                this.CboxListUnitsMassB.ItemsSource = new List<string>(new[]
               {
                    "uncja","funt"
                });
            }
            else
            {
                this.CboxListUnitsMassB.ItemsSource = new List<string>(new[]
              {
                    "karat","kwintal"
                });
            }

        }
    }
}

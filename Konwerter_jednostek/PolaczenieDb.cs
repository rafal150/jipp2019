using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace Konwerter_jednostek
{
    public static class PolaczenieDb
    {
        public const string ConnectionString1 = @"Data Source=VM-KAROL\NOWABAZA;Initial Catalog=Konwerter;User ID=VM-KAROL\Karol;Password=Milanista90#";
        public const string ConnectionString = "Data Source=VM-KAROL\\NowaBaza;Initial Catalog=Konwerter;Integrated Security=True";
        //private static SqlConnection _connection;

        public static void Inicjalizuj()
        {
            //_connection = new SqlConnection(ConnectionString);
        }

        public static IEnumerable<Miara> PobierzListeMiar(int? typ_ID) //interfejs do zwracania zbiorów
        {
            if (typ_ID == null)
            {
                typ_ID = 0;
            }
            var lista_miar = new List<Miara>();
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = new SqlCommand("dbo.pobierz_liste_miar", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@typ_ID", typ_ID));
           

            using (var reader = cmd.ExecuteReader()) //odczyt danych z bazy
            {
                while (reader.Read())
                {
                    lista_miar.Add(new Miara(Convert.ToInt32(reader["miara_ID"]), reader["nazwa_miary"].ToString(), Convert.ToInt32(reader["typ_ID"])));
                }
            }
            connection.Close();

            return lista_miar;
        }

        public static Wspolczynniki PobierzWspolczynniki(int inputMiaraId, int outputMiaraId)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = new SqlCommand("dbo.PobierzWspolczynniki", connection); //stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@wejscie_ID", inputMiaraId));
            cmd.Parameters.Add(new SqlParameter("@wyjscie_ID", outputMiaraId));

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return new Wspolczynniki(Convert.ToDouble(reader["A"]),
                                             Convert.ToDouble(reader["B"]),
                                             Convert.ToInt32(reader["CzyOdwrotne"]) == 1);
                }
            }
            connection.Close();

            return new Wspolczynniki(0, 0, false);
        }
        public static void Dodaj_statystyke (string nazwa_typu, string nazwa_miary_wejscie, double wartosc_do_konwersji, string nazwa_miary_wyjscia, double rezultat_konwersji)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = new SqlCommand("dbo.sp_dodaj_statystyka", connection); //stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nazwa_typu", nazwa_typu));
            cmd.Parameters.Add(new SqlParameter("@nazwa_miary_wejscie", nazwa_miary_wejscie));
            cmd.Parameters.Add(new SqlParameter("@wartosc_do_konwersji", wartosc_do_konwersji));
            cmd.Parameters.Add(new SqlParameter("@nazwa_miary_wyjscia", nazwa_miary_wyjscia));
            cmd.Parameters.Add(new SqlParameter("@rezultat_konwersji", rezultat_konwersji));

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static IEnumerable<Statystyka> PobierzStatystyki()
        {
            var lista_statystyk = new ObservableCollection<Statystyka>();
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = new SqlCommand("dbo.sp_pobierz_statystyki", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            using (var reader = cmd.ExecuteReader()) //odczyt danych z bazy
            {
                while (reader.Read())
                {
                    lista_statystyk.Add(new Statystyka(Convert.ToDateTime(reader["czas"]),
                                                       Convert.ToString(reader["nazwa_typu"]), 
                                                       reader["nazwa_miary_wejscie"].ToString(), 
                                                       Convert.ToInt32(reader["wartosc_do_konwersji"]), 
                                                       reader["nazwa_miary_wyjscia"].ToString(),
                                                       Convert.ToDouble(reader["rezultat_konwersji"])));
                }
            }
            connection.Close();

            return lista_statystyk;
        }
        public static string pobierz_nazwe_typu(int typ_ID)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var cmd = new SqlCommand("dbo.sp_pobierz_nazwe_typu", connection); //stored procedure
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@typ_ID", typ_ID));

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    return reader["nazwa_typu"].ToString();
                }
            }
            connection.Close();

            return "";
        }
    }
}

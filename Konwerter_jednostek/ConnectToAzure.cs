using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Threading.Tasks;
using System.Linq;

namespace Konwerter_jednostek
{
    public class ConnectToAzure : IPolaczenie
    {
        private CloudTable table;

        public ConnectToAzure()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("konwerterstorage", "NSGRMNPElql6GUQJcq5pYqzR3AUmDUT7+duFr/Fn43GDqYk4D5ftzkz4YxfgairPafqb1b0zrYVFhgnVcN/6WA=="), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatystykiTable");
        }

        public void Dodaj_statystyke(Statystyka statystyka)
        {
            var entity = new EntityStatystyka();
            entity.PartitionKey = "user";
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Czas = statystyka.Czas;
            entity.Nazwa_miary_wejscie = statystyka.Nazwa_miary_wejscie;
            entity.Nazwa_miary_wyjscia = statystyka.Nazwa_miary_wyjscia;
            entity.Nazwa_typu = statystyka.Nazwa_typu;
            entity.Rezultat_konwersji = statystyka.Rezultat_konwersji;
            entity.Wartosc_do_konwersji = statystyka.Wartosc_do_konwersji;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<Statystyka> PobierzStatystyki()
        {
            TableQuery<EntityStatystyka> query = new TableQuery<EntityStatystyka>();

            return table.ExecuteQuery(query).Select(obj => 
                                            new Statystyka(obj.Czas,
                                                           obj.Nazwa_typu,  
                                                           obj.Nazwa_miary_wejscie,
                                                           obj.Wartosc_do_konwersji,
                                                           obj.Nazwa_miary_wyjscia,
                                                           obj.Rezultat_konwersji))
                                                                            .ToList();
        }
    }
}

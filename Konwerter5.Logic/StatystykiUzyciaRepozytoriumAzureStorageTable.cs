using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter5.Logic.ModelDanych;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace Konwerter5.Logic
{
    public class StatystykiUzyciaRepozytoriumAzureStorageTable : IRepozytoriumStatystykUzycia
    {
        CloudTable tabelaWAzure;
        
        public StatystykiUzyciaRepozytoriumAzureStorageTable()
        {
            CloudStorageAccount kontoWAzure = new CloudStorageAccount
            (
                new StorageCredentials
                (
                    ConfigurationManager.AppSettings["StorageName"], 
                    ConfigurationManager.AppSettings["StorageKey"]
                ), 
            true
            );
            CloudTableClient klientAzure = kontoWAzure.CreateCloudTableClient();
            tabelaWAzure = klientAzure.GetTableReference("StatystykiUzyciaWAzureJW");
            tabelaWAzure.CreateIfNotExists();
        }

        public void DodajStatystykiUzycia(StatystykiUzyciaDTO StatystykiUzycia)
        {
            StatystykiUzyciaEntity statystykiUzyciaEntity = new StatystykiUzyciaEntity
            {
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                TypKonwersji = StatystykiUzycia.TypKonwersji,
                Data = StatystykiUzycia.Data,
                Id = StatystykiUzycia.Id,
                ZJednostki = StatystykiUzycia.ZJednostki,
                DoJednostki = StatystykiUzycia.DoJednostki,
                WartoscDoPrzeliczen = StatystykiUzycia.WartoscDoPrzeliczen,
                WartoscPrzeliczona = StatystykiUzycia.WartoscPrzeliczona
               
            };
            TableOperation insert = TableOperation.Insert(statystykiUzyciaEntity);
            tabelaWAzure.Execute(insert);
        }

        public IEnumerable<StatystykiUzyciaDTO> PobierzStatystykiUzycia()
        {
            TableQuery<StatystykiUzyciaEntity> zapytanie = new TableQuery<StatystykiUzyciaEntity>();
            return tabelaWAzure.ExecuteQuery(zapytanie).Select
                 (
                    obj => new StatystykiUzyciaDTO()
                    {
                        Data = obj.Data,
                        TypKonwersji = obj.TypKonwersji,
                        Id = obj.Id,
                        ZJednostki = obj.ZJednostki,
                        DoJednostki = obj.DoJednostki,
                        WartoscPrzeliczona = obj.WartoscPrzeliczona,
                        WartoscDoPrzeliczen = obj.WartoscDoPrzeliczen

                    }
                 ).ToList();
        }
    }
}

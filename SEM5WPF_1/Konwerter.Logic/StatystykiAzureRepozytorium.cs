using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SEM5WPF_1.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Threading.Tasks;

namespace SEM5WPF_1
{
    public class StatystykiAzureRepozytorium: IStatystykiRepozytorium
    {
        private CloudTable table;
        public StatystykiAzureRepozytorium()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatystykiStorage");
            this.table.CreateIfNotExists();
        }

        public void DodajStatystyki(StatystykiDTO statystyki)
        {
            StatystykiEntities entities = new StatystykiEntities();
            entities.PartitionKey = string.Empty;
            entities.RowKey = Guid.NewGuid().ToString();
            entities.Data = statystyki.Data;
            entities.JednostkaA = statystyki.JednostkaA;
            entities.JednostkaB = statystyki.JednostkaB;
            entities.WartoscA = statystyki.WartoscA;
            entities.WartoscB = statystyki.WartoscB;
            entities.WartoscPodstawowa = statystyki.WartoscPodstawowa;
            entities.WartoscPoKonwersji = statystyki.WartoscPoKonwersji;

            TableOperation insertOperation = TableOperation.Insert(entities);
            table.Execute(insertOperation);
        }

        public IEnumerable<StatystykiDTO> GetStatystykis()
        {
            TableQuery<StatystykiEntities> q = new TableQuery<StatystykiEntities>();
            return table.ExecuteQuery(q).Select(obj => new StatystykiDTO()
            {
                Data = obj.Data,
                JednostkaA = obj.JednostkaA,
                JednostkaB = obj.JednostkaB,
                WartoscA = obj.WartoscA,
                WartoscB = obj.WartoscB,
                WartoscPodstawowa = obj.WartoscPodstawowa,
                WartoscPoKonwersji = obj.WartoscPoKonwersji
            }).ToList();
        }
    }
}

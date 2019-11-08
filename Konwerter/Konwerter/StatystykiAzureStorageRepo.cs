using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Model;

namespace Konwerter
{
    public class StatystykiAzureStorageRepo:IStatystykiRepo
    {
        private CloudTable tabela;
        public StatystykiAzureStorageRepo()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.tabela = client.GetTableReference("StatisticsMarcinIwanowski");
            this.tabela.CreateIfNotExists();
        }

        public void Dodaj_do_bazy(StatystykiObiekt stats)
        {
            Staty2 stats2 = new Staty2();
            stats2.PartitionKey = string.Empty;
            stats2.RowKey = Guid.NewGuid().ToString();
            stats2.DateTime = stats.DateTime;
            stats2.UnitFrom = stats.UnitFrom;
            stats2.UnitTo = stats.UnitTo;
            stats2.RawValue = stats.RawValue;
            stats2.ConvertedValue = stats.ConvertedValue;
            stats2.Type = stats.Type;


            TableOperation wprowadzanie = TableOperation.Insert(stats2);

            tabela.Execute(wprowadzanie);
        }
        public IEnumerable<StatystykiObiekt> GetStatistics()
        {
            TableQuery<Staty2> query = new TableQuery<Staty2>();

            return tabela.ExecuteQuery(query).Select(obj => new StatystykiObiekt() { DateTime = obj.DateTime, UnitFrom=obj.UnitFrom, 
                UnitTo=obj.UnitTo, RawValue=obj.RawValue, ConvertedValue=obj.ConvertedValue ,Type = obj.Type}).ToList();
        }
    }
}

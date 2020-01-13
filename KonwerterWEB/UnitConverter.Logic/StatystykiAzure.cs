using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Model;

namespace UnitConverter
{
    public class StatystykiAzure : InterfejsStatystyki
    {
        private CloudTable table;

        public StatystykiAzure()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatJasGasiorek");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(Statystyki statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.Tresc;
            entity.DateTime = statistic.DataLogu;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<Statystyki> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();
            return table.ExecuteQuery(query).Select(obj => new Statystyki() { DataLogu = obj.DateTime, Tresc = obj.Type }).ToList();


        }
    }
}

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterAzure.Model;

namespace KonwerterAzure
{
    public class StatystykiAZURE: DodawanieStatystyk
    {
        private CloudTable table;

        public StatystykiAZURE()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticJanGasiorek");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatystykiDBO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.TrescLogu;
            entity.DateTime = statistic.DataLogu;


            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatystykiDBO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatystykiDBO() { DataLogu = obj.DateTime, TrescLogu = obj.Type }).ToList();
        }
    }
}

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverter.StatisticModel;
using Newtonsoft.Json;

namespace UnitConverter
{
    public class StatisticToAzure: InterfaceStatistic
    {
        private CloudTable table;

        public StatisticToAzure()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsPrzemyslawKrzyszczak");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticRecord statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.ValueFrom = statistic.ValueFrom;
            entity.UnitFrom = statistic.UnitFrom;
            entity.ValueTo = statistic.ValueTo;
            entity.UnitTo = statistic.UnitTo;
            entity.DateTime = statistic.DateTime;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticRecord> GetStatistics()
        {
            
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticRecord() { DateTime = obj.DateTime, ValueFrom = obj.ValueFrom, UnitFrom = obj.UnitFrom, ValueTo = obj.ValueTo, UnitTo = obj.UnitTo }).ToList();
        }
    }
}

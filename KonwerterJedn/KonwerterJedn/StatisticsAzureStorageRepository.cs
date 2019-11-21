using KonwerterJedn.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class StatisticsAzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsOlaDreslinska");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            entity.ValueFrom = statistic.ValueFrom;
            entity.ValueTo = statistic.ValueTo;
            entity.Type = statistic.Type;
            entity.DateTime = statistic.DateTime;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, ValueFrom = obj.ValueFrom, ValueTo = obj.ValueTo, Type = obj.Type, DateTime = obj.DateTime, }).
            ToList();
        }
    }
}

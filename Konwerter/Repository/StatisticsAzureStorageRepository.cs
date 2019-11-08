using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;


namespace Konwerter
{
    class StatisticsAzureStorageRepository : IStatisticRepository
    {
        private CloudTable table;
        public StatisticsAzureStorageRepository()
        {
            StorageCredentials credentials = new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]);
            CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            table = client.GetTableReference("StatisticsMartaBasznianin");
            table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticEntity entity = new StatisticEntity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Id = statistic.Id;
            entity.DateTime = statistic.DateTime;
            entity.Type = statistic.Type.ToString();
            entity.ValueFrom = statistic.ValueFrom;
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            entity.ValueTo = statistic.ValueTo;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticEntity> query = new TableQuery<StatisticEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() {
                Id = obj.Id,
                DateTime = obj.DateTime,
                Type = obj.Type.ToString(),
                ValueFrom = obj.ValueFrom,
                UnitFrom = obj.UnitFrom,
                UnitTo = obj.UnitTo,
                ValueTo = obj.ValueTo
            }).ToList();
        }
    }
}

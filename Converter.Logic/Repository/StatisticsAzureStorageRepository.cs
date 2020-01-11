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
    public class StatisticsAzureStorageRepository : IStatisticRepository
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
            StatisticEntity entity = new StatisticEntity
            {
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                Id = statistic.Id,
                DateTime = statistic.DateTime,
                Type = statistic.Type.ToString(),
                ValueFrom = statistic.ValueFrom,
                UnitFrom = statistic.UnitFrom,
                UnitTo = statistic.UnitTo,
                ValueTo = statistic.ValueTo,
                Comment = statistic.Comment
            };

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
                ValueTo = obj.ValueTo,
                Comment = obj.Comment
            }).ToList();
        }
    }
}

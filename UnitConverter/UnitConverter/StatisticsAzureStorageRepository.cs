using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace UnitConverter {
    class StatisticsAzureStorageRepository : IStatisticsRepository {
        private CloudTable table;
        public StatisticsAzureStorageRepository() {
            // Azure Storage credentials
            string storageName = ConfigurationManager.AppSettings["AzureStorageName"];
            string storageKey = ConfigurationManager.AppSettings["AzureStorageKey"];
            StorageCredentials storageCredentials = new StorageCredentials(storageName, storageKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            // table name
            table = client.GetTableReference("StatisticsMichalRoslaniec");
            // create table
            table.CreateIfNotExists();
        }
        public void AddStatistic(StatisticDTO statistic) {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty;
            // something like row's ID
            entity.RowKey = Guid.NewGuid().ToString();
            entity.DateTime = statistic.DateTime;
            entity.ConversionType = statistic.ConversionType;
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            entity.ValueFrom = statistic.ValueFrom;
            entity.ValueTo = statistic.ValueTo;

            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }
        public IEnumerable<StatisticDTO> GetStatistics() {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();
            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() {
                DateTime = obj.DateTime,
                ConversionType = obj.ConversionType,
                UnitFrom = obj.UnitFrom,
                UnitTo = obj.UnitTo,
                ValueFrom = obj.ValueFrom,
                ValueTo = obj.ValueTo
            }).ToList();
        }
    }
}
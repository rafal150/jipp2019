using JIPP5_LAB.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace JIPP5_LAB.Data
{
    public class AzureData : IGetData
    {
        private CloudTable table;

        public AzureData()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("Statystyki");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity
            {
                Id = new Random().Next(),
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                Type = statistic.Type,
                DateTime = statistic.DateTime,
                RawValue = statistic.RawValue,
                Converterd = statistic.ConvertedValue,
            };

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, ConvertedValue = obj.Converterd, RawValue = obj.RawValue }).ToList();
        }
    }
}
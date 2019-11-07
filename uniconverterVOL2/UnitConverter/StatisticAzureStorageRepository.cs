using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using UnitConverter.Model;
using System.Linq;

namespace UnitConverter
{
    class StatisticAzureStorageRepository : IRepository
    {
        private CloudTable table;
        public StatisticAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("UnitsConverter");
            this.table.CreateIfNotExists();
        }
        public void AddStatistic(StatisticJZDTO statistic)
        {
            StatisticEntity entity = new StatisticEntity
            {
                PartitionKey = string.Empty, // computer name;
                RowKey = Guid.NewGuid().ToString(),
                Id = statistic.Id,
                DateTime = statistic.DateTime,
                UnitFrom = statistic.UnitFrom,
                UnitTo = statistic.UnitTo,
                Type = statistic.Type,
                RawValue = statistic.RawValue,
                ConvertedValue = statistic.ConvertedValue
            };


            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticJZDTO> GetStatistics()
        {
            TableQuery<StatisticEntity> query = new TableQuery<StatisticEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticJZDTO()
            {
                Id = obj.Id,
                DateTime = obj.DateTime,
                UnitFrom = obj.UnitFrom,
                UnitTo = obj.UnitTo,
                Type = obj.Type,
                RawValue = obj.RawValue,
                ConvertedValue = obj.ConvertedValue
            }).ToList();
        }
    }
}

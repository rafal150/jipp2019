using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace applicationWpf
{
    public class StatisticsAzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;
        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsLukaszWieczorek");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticsDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity
            {
                PartitionKey = string.Empty, // computer name;
                RowKey = Guid.NewGuid().ToString(),
                Type = statistic.Type,
                Date = statistic.Date,
                ConvertedUnit = statistic.ConvertedUnit,
                ConvertedValue = statistic.ConvertedValue,
                SourceUnit = statistic.SourceUnit,
                SourceValue = statistic.SourceValue,
                Id = statistic.Id
            };

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticsDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(dupa => new StatisticsDTO()
            {
                Id = dupa.Id,
                ConvertedUnit = dupa.ConvertedUnit,
                ConvertedValue = dupa.ConvertedValue,
                Date = dupa.Date,
                SourceUnit = dupa.SourceUnit,
                SourceValue = dupa.SourceValue,
                Type = dupa.Type
            }).ToList();
        }
    }
}
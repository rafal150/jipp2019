using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace JIPP5_LAB.DataProviders
{
    public class AzureHelper : IDataHelper
    {
        private CloudTable table;

        public AzureHelper()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("statsPZ");
            this.table.CreateIfNotExists();
        }

        public void AddRecord(StatisticsDTO modelToSave)
        {
            StatisticsEntity entity = new StatisticsEntity
            {
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                Type = modelToSave.ToUnit,
                DateTime = modelToSave.Date
            };

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticsDTO> GetRecords()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticsDTO() { Date = obj.DateTime, FromUnit = obj.Type }).ToList();
        }
    }
}
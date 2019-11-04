using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace UnitConversion
{
    public class AzureServiceRepository : IServiceRepository
    {
        private readonly CloudTable cloudTable;

        public AzureServiceRepository()
        {
            string storageName = ConfigurationManager.AppSettings["StorageName"];
            string storageKey = ConfigurationManager.AppSettings["StorageKey"];
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(storageName, storageKey), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.cloudTable = client.GetTableReference("ConversionHistory");
            this.cloudTable.CreateIfNotExists();
        }

        public void AddConversionHistory(ConversionHistoryDTO conversionHistory)
        {
            ConversionHistoryEntity entity = new ConversionHistoryEntity()
            {
                BaseUnit = conversionHistory.BaseUnit,
                BaseValue = conversionHistory.BaseValue,
                ConversionType = conversionHistory.ConversionType,
                Created = conversionHistory.Created,
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                TargetUnit = conversionHistory.TargetUnit,
                TargetValue = conversionHistory.TargetValue
            };
            TableOperation insert = TableOperation.Insert(entity);
            cloudTable.Execute(insert);

        }

        public IEnumerable<ConversionHistoryDTO> GetConversionHistory()
        {
            TableQuery<ConversionHistoryEntity> query = new TableQuery<ConversionHistoryEntity>();
            return cloudTable.ExecuteQuery(query).Select(x => new ConversionHistoryDTO()
            {
                BaseUnit = x.BaseUnit,
                BaseValue = x.BaseValue,
                ConversionType = x.ConversionType,
                Created = x.Created,
                TargetUnit = x.TargetUnit,
                TargetValue = x.TargetValue
            }).ToList();
        }
    }
}

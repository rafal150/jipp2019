using JIPP5_LAB.Database;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.Models;
using JIPP5_LAB.Resources;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Helpers
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

        public void AddRecord(StatisticModel modelToSave)
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

        public IEnumerable<StatisticModel> GetRecords()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticModel() { Date = obj.DateTime, FromUnit = obj.Type }).ToList();
        }
    }
}

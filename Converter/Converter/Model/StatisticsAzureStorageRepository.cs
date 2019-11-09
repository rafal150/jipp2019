using Converter.Program;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Model
{
    public class StatisticsAzureStorageRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("TableZbigniewGawarski");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(BaseConverter converter)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.PhysicalProperty = converter.PhysicalProperty;
            entity.ConvertingTime = converter.ConvertingTime;

            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { ConvertingTime = obj.ConvertingTime, PhysicalProperty = obj.PhysicalProperty }).ToList();
        }
    }
}
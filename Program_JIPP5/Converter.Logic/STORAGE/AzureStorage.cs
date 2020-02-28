using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Converter
{

    public class AzureStorage : IStatisticsRepository
    {
        private CloudTable table;

        public AzureStorage()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsLaskowskiDominik");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.DateTime = statistic.DateTime;
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }


        public IEnumerable<StatDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatDTO() { DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo}).ToList();
        }
    }
}

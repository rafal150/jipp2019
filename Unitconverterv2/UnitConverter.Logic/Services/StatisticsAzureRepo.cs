using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace Unitconverter
{
    public class StatisticsAzureRepo : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureRepo()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsMarcinIwanowski");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatDTO statistic)
        {
            StatAzureModel entity = new StatAzureModel();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.Type;
            entity.DateTime = statistic.DateTime;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatDTO> GetStatistics()
        {
            TableQuery<StatAzureModel> baza = new TableQuery<StatAzureModel>();
            return table.ExecuteQuery(baza).Select(obj => new StatDTO()
            {
                DateTime = obj.DateTime,
                Type = obj.Type,
                FromUnit = obj.FromUnit,
                ToUnit = obj.ToUnit,
                RawValue = obj.RawValue,
                ConvertedValue = obj.ConvertedValue
            }).ToList();

        }
    }
}

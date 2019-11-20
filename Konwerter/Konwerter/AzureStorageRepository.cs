using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace Konwerter
{
    public class AzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;

        public AzureStorageRepository()
        {
            CloudStorageAccount account = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = account.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsElizaNowakowska");
            this.table.CreateIfNotExists();
        }

        public void AddStatistics(StatisticsDTO statistics)
        {
            DbAzure entity = new DbAzure();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.conversionType = statistics.conversionType;
            entity.fromUnit = statistics.fromUnit;
            entity.valueToConvert = statistics.valueToConvert;
            entity.toUnit = statistics.toUnit;
            entity.convertedValue = statistics.convertedValue;
            entity.dateTime = statistics.dateTime;

            TableOperation insert = TableOperation.Insert(entity);

            table.Execute(insert);
        }

        public IEnumerable<StatisticsDTO> GetStatistics()
        {
            TableQuery<DbAzure> query = new TableQuery<DbAzure>();

            return table.ExecuteQuery(query).Select(obj => new StatisticsDTO()
            {
                conversionType = obj.conversionType,
                fromUnit = obj.fromUnit,
                valueToConvert = obj.valueToConvert,
                toUnit = obj.toUnit,
                convertedValue = obj.convertedValue,
                dateTime = obj.dateTime
            }).ToList();
        }
    }
}

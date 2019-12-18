using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using UnitConverter.Statistics;

namespace UnitConverter.DataBase
{

    public class AzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;
        public AzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("PiotrKalinskiz502");
            this.table.CreateIfNotExists();
        }
        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticEntity entity = new StatisticEntity();
            entity.PartitionKey = string.Empty; 
            entity.RowKey = Guid.NewGuid().ToString();
            entity.type = statistic.type;
            entity.date = statistic.date;
            entity.toUnit = statistic.toUnit;
            entity.fromUnit = statistic.fromUnit;
            entity.startValue = statistic.startValue;
            entity.finalValue = statistic.finalValue;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }
        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticEntity> query = new TableQuery<StatisticEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { toUnit= obj.toUnit, fromUnit = obj.fromUnit, finalValue = obj.finalValue, startValue = obj.startValue, date = obj.date, type = obj.type }).ToList();
        }
    }
}

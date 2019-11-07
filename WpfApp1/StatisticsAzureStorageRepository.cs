using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public class StatisticsAzureStorageRepository : IStatisticsSource
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsPiotrGradkowski");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticsDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; 
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Id = statistic.Id;
            entity.Time = statistic.Time;
            entity.From = statistic.From;
            entity.To = statistic.To;
            entity.OryginalValue = statistic.OryginalValue;
            entity.CalculatedValue = statistic.CalculatedValue;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticsDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticsDTO()
            {
                Id = obj.Id,
                Time = obj.Time,
                From = obj.From,
                To = obj.To,
                OryginalValue = obj.OryginalValue,
                CalculatedValue = obj.CalculatedValue,
            }).ToList();
        }
    }
}
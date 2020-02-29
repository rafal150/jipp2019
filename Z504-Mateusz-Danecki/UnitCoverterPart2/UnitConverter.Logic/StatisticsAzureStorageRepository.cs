using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Model;


namespace UnitCoverterPart2
{
    public class StatisticsAzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount
              (new StorageCredentials("wwsi", "mVDN4VYhoG2olhNa4bBiR2Im46RAn1C23pgvXZBQ3Wh/ebmOfOOp0L9LORGYzJLg80XpkqrVxp4f4TBSRZICKg=="), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("MateuszDanecki");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.id = statistic.id;
            entity.DateTime = statistic.DateTime;
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            entity.RawValue = statistic.RawValue;
            entity.ConvertedValue = statistic.ConvertedValue;
            entity.Type = statistic.Type;
            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { id = obj.id, DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue, Type = obj.Type }).ToList();
        }
    }
}

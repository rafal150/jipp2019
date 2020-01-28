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
    public class StatisticsAzureStorageRepository: IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsZbigniewGawarski2");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.Type;
            entity.DateTime = statistic.DateTime;
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            entity.RawValue = statistic.RawValue;
            entity.ConvertedValue = statistic.ConvertedValue;


            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { DateTime = obj.DateTime,
                                                                                Type = obj.Type,
                                                                                UnitFrom = obj.UnitFrom,
                                                                                UnitTo = obj.UnitTo,
                                                                                RawValue = obj.RawValue,
                                                                                ConvertedValue = obj.ConvertedValue
                                                                                }).ToList();
        }

        public void Clean()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                IEnumerable<Statistic> toDelete = context.Statistics.Where(x => x.Id > 0);
                context.Statistics.RemoveRange(toDelete);
                context.SaveChanges();
            }

            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            IEnumerable<StatisticsEntity> doUsuniecia = table.ExecuteQuery(query).Where(x => x.RowKey != String.Empty);
            foreach (var row in doUsuniecia)
            {
                TableOperation deleteOperation = TableOperation.Delete(row);
                table.Execute(deleteOperation);
            }
        }
    }
}

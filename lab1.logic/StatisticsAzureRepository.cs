using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.Model;

namespace lab1
{
    public class StatisticsAzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatistykiJuliaBlaszczyk");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.TypJednostki = statistic.TypJednostki;
            entity.JednostkaZ = statistic.JednostkaZ;
            entity.JednostkaDo = statistic.JednostkaDo;
            entity.IloscPrzed = statistic.IloscPrzed;
            entity.IloscPo = statistic.IloscPo;
            entity.Data = statistic.Data;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() { Data = obj.Data, TypJednostki = obj.TypJednostki, JednostkaZ = obj.JednostkaZ, JednostkaDo = obj.JednostkaDo, IloscPrzed = obj.IloscPrzed,  IloscPo = obj.IloscPo }).ToList();
        }
    }
}

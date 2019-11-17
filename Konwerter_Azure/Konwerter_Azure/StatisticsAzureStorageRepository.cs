using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter_Azure.Model;

namespace Konwerter_Azure
{
    public class StatisticsAzureStorageRepository : IStatisticsRepository // do zapisu na azure
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatMagdalenaGlowacka");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.id = statistic.id;
            entity.czas = statistic.czas;
            entity.grupa = statistic.grupa;
            entity.przeliczZ = statistic.przeliczZ;
            entity.dane = statistic.dane;
            //entity.dane = statistic.dane.ToString();
            entity.przeliczNa = statistic.przeliczNa;
            entity.wynik = statistic.wynik;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obiekt => new StatisticDTO()
            {
                id = obiekt.id,
                czas = obiekt.czas,
                grupa = obiekt.grupa,
                przeliczZ = obiekt.przeliczZ,
                dane = obiekt.dane,
                przeliczNa = obiekt.przeliczNa,
                wynik = obiekt.wynik
            }).ToList();
        }

    }
}

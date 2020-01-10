using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppJIPP;


namespace WpfAppJIPP
{
    public class StatisticsAzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsJacekHaloszka");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; 
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Id = statistic.Id;
            entity.Czas = statistic.Czas;
            entity.Typ = statistic.Typ;
            entity.Konwersja_z = statistic.Konwersja_z;
            entity.Konwersja_na = statistic.Konwersja_na;
            entity.Wartosc_wprowadzona = statistic.Wartosc_wprowadzona;
            entity.Wynik = statistic.Wynik;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new StatisticDTO()
            {
                Id = obj.Id,
                Czas = obj.Czas,
                Typ = obj.Typ,
                Konwersja_z = obj.Konwersja_z,
                Konwersja_na = obj.Konwersja_na,
                Wartosc_wprowadzona = obj.Wartosc_wprowadzona,
                Wynik = obj.Wynik,
            }).ToList();
        }
    }
}

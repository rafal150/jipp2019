using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterNS.Modell;

namespace KonwerterNS
{
    public class StatisticsAzureStorageRepository : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticJakubFigat");
            this.table.CreateIfNotExists();
        }


        public List<StatisticDTO> WczytajStaty()
        {
            TableQuery<StatisticEntity> query = new TableQuery<StatisticEntity>();
            //IEnumerable<StatisticEntity> tmp;
            return table.ExecuteQuery(query).Select(obj => new StatisticDTO() {
                DateTime = obj.DateTime,
                Type = obj.Type,
                FromTo = obj.FromTo,
                FromUnit = obj.FromUnit,
                RawValue = Convert.ToDecimal(obj.RawValue),
                ConvertedValue = Convert.ToDecimal(obj.ConvertedValue)
            }).ToList();
        }

        public void ZapiszDoDB(string rodzaj, string Zjednostka, string Dojednostka, double WartoscZ, double WartoscNa)
        {
            StatisticEntity entity = new StatisticEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.DateTime = DateTime.Now;
            entity.FromUnit = Zjednostka;
            entity.FromTo = Dojednostka;
            entity.RawValue = WartoscZ;
            entity.ConvertedValue = WartoscNa;
            entity.Type = rodzaj;


            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }
    }
}

/*
DateTime = DateTime.Now,
FromUnit = Zjednostka,
FromTo = Dojednostka,
RawValue = Convert.ToDecimal(WartoscZ),
ConvertedValue = Convert.ToDecimal(WartoscNa),
Type = rodzaj */
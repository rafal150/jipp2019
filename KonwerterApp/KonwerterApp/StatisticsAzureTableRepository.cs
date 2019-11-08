
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;


namespace KonwerterApp
{
    class StatisticsAzureTableRepository : IStatisticsRepository
    {
        private CloudTable TabelaChmurowa;

        public void DodajStatystyke(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.Type;
            entity.DateTime = statistic.DateTime;
            entity.ID = statistic.ID;
            entity.DateTime = statistic.DateTime;
            entity.Type = statistic.Type;
            entity.FromUnit = statistic.FromUnit;
            entity.ToUnit = statistic.ToUnit;
            entity.RawValue = statistic.RawValue;
            entity.Converted = statistic.Converted;
            /*
             *      ID = statistic.ID,
                    DateTime = statistic.DateTime,
                    Type = statistic.Type,
                    FromUnit = statistic.FromUnit,
                    ToUnit = statistic.ToUnit,
                    RawValue = statistic.RawValue,
                    Converted = statistic.Converted,
             */
            TableOperation insertOperation = TableOperation.Insert(entity);

            TabelaChmurowa.Execute(insertOperation);
        }

        public StatisticsAzureTableRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.TabelaChmurowa = client.GetTableReference("StatisticsMichalGawryluk");
            this.TabelaChmurowa.CreateIfNotExists();
        }

        public IEnumerable<StatisticDTO> GetStatistic()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();
            return TabelaChmurowa.ExecuteQuery(query).Select(obj => new StatisticDTO()
            {
                ID = obj.ID,
                DateTime = obj.DateTime,
                Type = obj.Type,
                FromUnit = obj.FromUnit,
                ToUnit = obj.ToUnit,
                RawValue = obj.RawValue,
                Converted = obj.Converted,

            }).ToList();
        }
    }
}

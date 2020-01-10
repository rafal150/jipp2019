using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace UnitConverteAZ
{
    public class StatisticStorageAzureRepository : IStatisticRepository
    {
        private CloudTable table;


        public StatisticStorageAzureRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsAleksanderZablocki");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();

            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();

            //calculation data
            entity.Type = statistic.Type;
            entity.Calculation_Time = statistic.Calculation_Time;
            entity.UnitFrom = statistic.UnitFrom;
            entity.Unit_To = statistic.Unit_To;
            entity.Value_From = statistic.Value_From;
            entity.Converted_Value = statistic.Converted_Value;

            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }

        public IEnumerable<StatisticDTO> GetStatistic()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();
            return table.ExecuteQuery(query).Select(obj => new StatisticDTO()
            {
                Type = obj.Type,
                Calculation_Time = obj.Calculation_Time,
                UnitFrom = obj.UnitFrom,
                Unit_To = obj.Unit_To,
                Value_From = obj.Value_From,
                Converted_Value = obj.Converted_Value
            }).ToList();

        }
    }
}

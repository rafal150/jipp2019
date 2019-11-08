using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFConverterv2
{
    class StatisticsAzureStorage : IStatisticsRepository
    {
        private CloudTable table;

        public StatisticsAzureStorage()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount
              (new StorageCredentials("unitsconverter", "sgZyF6sZ/aSKL/flDY/Bidxrxb5/W0itnkfmRwguLggQu420CEiuzDTkM4hS/W2+KSc9+zoKURYetR1Mv1J8yg=="), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("test");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(Statistic statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.DateTime = statistic.DateTime;
            entity.UnitFrom = statistic.UnitFrom;
            entity.UnitTo = statistic.UnitTo;
            entity.RawValue = statistic.RawValue;
            entity.ConvertedValue = statistic.ConvertedValue;
            entity.Type = statistic.Type;
            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<Statistic> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new Statistic() { DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue, Type = obj.Type }).ToList();
        }

        



    }
}

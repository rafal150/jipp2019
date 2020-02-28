using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public class AzureStatisticsRepository : IRepository<StatisticsEntryDto>
    {
        private CloudTable table;

        public AzureStatisticsRepository()
        {
            StorageCredentials storageCredentials = new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]);
            CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsRafalCiupak");
            this.table.CreateIfNotExists();
        }

        //zwraca historie wszystkich wywolan
        public IEnumerable<StatisticsEntryDto> GetAll()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();
            return table.ExecuteQuery(query)
                .Select(x => new StatisticsEntryDto(x.date, x.from, x.to, x.fromValue, x.resultValue))
                .ToList();
        }

        //zapisuje wywolanie
        public void Save(StatisticsEntryDto dto)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.date = dto.date;
            entity.from = dto.from;
            entity.to = dto.to;
            entity.fromValue = dto.fromValue;
            entity.resultValue = dto.resultValue;

            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }
    }
}

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterPLUGIN.Model;

namespace KonwerterPLUGIN
{
    public class StatystykiAzure : DodajStatystyki
    {
        private CloudTable table;

        public StatystykiAzure()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatystykiTCzarekRyzko");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(Logi statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.LogiKonwersjiDanych;
            entity.DateTime = statistic.Data;

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<Logi> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new Logi() { Data = obj.DateTime, LogiKonwersjiDanych = obj.Type }).ToList();

        }
    }
}

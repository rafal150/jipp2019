using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using Labs.Converters;
using Labs.Databases;
using Labs;

namespace Labs.Databases
{
    public class AzureRepo: InterfaceRepository
    {
        private CloudTable tab;
        public AzureRepo()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.tab = client.GetTableReference("StatisticsMarcinIwanowski");
            this.tab.CreateIfNotExists();
        }

        public IEnumerable<Values> GetValues()
        {
            TableQuery<Entity> query = new TableQuery<Entity>();
            return tab.ExecuteQuery(query).Select(val => new Values(){ category = val.category, from = val.from, to = val.to, initial = val.initial, converted = val.converted, DateTime = val.DateTime }).ToList();
        }


        public void AddCalcs(Values values)
        {
            Entity entity = new Entity();
            entity.PartitionKey = string.Empty;
            entity.RowKey = Guid.NewGuid().ToString();
            entity.category = values.category;
            entity.DateTime = values.DateTime;

            TableOperation insert = TableOperation.Insert(entity);

            tab.Execute(insert);
        }

    }
}


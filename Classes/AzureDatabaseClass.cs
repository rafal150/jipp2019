using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Laborki.Classes;

namespace Laborki.Classes
{

    public class Record : TableEntity
    {
        public Record(string category, string from, string to, double initial, double result, string date)
        {            

            this.PartitionKey = string.Empty;
            this.RowKey = Guid.NewGuid().ToString();
            this.DateTime = date;
            this.Type = category;
            this.UnitFrom = from;
            this.UnitTo = to;
            this.RawValue = initial.ToString();
            this.ConvertedValue = result.ToString();
        }

        public Record() { }

        public string DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public string RawValue { get; set; }
        public string ConvertedValue { get; set; }
        public string Type { get; set; }


    }



    class AzureDatabaseClass : TableEntity
    {
        private CloudTable table;

        public void azureStorage()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsMarcinIwanowski");
            this.table.CreateIfNotExists();
        }


        public void saveToAzure(string category, string from, string to, double initial, double result)
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsMarcinIwanowski");
            this.table.CreateIfNotExists();

            string date = DateTime.Now.ToString();

            Record record = new Record(category, from, to, initial, result, date);

            //record.DateTime = date;
            //record.UnitFrom = from;
            //record.UnitTo = to;
            //record.RawValue = initial.ToString();
            //record.ConvertedValue = result.ToString();
            //record.Type = category;

            TableOperation insert = TableOperation.Insert(record);
            table.Execute(insert);

        }

        public void showDB()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatisticsMarcinIwanowski");
            this.table.CreateIfNotExists();

            ShowDB.DbWindow.DataGridShowDB.ItemsSource = table.ExecuteQuery(new TableQuery<Record>()).ToList();
        }
    }
}

using Konwerter.Model;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class AzureStorageRepo : IRepo
    {
        private CloudTable table;

        public AzureStorageRepo()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("konwerter");
            this.table.CreateIfNotExists();
        }

        public void dodajRekord(RekordDTO rekord)
        {
            PrzezAzureStorageTable encja = new PrzezAzureStorageTable();
            encja.PartitionKey = string.Empty; // computer name;
            encja.RowKey = Guid.NewGuid().ToString();
            //encja.Id = rekord.Id;
            encja.DateTime = rekord.DateTime;
            encja.Type = rekord.Type;
            encja.FromUnit = rekord.FromUnit;
            encja.ToUnit = rekord.ToUnit;
            encja.RawValue = rekord.RawValue;
            encja.ConvertedValue = rekord.ConvertedValue;

            TableOperation insertOperation = TableOperation.Insert(encja);

            table.Execute(insertOperation);
        }

        public IEnumerable<RekordDTO> pobierzRekordy()
        {
            TableQuery<PrzezAzureStorageTable> query = new TableQuery<PrzezAzureStorageTable>();

            return table.ExecuteQuery(query).Select(obj => new RekordDTO() { DateTime = obj.DateTime, Type = obj.Type, FromUnit = obj.FromUnit, ToUnit = obj.ToUnit, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue }).ToList();
        }
    }
}
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Logic.Model;

namespace UnitConverter.Logic
{
    public class HistoryAzureStorageRepository : IHistoryRepository
    {
        private const int MaxHistoryItems = 5;

        private CloudTable table;

        public HistoryAzureStorageRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("HistoryKarolKowalski");
            this.table.CreateIfNotExists();
        }

        public void AddConversionItem(HistoryDTO conversionItem)
        {
            HistoryEntity entity = new HistoryEntity()
            {
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                DateTime = conversionItem.DateTime,
                ConversionType = conversionItem.ConversionType,
                UnitFrom = conversionItem.UnitFrom,
                ValueToConvert = DecimalToString(conversionItem.ValueToConvert),
                UnitTo = conversionItem.UnitTo,
                ConvertedValue = DecimalToString(conversionItem.ConvertedValue),
            };

            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);

            RemoveOldConversionItems();
        }

        private string DecimalToString(decimal? value)
        {
            return value.HasValue
                ? value.Value.ToString(CultureInfo.InvariantCulture)
                : null;
        }

        private decimal? StringToDecimal(string value)
        {
            return value != null
                ? decimal.Parse(value, CultureInfo.InvariantCulture)
                : (decimal?) null;
        }

        private void RemoveOldConversionItems()
        {
            TableQuery<HistoryEntity> query = new TableQuery<HistoryEntity>();
            var oldEntries = table.ExecuteQuery(query)
                .OrderByDescending(e => e.DateTime)
                .Skip(MaxHistoryItems);

            foreach (var entity in oldEntries)
            {
                TableOperation deleteOperation = TableOperation.Delete(entity);
                table.Execute(deleteOperation);
            }
        }

        public IEnumerable<HistoryDTO> GetLastConversions()
        {
            TableQuery<HistoryEntity> query = new TableQuery<HistoryEntity>();

            return table.ExecuteQuery(query).OrderByDescending(e => e.DateTime).Select(item => new HistoryDTO()
            {
                DateTime = item.DateTime,
                ConversionType = item.ConversionType,
                UnitFrom = item.UnitFrom,
                ValueToConvert = StringToDecimal(item.ValueToConvert),
                UnitTo = item.UnitTo,
                ConvertedValue = StringToDecimal(item.ConvertedValue),
            }).ToList();
        }
    }
}

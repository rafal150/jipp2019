using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    class TelemetryAzureRepository : ITelemetryRepository
    {
        private CloudTable table;
        public TelemetryAzureRepository()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();

            table = client.GetTableReference("StatisticsOskarSwitalski");
            table.CreateIfNotExists();
        }

        public void AddTelemetry(TelemetryDTO telemetry)
        {
            var entity = new TelemetryEntity()
            {
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                Date = telemetry.Date,
                Type = telemetry.Type,
                UnitFrom = telemetry.UnitFrom,
                UnitTo = telemetry.UnitTo,
                ValueFrom = telemetry.ValueFrom,
                ValueTo = telemetry.ValueTo
            };

            table.Execute(TableOperation.Insert(entity));
        }

        public IEnumerable<TelemetryDTO> GetTelemetries()
        {
            var query = new TableQuery<TelemetryEntity>();

            return table.ExecuteQuery(query).Select(
                obj => new TelemetryDTO()
                {
                    Date = obj.Date,
                    Type = obj.Type,
                    UnitFrom = obj.UnitFrom,
                    UnitTo = obj.UnitTo,
                    ValueFrom = (float)obj.ValueFrom,
                    ValueTo = (float)obj.ValueTo,
                }).ToList();
        }
    }
}

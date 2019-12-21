using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using WPFKonwerter.Model.DTO;

namespace WPFKonwerter.Model
{
    public class Statistics2Azure : IStatisticsRepo
    {
        CloudTable cloudTable;
        public Statistics2Azure()
        {
            CloudStorageAccount storageAccount =
                new CloudStorageAccount(
                    new StorageCredentials(ConfigurationManager.AppSettings.Get("StorageName"),
                                    ConfigurationManager.AppSettings.Get("StorageKey")), true);

            CloudTableClient cloudClient = storageAccount.CreateCloudTableClient();
            cloudTable = cloudClient.GetTableReference("Statistics");
            cloudTable.CreateIfNotExists();
        }
        public void SaveStats(Statistics stats)
        {
            StatisticsAzureMapping statsAzure = new StatisticsAzureMapping();
            statsAzure.CategoryType = stats.CategoryType;
            statsAzure.ConversionDT = stats.ConversionDT;
            statsAzure.Id = stats.Id;
            statsAzure.UnitFrom = stats.UnitFrom;
            statsAzure.ValueFrom = stats.ValueFrom;
            statsAzure.UnitTo = stats.UnitTo;
            statsAzure.ValueTo = stats.ValueTo;
            //---------------------------------
            statsAzure.PartitionKey = string.Empty;
            statsAzure.RowKey = Guid.NewGuid().ToString();
            //------------------------------------
            TableOperation insertIntoTable = TableOperation.Insert(statsAzure);
            cloudTable.Execute(insertIntoTable);
        }

        public List<Statistics> GetStats()
        {
            TableQuery<StatisticsAzureMapping> statsTable = new TableQuery<StatisticsAzureMapping>();

            return cloudTable.ExecuteQuery(statsTable).Select(x => 
                                        new Statistics() 
                                        { 
                                            ConversionDT = x.ConversionDT,
                                            CategoryType = x.CategoryType,
                                            Id = x.Id,
                                            UnitFrom = x.UnitFrom,
                                            ValueFrom = x.ValueFrom,
                                            UnitTo = x.UnitTo,
                                            ValueTo = x.ValueTo,
                                        }).ToList();


        }
    }
}

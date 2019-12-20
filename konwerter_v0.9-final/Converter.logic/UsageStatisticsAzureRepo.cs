using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public class UsageStatisticsAzureRepo : IUsageStatisticsRepo
    {
        private CloudTable table;

        public UsageStatisticsAzureRepo()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("unitconvertersa", "b0KDTh490cCrpvtScLzqXpvPshiVxVh9e1K4lXRHLHSqPjLet37N6UmYtIpwfw3sUeNsL8dBiZFUDjiYUqjIlw=="), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("UsageStatisticsAB");
            this.table.CreateIfNotExists();
        }
        public void AddStatistic(StatisticDTO statistic)
        {
           using (Model1 context = new Model1())
            {
                UsageStatisticsEntity entity = new UsageStatisticsEntity
                {
                    PartitionKey = string.Empty,
                    RowKey = Guid.NewGuid().ToString(),
                    DateTime = statistic.DateTime,
                    UnitType = statistic.UnitType,
                    InputUnit = statistic.InputUnit,
                    OutputUnit = statistic.OutputUnit,
                    Value = statistic.Value
                };

                TableOperation insertOperation = TableOperation.Insert(entity);
                table.Execute(insertOperation);
            }
        }

        public string GetStatistics()
        {
            //using (Model1 context = new Model1())
            //{
            //    int conversionsNumber = context.Database.SqlQuery<int>("select max(ID) from UsageStatistics").Single();

            //    return conversionsNumber.ToString();
            //}


            TableQuery<UsageStatisticsEntity> tableQuery = new TableQuery<UsageStatisticsEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, string.Empty)).Select(new string[] { "PartitionKey" });

            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => props.ContainsKey("PartitionKey") ? props["PartitionKey"].StringValue : null;

            List<string> entities = new List<string>();

            TableContinuationToken continuationToken = null;
            do
            {
                TableQuerySegment<string> tableQueryResult =
                    table.ExecuteQuerySegmented(tableQuery, resolver, continuationToken);

                continuationToken = tableQueryResult.ContinuationToken;

                entities.AddRange(tableQueryResult.Results);
            } while (continuationToken != null);

            return entities.Count.ToString();
        }

    }
}

﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterZSQLiAZURE.Model;

namespace KonwerterZSQLiAZURE
{
    public class AZURE: ADDStat
    {
        private CloudTable table;

        public AZURE()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.table = client.GetTableReference("StatystykiMateuszZaczek");
            this.table.CreateIfNotExists();
        }

        public void AddStatistic(DBO statistic)
        {
            StatisticsEntity entity = new StatisticsEntity();
            entity.PartitionKey = string.Empty; // computer name;
           entity.RowKey = Guid.NewGuid().ToString();
            entity.Type = statistic.LogKonwersji;
            entity.DateTime = statistic.DataGenerowania;


            TableOperation insertOperation = TableOperation.Insert(entity);

            table.Execute(insertOperation);
        }

        public IEnumerable<DBO> GetStatistics()
        {
            TableQuery<StatisticsEntity> query = new TableQuery<StatisticsEntity>();

            return table.ExecuteQuery(query).Select(obj => new DBO() { DataGenerowania = obj.DateTime, LogKonwersji = obj.Type }).ToList();
        }
    }
}

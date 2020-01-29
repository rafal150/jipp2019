using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using Konwerter8000.Model;

namespace Konwerter8000
{
   public class LogDoAzure : ILog
    {
        CloudTable tAzure;

        public LogDoAzure()
        {
            CloudStorageAccount kAzure = new CloudStorageAccount
            (
                new StorageCredentials
                (
                    ConfigurationManager.AppSettings["StorageName"],
                    ConfigurationManager.AppSettings["StorageKey"]
                ),
            true
            );
            CloudTableClient klientAzure = kAzure.CreateCloudTableClient();
            tAzure = klientAzure.GetTableReference("StatystykiUzyciaWAzureAW");
            tAzure.CreateIfNotExists();
        }

        public void DodajLog(LogDTO log)
        {
            LogEntity logEntity = new LogEntity
            {
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                
                Data = log.Data,
                Id = log.Id,
                ZJednostki = log.ZJednostki,
                DoJednostki = log.DoJednostki,
                WartoscDoPrzeliczen = log.WartoscDoPrzeliczen,
                WartoscPrzeliczona = log.WartoscPrzeliczona

            };
            TableOperation insert = TableOperation.Insert(logEntity);
            tAzure.Execute(insert);
        }

        public IEnumerable<LogDTO> PobierzLog()
        {
            TableQuery<LogEntity> zapytanie = new TableQuery<LogEntity>();
            return tAzure.ExecuteQuery(zapytanie).Select
                 (
                    obj => new LogDTO()
                    {
                        Data = obj.Data,
                        Id = obj.Id,
                        ZJednostki = obj.ZJednostki,
                        DoJednostki = obj.DoJednostki,
                        WartoscPrzeliczona = obj.WartoscPrzeliczona,
                        WartoscDoPrzeliczen = obj.WartoscDoPrzeliczen

                    }
                 ).ToList();
        }
    }
}

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace UnitConversion
{
    public class AzureServiceRepository : IServiceRepository
    {
        private readonly CloudTable conversionHistoryTable;
        private readonly CloudTable convertersTable;
        private readonly CloudTable converterUnitsTable;

        public AzureServiceRepository()
        {
            string storageName = ConfigurationManager.AppSettings["StorageName"];
            string storageKey = ConfigurationManager.AppSettings["StorageKey"];
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(storageName, storageKey), true);
            CloudTableClient client = storageAccount.CreateCloudTableClient();
            this.conversionHistoryTable = client.GetTableReference("ConversionHistory");
            this.conversionHistoryTable.CreateIfNotExists();

            this.convertersTable = client.GetTableReference("Converters");
            this.convertersTable.CreateIfNotExists();

            this.converterUnitsTable = client.GetTableReference("ConverterUnits");
            this.converterUnitsTable.CreateIfNotExists();
        }

        public void AddConversionHistory(ConversionHistoryDTO conversionHistory)
        {
            ConversionHistoryEntity entity = new ConversionHistoryEntity()
            {
                BaseUnit = conversionHistory.BaseUnit,
                BaseValue = conversionHistory.BaseValue,
                ConversionType = conversionHistory.ConversionType,
                Created = conversionHistory.Created,
                PartitionKey = string.Empty,
                RowKey = Guid.NewGuid().ToString(),
                TargetUnit = conversionHistory.TargetUnit,
                TargetValue = conversionHistory.TargetValue
            };
            TableOperation insert = TableOperation.Insert(entity);
            conversionHistoryTable.Execute(insert);

        }

        public void SaveConverter(string converterType, string newConverterType)
        {
            TableQuery<ConverterEntity> query = new TableQuery<ConverterEntity>().Where(TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, converterType));
            ConverterEntity entity = convertersTable.ExecuteQuery(query).FirstOrDefault();
            if (entity == null)
            {
                entity = new ConverterEntity()
                {
                    Created = DateTime.Now,
                    RowKey = Guid.NewGuid().ToString(),
                    PartitionKey = string.Empty
                };
            }
            entity.Name = newConverterType;
            TableOperation insert = TableOperation.InsertOrReplace(entity);
            convertersTable.Execute(insert);
        }

        public IEnumerable<ConversionHistoryDTO> GetConversionHistory()
        {
            TableQuery<ConversionHistoryEntity> query = new TableQuery<ConversionHistoryEntity>();
            return conversionHistoryTable.ExecuteQuery(query).Select(x => new ConversionHistoryDTO()
            {
                BaseUnit = x.BaseUnit,
                BaseValue = x.BaseValue,
                ConversionType = x.ConversionType,
                Created = x.Created,
                TargetUnit = x.TargetUnit,
                TargetValue = x.TargetValue
            }).ToList();
        }

        public IEnumerable<ConverterDTO> GetConverters()
        {
            List<ConverterDTO> cdtoList = new List<ConverterDTO>();
            TableQuery<ConverterEntity> query = new TableQuery<ConverterEntity>();
            TableQuery<ConverterUnitEntity> queryUnits = new TableQuery<ConverterUnitEntity>();
            IEnumerable<ConverterUnitEntity> unitsList = converterUnitsTable.ExecuteQuery(queryUnits);

            foreach(ConverterEntity ce in convertersTable.ExecuteQuery(query))
            {
                ConverterDTO cdto = new ConverterDTO();
                cdto.Created = ce.Created;
                cdto.Name = ce.Name;
                cdto.Units = unitsList.Where(x => x.ConverterRowKey == ce.RowKey).Select(x => new ConverterUnitDTO()
                {
                    Name = x.Name,
                    Converter = cdto,
                    ConversionFromBaseValueFormula = x.ConversionFromBaseValueFormula,
                    ConversionToBaseValueFormula = x.ConversionToBaseValueFormula
                }).ToList();

                cdtoList.Add(cdto);
            }
            return cdtoList;
        }

        public void DeleteConverter(string converterType)
        {
            TableQuery<ConverterEntity> query = new TableQuery<ConverterEntity>().Where(TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, converterType));
            ConverterEntity entity = convertersTable.ExecuteQuery(query).FirstOrDefault();
            TableOperation delete = TableOperation.Delete(entity);
            IEnumerable<ConverterUnitEntity> unitsEntity = converterUnitsTable.ExecuteQuery
                    (
                        new TableQuery<ConverterUnitEntity>().Where(TableQuery.GenerateFilterCondition("ConverterRowKey", QueryComparisons.Equal, entity.RowKey))
                    );
            foreach(ConverterUnitEntity unit in unitsEntity)
            {
                converterUnitsTable.Execute(TableOperation.Delete(unit));
            }
            convertersTable.Execute(delete);
        }

        public void SaveConverterUnit(string ConverterType, string ConverterUnitName, string Name, string ConversionToBaseValueFormula, string ConversionFromBaseValueFormula)
        {
            TableQuery<ConverterEntity> query = new TableQuery<ConverterEntity>().Where(TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, ConverterType));
            ConverterEntity entity = convertersTable.ExecuteQuery(query).FirstOrDefault();
            if (entity != null)
            {
                ConverterUnitEntity unitEntity = converterUnitsTable.ExecuteQuery
                    (
                        new TableQuery<ConverterUnitEntity>().Where
                        (
                            TableQuery.CombineFilters
                            (
                                TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, ConverterUnitName), 
                                TableOperators.And,
                                TableQuery.GenerateFilterCondition("ConverterRowKey", QueryComparisons.Equal, entity.RowKey)
                            )
                        )
                    ).FirstOrDefault();
                if(unitEntity == null)
                {
                    unitEntity = new ConverterUnitEntity()
                    {
                        PartitionKey = string.Empty,
                        RowKey = Guid.NewGuid().ToString(),
                        ConverterRowKey = entity.RowKey
                    };

                }
                unitEntity.Name = Name;
                unitEntity.ConversionFromBaseValueFormula = ConversionFromBaseValueFormula;
                unitEntity.ConversionToBaseValueFormula = ConversionToBaseValueFormula;

                TableOperation insert = TableOperation.InsertOrReplace(unitEntity);
                converterUnitsTable.Execute(insert);
            }

        }

        public void DeleteConverterUnit(string ConverterType, string Name)
        {
            TableQuery<ConverterEntity> query = new TableQuery<ConverterEntity>().Where(TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, ConverterType));
            ConverterEntity entity = convertersTable.ExecuteQuery(query).FirstOrDefault();
            if (entity != null)
            {
                ConverterUnitEntity unitEntity = converterUnitsTable.ExecuteQuery
                   (
                       new TableQuery<ConverterUnitEntity>().Where
                       (
                           TableQuery.CombineFilters
                           (
                               TableQuery.GenerateFilterCondition("Name", QueryComparisons.Equal, Name),
                               TableOperators.And,
                               TableQuery.GenerateFilterCondition("ConverterRowKey", QueryComparisons.Equal, entity.RowKey)
                           )
                       )
                   ).FirstOrDefault();
                if (unitEntity != null)
                {
                    TableOperation delete = TableOperation.Delete(unitEntity);
                    converterUnitsTable.Execute(delete);
                }
            }
        }
    }
}

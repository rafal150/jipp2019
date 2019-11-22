using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.DataBase;
using UnitConverter.DateBase;
using UnitConverter.Statistics;
using UnitConverter.Converters;
namespace UnitConverter
{
    public class Manager
    {
        private ConvertManager cm;
        private SqlRepository dbm;
        private AzureStorageRepository azure;
        private IStatisticsRepository repo;
        public Manager()
        {
            cm = new ConvertManager();
            initRepo();
         //   dbm = new SqlRepository();
          //  azure = new AzureStorageRepository();




        }
        private void initRepo()
        {
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                repo = repo = new AzureStorageRepository();
            }
            else
            {
                repo = new SqlRepository();
            }
        }

        public ConvertManager GetConverter()
        {
            return cm;
        }
        public SqlRepository GetDataBaseManager()
        {
            return dbm;
        }
        public AzureStorageRepository GetAzureStorageRepository()
        {
            return azure;
        }
        public IStatisticsRepository GetRepository()
        {
            return repo;
        }
       
    }
}

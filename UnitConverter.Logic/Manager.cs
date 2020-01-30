using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.DataBase;
using UnitConverter.Statistics;
using UnitConverter.Converters;
namespace UnitConverter
{
    public class Manager
    {
        private ConvertManager cm;
        private IStatisticsRepository repo;
        public Manager()
        {
            cm = new ConvertManager();
            initRepo();

        }
        private void initRepo()
        {
            if (ConfigurationManager.AppSettings["StatisticsRepository"] == "AzureStorage")
            {
                repo = new AzureStorageRepository();
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
        
        public IStatisticsRepository GetRepository()
        {
            return repo;
        }
       
    }
}

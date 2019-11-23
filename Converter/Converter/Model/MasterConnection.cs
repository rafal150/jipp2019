using Plugins;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Model
{
    public class MasterConnection
    {
        private string connectionType = ConfigurationManager.AppSettings["StatisticsRepository"];
        private DataBaseConnection.DataBaseConnection connection = new DataBaseConnection.DataBaseConnection();
        private StatisticsAzureStorageRepository statisticsAzureStorageRepository = new StatisticsAzureStorageRepository();

        public void Add(BaseConverter converter)
        {
            switch (this.connectionType)
            {
                case "AzureStorage":
                    //StatisticsAzureStorageRepository statisticsAzureStorageRepository = new StatisticsAzureStorageRepository();
                    statisticsAzureStorageRepository.AddStatistic(converter);
                    break;
                default:
                    connection.Converters.Add(converter);
                    connection.SaveChanges();
                    break;
            }
        }
        public DataBaseConnection.DataBaseConnection GetLocal()
        {
            return this.connection;
        }

        public IEnumerable<StatisticDTO> GetAzure()
        {
            return this.statisticsAzureStorageRepository.GetStatistics();
        }
    }
}

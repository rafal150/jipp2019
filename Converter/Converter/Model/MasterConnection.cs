using Converter.Program;
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

        public void Add(BaseConverter converter)
        {
            switch (this.connectionType)
            {
                case "AzureStorage":
                    StatisticsAzureStorageRepository statisticsAzureStorageRepository = new StatisticsAzureStorageRepository();
                    statisticsAzureStorageRepository.AddStatistic(converter);
                    break;
                default:
                    DataBaseConnection.Connection connection = new DataBaseConnection.Connection();
                    connection.Converters.Add(converter);
                    connection.SaveChanges();
                    break;
            }
        }
    }
}

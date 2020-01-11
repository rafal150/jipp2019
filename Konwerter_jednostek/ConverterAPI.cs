using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Konwerter_jednostek
{
    public class ConverterAPI
    {
        public IEnumerable<Statystyka> PobierzStatystyki()
        {
            string url = @"http://localhost:7071/api/PobierzStatystyki";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Statystyka[] stats = JsonConvert.DeserializeObject<Statystyka[]>(json);

                return new List<Statystyka>(stats);
            }
        }

        public double Konwertuj(string input, int inputMiaraID, int outputMiaraID)
        {
            string url = @"http://localhost:7071/api/Konwertuj?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("value", input);
            queryString.Add("inputMiaraID", inputMiaraID.ToString());
            queryString.Add("outputMiaraID", outputMiaraID.ToString());

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return double.Parse(valueString);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace NBPConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if(tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();
                    String line;
                    if (rate != null)
                    {                    
                        line = rate.Mid; 
                        try
                        {
                            string modified = line.Replace(".", ",");
                            // Set a variable to the Documents path.
                            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                            File.Delete(Path.Combine(docPath, "KursikWalutek.txt"));
                            // Append text to an existing file named "WriteLines.txt".
                            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "KursikWalutek.txt"), true))
                            {
                                outputFile.WriteLine(modified);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Wyjatek: " + e.Message);
                        }


      
                    }


                 
                    }
                }
            }
        }
    }

    public class TableObject
    {
        public string Table { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public RateObject[] Rates { get; set; }
    }

    public class RateObject
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public string Mid { get; set; }
    }


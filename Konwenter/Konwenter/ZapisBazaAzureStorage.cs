using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    public class ZapisBazaAzureStorage:IBazyDanych
    {
        private CloudTable tabela;
        public ZapisBazaAzureStorage()
        {
            CloudStorageAccount konto = new CloudStorageAccount(new StorageCredentials(ConfigurationManager.AppSettings["StorageName"], ConfigurationManager.AppSettings["StorageKey"]), true);
            CloudTableClient klient = konto.CreateCloudTableClient();
            this.tabela = klient.GetTableReference("Statystyki");
            this.tabela.CreateIfNotExists();
            
        }   
            
        public void zapisDoBazy(ZapisBazaDTO stat)
        {
            StatystykiEntity entity = new StatystykiEntity();
            entity.PartitionKey = "ADRIAN";
            entity.RowKey = Guid.NewGuid().ToString();
            entity.id = stat.id;
            entity.dataZapisu = stat.dataZapisu;
            entity.typKonwersji = stat.typKonwersji;
            entity.zJednostki = stat.zJednostki;
            entity.naJednostke = stat.naJednostke;
            entity.daneWejsc = stat.daneWejsc.ToString();
            entity.daneWyjsc = stat.daneWyjsc.ToString();

            TableOperation insertOperation = TableOperation.Insert(entity);
            tabela.Execute(insertOperation);
        }
        public IEnumerable<ZapisBazaDTO> wyswietlStatystyki()
        {
            TableQuery<StatystykiEntity> zapytanie = new TableQuery<StatystykiEntity>();
            return tabela.ExecuteQuery(zapytanie).Select(x => new ZapisBazaDTO()
            {
                id = x.id,
                dataZapisu = x.dataZapisu,
                typKonwersji = x.typKonwersji,
                zJednostki = x.zJednostki,
                naJednostke = x.naJednostke,
                daneWejsc = string.IsNullOrEmpty(x.daneWejsc) ? null : (decimal?) decimal.Parse(x.daneWejsc),
                daneWyjsc = string.IsNullOrEmpty(x.daneWyjsc) ? null : (decimal?)decimal.Parse(x.daneWyjsc),
            }).ToList();

        }
    }
}

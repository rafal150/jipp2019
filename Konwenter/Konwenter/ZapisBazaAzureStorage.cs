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
            
        public void zapisDoBazy(ZapisBazaPosrednik statystyki)
        {
            StatystykiEntity entity = new StatystykiEntity();
            entity.PartitionKey = "ADRIAN";
            entity.RowKey = Guid.NewGuid().ToString();
            entity.id = statystyki.id;
            entity.dataZapisu = statystyki.dataZapisu;
            entity.typKonwersji = statystyki.typKonwersji;
            entity.zJednostki = statystyki.zJednostki;
            entity.naJednostke = statystyki.naJednostke;
            entity.daneWejsc = statystyki.daneWejsc;
            entity.daneWyjsc = statystyki.daneWyjsc;

            TableOperation insertOperation = TableOperation.Insert(entity);
            tabela.Execute(insertOperation);
        }
        public IEnumerable<ZapisBazaPosrednik> wyswietlStatystyki()
        {
            TableQuery<StatystykiEntity> zapytanie = new TableQuery<StatystykiEntity>();
            return tabela.ExecuteQuery(zapytanie).Select(x => new ZapisBazaPosrednik()
            {
                id = x.id,
                dataZapisu = x.dataZapisu,
                typKonwersji = x.typKonwersji,
                zJednostki = x.zJednostki,
                naJednostke = x.naJednostke,
                daneWejsc = x.daneWejsc,
                daneWyjsc = x.daneWyjsc,
            }).ToList();

        }
    }
}

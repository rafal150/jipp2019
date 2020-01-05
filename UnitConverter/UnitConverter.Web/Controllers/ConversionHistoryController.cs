using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace UnitConversion.Web.Controllers
{
    public class ConversionHistoryController : ApiController
    {
        private IServiceRepository repository;

        public ConversionHistoryController(IServiceRepository repo)
        {
            repository = repo;
        }

        public List<ConversionHistoryDTO> GetConversionHistory()
        {
            return repository.GetConversionHistory().ToList();
        }
    }
}
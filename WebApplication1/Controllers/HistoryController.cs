using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using ConverterLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [Ap
        iController]
    public class HistoryController : Controller
    {

        private readonly IRepository<StatisticsEntryDto> _repository;

        public HistoryController(IRepository<StatisticsEntryDto> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<StatisticsEntryDto> GetHistory()
        {
            return _repository.GetAll();
        }
    }
}
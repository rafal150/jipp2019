using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConverterLogic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
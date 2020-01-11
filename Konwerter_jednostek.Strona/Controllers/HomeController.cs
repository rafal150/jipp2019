using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Konwerter_jednostek.Strona.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private ILogic logicPart;

        public HomeController(ILifetimeScope scope, ILogic logic, IPolaczenie repo, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.logicPart = logic;
            logicPart.Inicjalizuj(repo, convertersService);
        }

        public ActionResult Index()
        {
            List<IKonwertuj> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public string Konwertuj(string value, int inputMiaraID, int outputMiaraID)
        {
            logicPart.UstawInputTypID(inputMiaraID);
            logicPart.UstawOutputTypID(outputMiaraID);
            var output = logicPart.Konwertuj(value,
                                        logicPart.PobierzListeInputowychMiar().Where(x => x.Miara_ID == inputMiaraID).Single(),
                                        logicPart.PobierzListeInputowychMiar().Where(x => x.Miara_ID == outputMiaraID).Single());

            return output;
        }

        public ActionResult About()
        {
            IEnumerable<Statystyka> statystyki = logicPart.PobierzStatystyki();

            return View(statystyki);
        }
    }
}
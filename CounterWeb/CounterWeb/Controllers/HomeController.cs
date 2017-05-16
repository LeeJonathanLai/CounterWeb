using System.Configuration;
using System.Web.Mvc;

namespace CounterWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            new CounterLibrary.CounterService().Initialize();
            return View();
        }

        public ActionResult IncreaseCounter()
        {
            int maxCounter = int.Parse(ConfigurationManager.AppSettings["MaxCounter"].ToString());
            if (new CounterLibrary.CounterService().GetCounter() < maxCounter)
            {
                ViewData["CounterData"] = new CounterLibrary.CounterService().IncreaseCounter();
            }
            else
            {
                ViewData["CounterData"] = new CounterLibrary.CounterService().GetCounter();
            }
            return View();
        }
    }
}
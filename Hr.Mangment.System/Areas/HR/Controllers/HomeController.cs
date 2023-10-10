using Microsoft.AspNetCore.Mvc;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

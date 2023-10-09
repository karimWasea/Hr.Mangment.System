using Microsoft.AspNetCore.Mvc;

namespace Hr.Mangment.System.Areas.Auth
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

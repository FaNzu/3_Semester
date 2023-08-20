using Microsoft.AspNetCore.Mvc;

namespace ClimbingCollectionWeb.Controllers
{
    public class RouteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

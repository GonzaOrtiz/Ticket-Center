using Microsoft.AspNetCore.Mvc;

namespace _cubits.Controllers
{
    public class OriginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

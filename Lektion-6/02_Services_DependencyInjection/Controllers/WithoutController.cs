using _02_Services_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_Services_DependencyInjection.Controllers
{
    public class WithoutController : Controller
    {
        private readonly WithoutService _withoutService = new WithoutService();

        public IActionResult Index()
        {
            return View(_withoutService);
        }
    }
}

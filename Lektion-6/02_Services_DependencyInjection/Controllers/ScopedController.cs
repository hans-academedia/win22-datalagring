using _02_Services_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_Services_DependencyInjection.Controllers
{
    public class ScopedController : Controller
    {
        private readonly ScopedService _scopedService;

        public ScopedController(ScopedService scopedService)
        {
            _scopedService = scopedService;
        }

        public IActionResult Index()
        {
            return View(_scopedService);
        }
    }
}

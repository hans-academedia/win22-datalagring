using _02_Services_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_Services_DependencyInjection.Controllers
{
    public class SingletonController : Controller
    {
        private readonly SingletonService _singletonService;

        public SingletonController(SingletonService singletonService)
        {
            _singletonService = singletonService;
        }

        public IActionResult Index()
        {
            return View(_singletonService);
        }
    }
}

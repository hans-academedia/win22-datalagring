using _02_Services_DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace _02_Services_DependencyInjection.Controllers
{
    public class TransientController : Controller
    {
        private readonly TransientService _transientService;

        public TransientController(TransientService transientService)
        {
            _transientService = transientService;
        }

        public IActionResult Index()
        {
            return View(_transientService);
        }
    }
}

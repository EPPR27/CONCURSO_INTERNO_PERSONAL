using Microsoft.AspNetCore.Mvc.Rendering;
using CONCURSO_INTERNO_PERSONAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CONCURSO_INTERNO_PERSONAL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmvConcursoInternoContext _DBcontext;

        public HomeController(ILogger<HomeController> logger, SmvConcursoInternoContext context)
        {
            _logger = logger;
            _DBcontext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
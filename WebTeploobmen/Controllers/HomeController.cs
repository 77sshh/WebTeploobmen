using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTeploobmen.Data;
using WebTeploobmen.Models;

namespace WebTeploobmen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WebTeploobmenContext _context;
        public HomeController(ILogger<HomeController> logger, WebTeploobmenContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var varisants = _context.Variants.Where(x => x.UserId == null || x.UserId == GetUserId()).ToList();

            return View(varisants);
        }

        [HttpGet]
        public IActionResult Calc(int id)
        {
            var variant = _context.Variants.FirstOrDefault(x => x.Id == id);
            var viewModel = new HomeCalcViewModel();

            if (variant != null)
            {
                viewModel.height = variant.height;
                viewModel.mattemp = variant.mattemp;
                viewModel.gaztemp = variant.gaztemp;
                viewModel.haste = variant.haste;
                viewModel.gaztepl = variant.gaztepl;
                viewModel.rashod = variant.rashod;
                viewModel.mattepl = variant.mattepl;
                viewModel.koef = variant.koef;
                viewModel.diametr = variant.diametr;

            }

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Calc(CalcModel model)
        {

            var viewModel = new HomeCalcViewModel()
            {
            };

            _context.Variants.Add(new Variant
            {
                UserId = GetUserId(),
                height = model.height,
                mattemp = model.mattemp,
                gaztemp = model.gaztemp,
                haste = model.haste,
                gaztepl = model.gaztepl,
                rashod = model.rashod,
                mattepl = model.mattepl,
                koef = model.koef,
                diametr = model.diametr,

            });
            _context.SaveChanges();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Results(int id)
        {
            var variant = _context.Variants
                                  .FirstOrDefault(x => x.Id == id && (x.UserId == GetUserId() || x.UserId == null));

            if (variant == null)
            {
                return NotFound();
            }

            var viewModel = new HomeCalcViewModel
            {
                height = variant.height,
                mattemp = variant.mattemp,
                gaztemp = variant.gaztemp,
                haste = variant.haste,
                gaztepl = variant.gaztepl,
                rashod = variant.rashod,
                mattepl = variant.mattepl,
                koef = variant.koef,
                diametr = variant.diametr
            };

            return View(viewModel);
        }

        public IActionResult Delete(int id)
        {
            var variant = _context.Variants.FirstOrDefault(x => x.Id == id && x.UserId == GetUserId() || x.UserId == null);

            if (variant != null)
            {
                _context.Variants.Remove(variant);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        private int? GetUserId()
        {

            var userIdStr = User.FindFirst("UserId")?.Value;
            int? userId = userIdStr == null ? null : int.Parse(userIdStr);

            return userId;

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
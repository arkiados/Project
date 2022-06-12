using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Project.InventoryContext _context;

        public HomeController(ILogger<HomeController> logger, InventoryContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new Models.InventoryItem();
            model.InventoryItems = _context.Inventory.ToList();
            return View(model);
        }

        public IActionResult Edit()
        {
            var model = new Models.InventoryItem();
            model.InventoryItems = _context.Inventory.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new Models.InventoryItem();
            model.InventoryItems = _context.Inventory.ToList();
            return View(model);
        }

        public IActionResult Delete()
        {
            var model = new Models.InventoryItem();
            model.InventoryItems = _context.Inventory.ToList();
            return View(model);
        }

        public IActionResult Details()
        {
            var model = new Models.InventoryItem();
            model.InventoryItems = _context.Inventory.ToList();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
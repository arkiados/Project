using Microsoft.AspNetCore.Mvc;
using Project.InvInterface;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Project.InventoryContext _context;

        private readonly IInventoryManager inventoryManager;

        public HomeController(ILogger<HomeController> logger, InventoryContext context)
        {
            _logger = logger;
            _context = context;
        }
        public HomeController(ILogger<HomeController> logger, IInventoryManager inventoryManager)
        {
            this.inventoryManager = inventoryManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.ManufacturerSortParm = String.IsNullOrEmpty(sortOrder) ? "manufacturer_desc" : "";
            ViewBag.PurchaseDateSortParm = sortOrder == "PurchaseDate" ? "purchase_date_desc" : "PurchaseDate";
            ViewBag.ExpirationDateSortParm = sortOrder == "ExpirationDate" ? "expiration_date_desc" : "ExpirationDate";

            //var model = from s in _context.Inventory
            //            select s;

            var inventories = 
            switch (sortOrder)
            {
                case "name_desc":
                    model = model.OrderByDescending(s => s.Name);
                    break;
                case "Manufacturer":
                    model = model.OrderBy(s => s.Manufacturer);
                    break;
                case "manufacturer_desc":
                    model = model.OrderByDescending(s => s.Manufacturer);
                    break;
                case "PurchaseDate":
                    model = model.OrderBy(s => s.PurchaseDate);
                    break;
                case "purchase_date_desc":
                    model = model.OrderByDescending(s => s.PurchaseDate);
                    break;
                case "ExpirationDate":
                    model = model.OrderBy(s => s.ExpirationDate);
                    break;
                case "expiration_date_desc":
                    model = model.OrderByDescending(s => s.ExpirationDate);
                    break;
                default:
                    model = model.OrderBy(s => s.Name);
                    break;
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new Models.InventoryItem();
            model  = _context.Inventory.FirstOrDefault(t => t.ItemId == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(inventoryItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryItem);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new Models.InventoryItem();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventoryItem);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(inventoryItem);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = new Models.InventoryItem();
            model = _context.Inventory.FirstOrDefault(t => t.ItemId == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id, InventoryItem inventoryItem)
        {
            if (_context.Inventory == null)
            {
                return Problem("Entity set 'InventoryContext.InventoryItems'  is null.");
            }
            if (inventoryItem != null)
            {
                _context.Inventory.Remove(inventoryItem);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = new Models.InventoryItem();
            model = _context.Inventory.FirstOrDefault(t => t.ItemId == id);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
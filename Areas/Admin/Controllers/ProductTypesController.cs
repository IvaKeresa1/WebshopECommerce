using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop.Data;
using Webshop.Models;

namespace Webshop.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            //var data = 
            return View(_db.ProductTypes.ToList());
        }

        //GET method
        public ActionResult Create()
        {
            return View();
        }

        //POST method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

    }
}
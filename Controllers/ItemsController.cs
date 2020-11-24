using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalmartInventory.Data;

namespace WalmartInventory.Controllers
{
    public class ItemsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            // get the list of products that i wat to show in the main page

            var products = _context.Products.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}
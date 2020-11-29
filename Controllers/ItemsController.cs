using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalmartInventory.Data;
using WalmartInventory.Models;

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
            // get the list of departmet that i wat to show in the main page

            var department = _context.Departments.OrderBy(p => p.Name).ToList();
            return View(department);
        }

        public IActionResult Browse(int id)
        {
            //this query is to get the product by selected departmet
            var products = _context.Products.Where(p => p.DepartmentId == id).OrderBy(p => p.Name).ToList();

            //to show the selected department

            ViewBag.department = _context.Departments.Find(id).Name.ToString();
            return View(products);
        }

        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            // to get the product price
            var price = _context.Products.Find(ProductId).RetailPrice;

            //to get current time and date
            var currentTimeDate = DateTime.Now;

            //EmployeeId variable
            var EmployeeId = GetEmployeeId();

            // e

            //to make new cart create and save object
            var cart = new ShoppingCart
            {
                ProductId = ProductId,
                Quantity = Quantity,
                Price = price,
                DateSelected = currentTimeDate,
                EmployeeId = EmployeeId


            };

            _context.ShoppingCarts.Add(cart);
            _context.SaveChanges();


            // here we return to cart view
            return RedirectToAction("Cart");
        }

        private string GetEmployeeId()
        {
            
            if(HttpContext.Session.GetString("EmployeeId") == null)
            {
                // check if the Employee is logged in, if there is no existing EmpId
                var EmployeeId = "";
                
                //to make the use of email as employee id, when logged in
                if (User.Identity.IsAuthenticated)
                {
                    EmployeeId = User.Identity.Name;

                    // here name is the email used
                }

                // but if user is anonymous, use the guid to create ew identifier
                else
                {
                    EmployeeId = Guid.NewGuid().ToString();
                }

                //now put the emp id in a session variable
                HttpContext.Session.SetString("EmployeeId", EmployeeId);
            }

            // here we return the Session variable

            return HttpContext.Session.GetString("EmployeeId");

        }

        //item/cart
        public IActionResult Cart()
        {

            // getting the current cart to show
            var EmployeeId = "";

            //if user is in cart page but havent add anything, here idetify them first
            if (HttpContext.Session.GetString("EmployeeId") == null)
            {
                EmployeeId = GetEmployeeId();

            }
            else
            {
                EmployeeId = HttpContext.Session.GetString("EmployeeId");
            }
            //to show 

            var cartItems = _context.ShoppingCarts.Where(e => e.EmployeeId == EmployeeId).ToList();

            //passing the data to view
            return View(cartItems);

            //.Include(e => e.Product)
        }
    }
}
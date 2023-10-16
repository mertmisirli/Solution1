using Microsoft.AspNetCore.Mvc;
using Productify.Domain.Entities;
using Productify.Persistent.Contexts;

namespace Productify.Controllers
{
    public class ProductController : Controller
    {
        ProductifyDbContext _context;

        public ProductController()
        {
            _context = new();
        }

        public IActionResult GetAll()
        {
            return View(_context.Products.ToList());
        }

        

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddProduct(string productName)
        {
            _context.Products.Add(new Product(productName));
            _context.SaveChanges();

            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication12.Data;
using WebApplication12.Models;
using WebApplication12.Repositories;

namespace WebApplication12.Controllers
{
    public class ShopController : Controller
    {
        ApplicationDbContext _context;

        public ShopController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ShopRepo shopRepo = new(_context);

            var items = shopRepo.GetProducts();

            return View("Index", items);
        }
    }
}

using WebApplication12.Data;
using WebApplication12.Models;
using WebApplication12.ViewModels;

namespace WebApplication12.Repositories
{
    public class ShopRepo
    {

        ApplicationDbContext _context;

        public ShopRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = _context.Product;
            return products;
        }
    }
}

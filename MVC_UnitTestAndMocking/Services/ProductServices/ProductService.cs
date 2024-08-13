using MVC_UnitTestAndMocking.Entities;

namespace MVC_UnitTestAndMocking.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Masa", Price = 200 },
                new Product { Id = 2, Name = "Sandalye", Price = 300 }
            };
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}

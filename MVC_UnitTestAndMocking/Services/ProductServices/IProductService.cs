using MVC_UnitTestAndMocking.Entities;

namespace MVC_UnitTestAndMocking.Services.ProductServices
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}

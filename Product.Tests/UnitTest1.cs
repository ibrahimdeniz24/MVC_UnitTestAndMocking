using Moq;
using MVC_UnitTestAndMocking.Entities;
using MVC_UnitTestAndMocking.Services.ProductServices;

namespace Products.Tests
{
    public class UnitTest1
    {
        [Fact]

        public void GetAllProducts_ReturnsAllProducts()
        {
            // Arrange Hazýrlýk
            var mockProductService = new Mock<IProductService>();  //Mock Oluþturma: Mock<IProductService> nesnesi oluþturuluyor. Bu, IProductService arayüzü için bir taklit (mock) nesnesi saðlar.
            mockProductService.Setup(service => service.GetAllProducts()).Returns(new List<Product> //Setup Yapma: mockProductService.Setup(...) ile GetAllProducts metodunun çaðrýldýðýnda belirli bir deðer döndürmesini belirliyorsunuz. Bu metod, iki ürün içeren bir liste döndürecek þekilde yapýlandýrýlmýþtýr.
            {
                new Product { Id = 1, Name = "Masa", Price = 200 },
                new Product { Id = 2, Name = "Sandalye", Price = 300 }
            });

            var service = mockProductService.Object; //Moq kütüphanesinin saðladýðý bir özelliktir ve mock nesnesini gerçek bir nesne gibi kullanmanýzý saðlar.

            // Act
            var products = service.GetAllProducts();

            // Assert
            /*  NotNull: products deðiþkeninin null olup olmadýðýný kontrol eder. Liste null olmamalýdýr.
                Equal: Liste uzunluðunun 2 olduðunu doðrular. Bu, iki ürün döndürülmesini kontrol eder.
                Contains: Liste içinde Name deðeri "Masa" olan bir ürün olup olmadýðýný kontrol eder.
                Contains: Liste içinde Name deðeri "Sandalye" olan bir ürün olup olmadýðýný kontrol eder.
             */
            Assert.NotNull(products);
            Assert.Equal(2, products.Count());
            Assert.Contains(products, p => p.Name == "Masa");
            Assert.Contains(products, p => p.Name == "Sandalye");
        }

        [Fact]
        public void GetProductById_ReturnsCorrectProduct()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            mockProductService.Setup(service => service.GetProductById(1)).Returns(new Product
            {
                Id = 1,
                Name = "Masa",
                Price = 200
            });

            var service = mockProductService.Object;

            // Act
            var product = service.GetProductById(1);

            // Assert
            Assert.NotNull(product);
            Assert.Equal("Masa", product.Name);
            Assert.Equal(200, product.Price);
        }
    }
}
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
            // Arrange Haz�rl�k
            var mockProductService = new Mock<IProductService>();  //Mock Olu�turma: Mock<IProductService> nesnesi olu�turuluyor. Bu, IProductService aray�z� i�in bir taklit (mock) nesnesi sa�lar.
            mockProductService.Setup(service => service.GetAllProducts()).Returns(new List<Product> //Setup Yapma: mockProductService.Setup(...) ile GetAllProducts metodunun �a�r�ld���nda belirli bir de�er d�nd�rmesini belirliyorsunuz. Bu metod, iki �r�n i�eren bir liste d�nd�recek �ekilde yap�land�r�lm��t�r.
            {
                new Product { Id = 1, Name = "Masa", Price = 200 },
                new Product { Id = 2, Name = "Sandalye", Price = 300 }
            });

            var service = mockProductService.Object; //Moq k�t�phanesinin sa�lad��� bir �zelliktir ve mock nesnesini ger�ek bir nesne gibi kullanman�z� sa�lar.

            // Act
            var products = service.GetAllProducts();

            // Assert
            /*  NotNull: products de�i�keninin null olup olmad���n� kontrol eder. Liste null olmamal�d�r.
                Equal: Liste uzunlu�unun 2 oldu�unu do�rular. Bu, iki �r�n d�nd�r�lmesini kontrol eder.
                Contains: Liste i�inde Name de�eri "Masa" olan bir �r�n olup olmad���n� kontrol eder.
                Contains: Liste i�inde Name de�eri "Sandalye" olan bir �r�n olup olmad���n� kontrol eder.
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
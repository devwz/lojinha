using lojinha.Core.Data;
using lojinha.Core.Data.Interfaces;
using lojinha.Core.Domain;
using lojinha.ProductCatalog.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.UnitTest.ProductCatalog
{
    [TestClass]
    public class ProductControllerTest
    {
        readonly List<Product> productCatalog = new List<Product>()
        {
            new Product(1, "Product 1", 2),
            new Product(2, "Product 2", 4)
        };

        readonly Mock<ProductRepo> _repoMock;
        readonly Mock<HttpContext> _contextMock;

        public ProductControllerTest()
        {
            _repoMock = new Mock<ProductRepo>(new ApplicationDbContext());
            _contextMock = new Mock<HttpContext>();
        }

        [TestMethod]
        public void ShouldGetProductCatalog()
        {
            // Arrange
            _repoMock.Setup(x => x.All())
                .Returns(productCatalog);

            // Act
            var productController = new ProductController(_repoMock.Object);

            productController.ControllerContext.HttpContext = _contextMock.Object;

            var actionResult = productController.Get();

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(ActionResult<IEnumerable<Product>>));
        }
    }
}

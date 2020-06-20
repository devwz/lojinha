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
        #region config

        readonly List<Product> productCatalog = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Title = "Product 1",
                Price = 2
            },
            new Product()
            {
                Id = 2,
                Title = "Product 2",
                Price = 4
            }
        };

        #endregion

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

            var result = productController.Get();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<IEnumerable<Product>>));
        }

        [TestMethod]
        public void ShouldGetProductById()
        {
            // Arrange
            _repoMock.Setup(x => x.All())
                .Returns(productCatalog);

            // Act
            var productController = new ProductController(_repoMock.Object);

            productController.ControllerContext.HttpContext = _contextMock.Object;

            var result = productController.Get(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Product>));
        }
    }
}

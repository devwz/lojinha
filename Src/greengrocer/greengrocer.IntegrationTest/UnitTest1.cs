using greengrocer.Core.Data;
using greengrocer.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace greengrocer.IntegrationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange

            IQueryable<Product> productQueryable = new List<Product>().AsQueryable();

            Mock<IQueryProvider> queryProviderMock = new Mock<IQueryProvider>();
            queryProviderMock.Setup(p => p.CreateQuery<Product>(It.IsAny<MethodCallExpression>()))
                .Returns<MethodCallExpression>(x => productQueryable);

            Mock<DbSet<Product>> mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>()
                .SetupGet(p => p.Provider)
                .Returns(() => queryProviderMock.Object);

            mockDbSet.As<IQueryable<Product>>()
                .Setup(p => p.Expression)
                .Returns(Expression.Constant(mockDbSet.Object));

            ApplicationDbContext context = new ApplicationDbContext();

            ProductRepo repo = new ProductRepo(context);

            // Act
            IEnumerable<Product> product = repo.All();

            // Assert
            object debug = new object();
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            IQueryable<Product> productQueryable = new List<Product>().AsQueryable();

            Mock<DbSet<Product>> mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(p => p.Provider).Returns(productQueryable.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(p => p.Expression).Returns(productQueryable.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(p => p.ElementType).Returns(productQueryable.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(productQueryable.GetEnumerator());

            Mock<ApplicationDbContext> mockDbContext = new Mock<ApplicationDbContext>();

            ApplicationDbContext context = new ApplicationDbContext();

            ProductRepo repo = new ProductRepo(context);

            // Act
            IEnumerable<Product> product = repo.All();

            // Assert
            object debug = new object();
        }
    }
}

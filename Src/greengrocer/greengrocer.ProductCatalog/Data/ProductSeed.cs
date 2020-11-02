using greengrocer.Core.Data;
using greengrocer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace greengrocer.ProductCatalog.Data
{
    public class ProductSeed
    {
        public static void Seed(ProductRepo repo, int? retry = 1)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!repo.All().Any())
                {
                    foreach (Product product in GetPreconfiguredProductCatalog())
                    {
                        repo.Add(product);
                    }
                }
            }
            catch (Exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    Seed(repo, retryForAvailability);
                }
                throw;
            }
        }

        internal static IEnumerable<Product> GetPreconfiguredProductCatalog()
        {
            for (int i = 1; i < 7; i++)
            {
                Product product = new Product()
                {
                    Id = i,
                    Title = $"Product {i}",
                    Price = i * 2,
                    ImgUrl = $"/assets/product{i}.jpg",
                    Type = $"Type {i}"
                };

                yield return product;
            }
        }
    }
}

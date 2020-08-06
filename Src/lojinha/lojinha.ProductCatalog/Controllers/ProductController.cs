using lojinha.Core.Data;
using lojinha.Core.Domain;
using lojinha.ProductCatalog.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lojinha.ProductCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        readonly ProductRepo repo;

        public ProductController(ProductRepo repo)
        {
            this.repo = repo;
            ProductSeed.Seed(repo);
        }

        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return repo.All().ToList();
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product obj = repo.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // POST api/product
        [HttpPost]
        public ActionResult<Product> Post(Product obj)
        {
            repo.Add(obj);

            return CreatedAtAction("Get", new { id = obj.Id }, obj);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, Product obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            repo.Update(obj);

            return NoContent();
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            Product obj = repo.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            repo.Delete(obj.Id);

            return NoContent();
        }
    }
}

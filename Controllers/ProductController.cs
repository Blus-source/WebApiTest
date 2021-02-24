using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Core;
using WebApiTest.Data;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductData productData;
        private readonly ILogger<ProductController> logger;

        public ProductController(IProductData productData, ILogger<ProductController> logger)
        {
            this.productData = productData;
            this.logger = logger;
        }

        [HttpGet("GetProductsByName/{name}")]
        public IEnumerable<Product> GetProductsByName(string name)
        {
            return productData.GetProductsByName(name);
        }

        [HttpGet("GetAllProducts")]
        public IEnumerable<Product> GetProducts()
        {
            return productData.GetAllProducts();
        }

        [HttpPost("Create")]
        public Product Create(Product newProduct)
        {
            Product p = productData.Create(newProduct);
            productData.Commit();
            return p;
        }

        [HttpPost("Update")]
        public Product Update(Product updatedProduct)
        {
            Product product = productData.Update(updatedProduct);
            productData.Commit();
            return product;
        }

        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            Product product = productData.Delete(id);
            productData.Commit();
            return product;
        }
    }
}

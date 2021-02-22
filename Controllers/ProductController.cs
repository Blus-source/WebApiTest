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
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationContext _applicationContext;

        private readonly ILogger<ProductController> _logger;
        public ProductController(ApplicationContext applicationContext, ILogger<ProductController> logger)
        {
            _logger = logger;
            _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //-- TODO : Faire les procédures stockées pour remplacer les query (car bonne pratique) 
            //string query = @"select ProductId, ProductName, ProductDescription, ProductPrice, ProductImage from Product";
            //DataTable dataTable = new DataTable();

            return _applicationContext.Product;
        }

        [Route("GetProducts")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _applicationContext.Product.ToListAsync();
        }

        [HttpPost]
        public int Post(Product product)
        {
            _applicationContext.Product.AddAsync(product);
            return _applicationContext.SaveChanges();
        }

        [HttpDelete]
        public int Delete(int id)
        {
            Product productToRemove = _applicationContext.Product.FirstOrDefault(f => f.ProductId == id);
            _applicationContext.Product.Remove(productToRemove);
            return _applicationContext.SaveChanges();
        }

        [HttpPut]
        public void Put()
        {

        }

        [Route("Update")]
        [HttpPut]
        public int Update(Product product)
        {
            _applicationContext.Product.Update(product);
            return _applicationContext.SaveChanges();
        }
    }
}

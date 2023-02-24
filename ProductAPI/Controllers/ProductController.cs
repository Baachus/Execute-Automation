using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Repository;
using System.Collections.Generic;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult<List<Product>> GetProducts()
        {
            return productRepository.GetAllProducts();
        }

        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        [HttpGet]
        [Route("/[controller]/[action]/{name}")]
        public Product GetProductByName(string name)
        {
            return productRepository.GetProductByName(name);
        }

        [HttpPost]
        [Route("/[controller]/[action]")]
        public Product AddProduct(Product product)
        {
            return productRepository.AddProduct(product);
        }

        [HttpPut]
        [Route("/[controller]/[action]")]
        public Product UpdateProduct(Product product)
        {
            return productRepository.UpdateProduct(product);
        }

        [HttpDelete]
        [Route("/[controller]/[action]/{id}")]
        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }
    }
}
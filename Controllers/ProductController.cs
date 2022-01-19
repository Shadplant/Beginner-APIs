using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _18_1_22_Beginner_APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _18_1_22_Beginner_APIs.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        IProductRepository ProductRepository;

        public ProductController(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<ProductItem> Get()
        {
            return ProductRepository.Get();
        }

        [HttpGet("{id}", Name = "GetProductItem")]
        public IActionResult Get(int Id)
        {
            ProductItem todoItem = ProductRepository.Get(Id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return new ObjectResult(todoItem);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductItem productItem)
        {
            if (productItem == null)
            {
                return BadRequest();
            }
            ProductRepository.Create(productItem);
            return CreatedAtRoute("GetProductItem", new { id = productItem.ProductId }, productItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int Id, [FromBody] ProductItem updatedProductItem)
        {
            if (updatedProductItem == null || updatedProductItem.ProductId != Id)
            {
                return BadRequest();
            }

            var productItem = ProductRepository.Get(Id);
            if (productItem == null)
            {
                return NotFound();
            }

            ProductRepository.Update(updatedProductItem);
            return RedirectToRoute("GetAllProducts");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            var deletedProductItem = ProductRepository.Delete(Id);

            if (deletedProductItem == null)
            {
                return BadRequest();
            }

            return new ObjectResult(deletedProductItem);
        }
    }
}

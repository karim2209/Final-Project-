using System;
using FianlProject.Filters;
using FianlProject.Filters.ActionFilters;
using FianlProject.Filters.ExceptionFilters;
using FianlProject.Models;
using FianlProject.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FianlProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsControllercs : ControllerBase
    {

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(ProductRepository.GetProducts());
        }
        [HttpGet("{id}")]
        [Product_ValidateProductIdFilter]
        public IActionResult GetProductById(int id)
        {
            return Ok(ProductRepository.GetProductById(id));
        }

        [HttpPost]
        [Product_ValidateCreateProductFilter]
        public IActionResult CreateProduct([FromForm] Product product)
        {
            ProductRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetProductById),
                new { id = product.Id },
                product);

           
        }
        [HttpPut("{id}")]
        [Product_ValidateProductIdFilter]
        [Product_ValidateUpdateProductFilter]
        [Product_HandleUpdateExceptionsFilter]
        public IActionResult UpdateProduct(int id, Product product)
        {

            ProductRepository.UpdateProduct(product);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Product_ValidateProductIdFilter]
        public IActionResult DeleteProduct(int id)
        {
            var product = ProductRepository.GetProductById(id);
            ProductRepository.Deleteproduct(id);
            return Ok(product);
        }

    }
}
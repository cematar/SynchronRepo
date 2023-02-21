using CoreLayer.DTOs;
using CoreLayer.Entities;
using CoreLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IService<Product> _service;

        public ProductController(IService<Product> service)
        {

            _service = service;
        }

        [HttpGet]
        [Route("Allproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                List<Product> products = await _service.GetAll().ToListAsync();
                List<ProductDto> productsResult = new List<ProductDto>();

                //Mapping manually
                products.ForEach(p =>
                {

                    productsResult.Add(new ProductDto()
                    {
                
                        Name = p.Name,
                        Price = p.Price,
                        Stock = p.Stock
                    });
                });

                return Ok(productsResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);

            }         
        }

        [HttpGet("productbyid/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {

            try
            {
                Product product = await _service.GetById(id);
                //Mapping manually
                ProductDto productDto = new ProductDto()
                {
               
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock

                };

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
           
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        {

            try
            {
                Product product = new Product() {

                    Name = productDto.Name,
                    Price = productDto.Price,
                    Stock = productDto.Stock,
                    CategoryId = productDto.CategoryId
                
                };

                await _service.Add(product); 
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("addproducts")]
        public async Task<IActionResult> AddProduct(List<ProductDto> productDtos)
        {

            try
            {

                foreach(ProductDto productDto in productDtos)
                {
                    Product product = new Product()
                    {

                        Name = productDto.Name,
                        Price = productDto.Price,
                        Stock = productDto.Stock,
                        CategoryId = productDto.CategoryId

                    };

                    await _service.Add(product);
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

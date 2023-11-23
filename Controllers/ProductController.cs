using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIChallenge.Entities;
using APIChallenge.Services;
using APIChallenge.DTO;
using Microsoft.AspNetCore.Authorization;
using APIChallenge.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            _mapper = mapper;
            this.configuration = configuration;
        }

        [HttpGet, Route("GetAllProducts")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllProducts()
        {
            try
            {
                List<Product> products = productService.GetAllProducts();
                List<ProductDTO> productsDto = _mapper.Map<List<ProductDTO>>(products); 
                return StatusCode(200, productsDto); 
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetProductById/{productId}")]
        [Authorize] //all authenticated users can access
        public IActionResult Get(int productId)
        {
            try
            {
                Product product = productService.GetProductById(productId);
                ProductDTO productDto = _mapper.Map<ProductDTO>(product);
                if (product != null)
                    return StatusCode(200, product);
                else
                    return StatusCode(404, new JsonResult("Invalid Id")); 
                
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Roles = "Supplier")]
        [HttpPost, Route("AddProduct")]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto); 
                productService.AddProduct(product);
                return StatusCode(200, product); 
                
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("UpdateProduct")]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(ProductDTO productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto); 
                productService.UpdateProduct(product);
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteProduct/{productId}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int productId)
        {
            try
            {
                productService.DeleteProduct(productId);
                return StatusCode(200, new JsonResult($"Product with Id {productId} is Deleted"));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

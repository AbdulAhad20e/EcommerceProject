using Microsoft.AspNetCore.Mvc;
using Backend_ECommerce_App.Models;
using DTOS;
using APILayer.Services.Admin;
using APILayer.Services.User;
using DTOS;

namespace API_project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductAdminService _productAdminService;
        private readonly IProductUserService _productUserService;
        private PreferenceService _preferenceService = new PreferenceService();

        public ProductController(IProductAdminService c, IProductUserService s)
        {
            _productAdminService = c;
            _productUserService = s;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Index");
        }

        [HttpGet("allProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productUserService.GetAllProducts());
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return NotFound();

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Ratings = productDto.Ratings,
                ImagePath = productDto.ImagePath,
                CategoryID = productDto.CategoryID
            };

            _productAdminService.AddProduct(product);
            return Ok();
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetProductbyID(int id)
        {
            var s = _productUserService.GetProductByID(id);
            if (s == null)
                return NotFound();

            return Ok(s);
        }

        [HttpGet("getbyCategory/{categoryID}")]
        public IActionResult GetProductByCategory(int categoryID)
        {
            return Ok(_productUserService.GetProductsByCategory(categoryID));
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return NotFound();

            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Ratings = productDto.Ratings,
                ImagePath = productDto.ImagePath,
                CategoryID = productDto.CategoryID
            };

            _productAdminService.UpdateProduct(product);
            return Ok();
        }

        [HttpDelete("deleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productAdminService.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("search/{query}")]
        public IActionResult SearchProduct(string query)
        {
            _preferenceService.SaveKey(HttpContext, query);
            return Ok(_productUserService.SearchProduct(query));
        }

        [HttpGet("recommendeditems")]
        public IActionResult GetRecommendedItems()
        {
            List<string> userKeywords = _preferenceService.GetKeywords(HttpContext);
            return Ok(_productUserService.GetRecommendedProducts(userKeywords));
        }
    }
}

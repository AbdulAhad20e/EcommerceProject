using APILayer.Services.Admin;
using DTOS;
using Backend_ECommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService s)
        {
            _categoryService = s;
        }

        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetAllCategorys());
        }

        [HttpPost("addcategory")]
        public IActionResult AddCategory([FromBody] CategoryDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                Products = categoryDto.Products?.Select(p => new Product
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Ratings = p.Ratings,
                    ImagePath = p.ImagePath
                }).ToList()
            };

            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpPut("updatecategory")]
        public IActionResult EditCategory([FromBody] CategoryDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName,
                Products = categoryDto.Products?.Select(p => new Product
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    Ratings = p.Ratings,
                    ImagePath = p.ImagePath
                }).ToList()
            };

            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete("deletecategory/{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}


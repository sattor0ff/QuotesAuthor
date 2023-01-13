using Domain.Dtos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        [HttpGet("Category")]
        public List<CategoryDto> Quote()
        {
            return _categoryService.GetCategories();
        }
        [HttpPost("Add")]
        public bool Add(CategoryDto category)
        {
            return _categoryService.AddCategory(category);
        }
        [HttpPut("Update")]
        public bool Update(CategoryDto category)
        {
            return _categoryService.UpdateCategory(category);
        }
        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _categoryService.DeleteCategory(id);
        }
    }
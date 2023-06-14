using AkademiPlusMicroServiceProject.Catalog.DTOs;
using AkademiPlusMicroServiceProject.Catalog.Services.Abstract;
using AkademiPlusMicroServiceProject.Shared.ControllerBases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID( string id)
        {
            var category= await _categoryService.GetByIDAsync(id);
            return CreateActionResultInstance(category);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateCategoryDTO)
        {
            var category = await _categoryService.UpdateAsync(updateCategoryDTO);
            return CreateActionResultInstance(category);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var category = await _categoryService.DeleteAsync(id);
            return CreateActionResultInstance(category);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryDTO createCategoryDTO)
        {
            var category = await _categoryService.CreateAsync(createCategoryDTO);
            return CreateActionResultInstance(category);
        }
    }
}

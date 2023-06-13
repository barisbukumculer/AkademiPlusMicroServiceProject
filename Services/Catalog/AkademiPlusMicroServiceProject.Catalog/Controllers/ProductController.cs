using AkademiPlusMicroServiceProject.Catalog.DTOs;
using AkademiPlusMicroServiceProject.Catalog.Services.Abstract;
using AkademiPlusMicroServiceProject.Catalog.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(string id)
        {
            var products = await _productService.GetByIDAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var products = await _productService.UpdateAsync(updateProductDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var products = await _productService.DeleteAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDTO createProductDTO)
        {
            var products = await _productService.CreateAsync(createProductDTO);
            return Ok();
        }
    }
}

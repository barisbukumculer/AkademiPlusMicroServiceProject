using AkademiPlusMicroServiceProject.Catalog.DTOs;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ProductDTO>>> GetAllAsync();
        Task<Response<ProductDTO>> CreateAsync(CreateProductDTO createProductDTO);
        Task<Response<ProductDTO>> GetByIDAsync(string id);
        Task<Response<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO);
        Task<Response<NoContent>> DeleteAsync(string id);
    }
}

using AkademiPlusMicroServiceProject.Catalog.DTOs;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
       Task<Response<List<CategoryDTO>>>GetAllAsync();
       Task<Response<CategoryDTO>> CreateAsync(CreateCategoryDTO createCategoryDTO);
       Task<Response<CategoryDTO>> GetByIDAsync(string id);
       Task<Response<NoContent>> UpdateAsync(UpdateCategoryDTO updateCategoryDTO);
       Task<Response<NoContent>> DeleteAsync(string id);
    }
}

using AkademiPlusMicroServiceProject.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using AkademiPlusMicroServiceProject.Discount.Models;

namespace AkademiPlusMicroServiceProject.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Models.Discount>>> GetAll();
        Task<Response<Models.Discount>> GetByID(int id);
        Task<Response<NoContent>> Save(Models.Discount discount);
        Task<Response<NoContent>> Update(Models.Discount discount);
        Task<Response<NoContent>> Delete(int id);
        Task<Response<Models.Discount>> GetByCodeWithUserID(string code,string userID);
    }
}

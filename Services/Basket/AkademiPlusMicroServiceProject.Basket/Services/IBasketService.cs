using AkademiPlusMicroServiceProject.Basket.DTOs;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDTO>> GetBasket(string UserID);
        Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO);
        Task<Response<bool>> Delete(string UserID);
        
    }
}

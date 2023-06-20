using AkademiPlusMicroServiceProject.Basket.DTOs;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using System.Text.Json;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string UserID)
        {
            var status=await _redisService.GetDb().KeyDeleteAsync(UserID);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail(404,"Sepet Bulunamadı!");
        }

        public async Task<Response<BasketDTO>> GetBasket(string UserID)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(UserID);
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDTO>.Fail(404, "Sepet Bulunamadı!");
            }
            else
            {
                return Response<BasketDTO>.Success(200,JsonSerializer.Deserialize<BasketDTO>(existBasket));
            }
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDTO basketDTO)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDTO.UserID,JsonSerializer.Serialize(basketDTO));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail(404, "Bir Hata Oluştu!");
        }
    }
}

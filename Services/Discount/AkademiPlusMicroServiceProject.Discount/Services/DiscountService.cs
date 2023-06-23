using AkademiPlusMicroServiceProject.Shared.DTOs;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbconnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbconnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgrSQL"));
        }

        public Task<Response<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discounts = await _dbconnection.QueryAsync<Models.Discount>("select * from discount");
            return Response<List<Models.Discount>>.Success(200,discounts.ToList());
        }

        public Task<Response<Models.Discount>> GetByCodeWithUserID(string code, string userID)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<Models.Discount>> GetByID(int id)
        {
            var discount = (await _dbconnection.QueryAsync<Models.Discount>("select * from discount where id=@Id",new {Id=id})).SingleOrDefault();
            return Response<Models.Discount>.Success(200,discount);
            
        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            var status = await _dbconnection.ExecuteAsync("insert into discount (userID, rate , code) values (@userID, @rate,@code)",discount);
            return Response<NoContent>.Success(204); 
        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbconnection.ExecuteAsync("update discount set userID=@userID, rate=@rate , code=@code where id=@Id",new {Id=discount.ID , userID=discount.UserID,code=discount.Code,rate=discount.Rate});
            return Response<NoContent>.Success(204);
        }
    }
}

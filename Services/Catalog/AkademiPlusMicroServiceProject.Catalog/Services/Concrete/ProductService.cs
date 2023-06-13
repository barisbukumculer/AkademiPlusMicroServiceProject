using AkademiPlusMicroServiceProject.Catalog.DTOs;
using AkademiPlusMicroServiceProject.Catalog.Models;
using AkademiPlusMicroServiceProject.Catalog.Services.Abstract;
using AkademiPlusMicroServiceProject.Catalog.Settings;
using AkademiPlusMicroServiceProject.Shared.DTOs;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroServiceProject.Catalog.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<ProductDTO>> CreateAsync(CreateProductDTO createProductDTO)
        {
            var product = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(product);
            return Response<ProductDTO>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.ProductID == id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail(404, "ID Bulunamadı");
            }
        }

        public async Task<Response<List<ProductDTO>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();
            return Response<List<ProductDTO>>.Success(200, _mapper.Map<List<ProductDTO>>(products));
        }

        public async Task<Response<ProductDTO>> GetByIDAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return Response<ProductDTO>.Fail(404, "Kategori Bulunamadı");
            }
            else
            {
                return Response<ProductDTO>.Success(200, _mapper.Map<ProductDTO>(product));
            }
        }

        public async Task<Response<NoContent>> UpdateAsync(UpdateProductDTO updateProductDTO)
        {
            var product = _mapper.Map<Product>(updateProductDTO);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDTO.ProductID, product);
            if (result == null)
            {
                return Response<NoContent>.Fail(404, "Kategori Bulunamadı");
            }
            else
            {
                return Response<NoContent>.Success(204);
            }
        }
    }
}

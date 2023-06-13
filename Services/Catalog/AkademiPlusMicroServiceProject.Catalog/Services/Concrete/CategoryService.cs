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
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService( IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<CategoryDTO>> CreateAsync(CreateCategoryDTO createCategoryDTO)
        {
           var category=_mapper.Map<Category>(createCategoryDTO);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDTO>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _categoryCollection.DeleteOneAsync(x=>x.CategoryID== id);
            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
              return  Response<NoContent>.Fail( 404,"ID Bulunamadı");
            }
        }

        public async Task<Response<List<CategoryDTO>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return Response<List<CategoryDTO>>.Success(200,_mapper.Map<List<CategoryDTO>>(categories));
        }

        public async Task<Response<CategoryDTO>> GetByIDAsync(string id)
        {
            var category=await _categoryCollection.Find<Category>(x=>x.CategoryID== id).FirstOrDefaultAsync();
            if (category == null)
            {
                return Response<CategoryDTO>.Fail(404, "Kategori Bulunamadı");
            }
            else
            {
                return Response<CategoryDTO>.Success(200, _mapper.Map<CategoryDTO>(category));
            }
         }

        public async Task<Response<NoContent>> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            var category=_mapper.Map<Category>(updateCategoryDTO);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDTO.CategoryID,category);
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

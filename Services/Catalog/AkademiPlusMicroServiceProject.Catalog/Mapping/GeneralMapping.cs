using AkademiPlusMicroServiceProject.Catalog.DTOs;
using AkademiPlusMicroServiceProject.Catalog.Models;
using AutoMapper;
using System.Runtime.InteropServices;

namespace AkademiPlusMicroServiceProject.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();

            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}

using AkademiPlusMicroServiceProject.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace AkademiPlusMicroServiceProject.Catalog.DTOs
{
    public class ProductDTO
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }

        public string CategoryID { get; set; }
       
        public CategoryDTO Category { get; set; }
    }
}

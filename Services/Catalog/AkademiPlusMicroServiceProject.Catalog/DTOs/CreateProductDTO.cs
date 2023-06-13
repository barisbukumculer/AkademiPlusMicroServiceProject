namespace AkademiPlusMicroServiceProject.Catalog.DTOs
{
    public class CreateProductDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryID { get; set; }
    }
}

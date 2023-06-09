namespace AkademiPlusMicroServiceProject.Catalog.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ProductDescription { get; set; }
        public string ImageUrl { get; set; }
    }
}

namespace AkademiPlusMicroServiceProject.FrontEnds.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUrl { get; set; }
        public string PhotoStockUrl { get; set; }
        public string GatewayBaseUrl { get; set; }
        public ServiceApi Catalog { get; set; }
        public ServiceApi Basket { get; set; }
        public ServiceApi Photostock { get; set; }
        public ServiceApi Order { get; set; }
        public ServiceApi Discount { get; set; }
        public ServiceApi FakePayment { get; set; }
        public class ServiceApi 
        { 
            public string Path { get; set; }
        }
    }
}

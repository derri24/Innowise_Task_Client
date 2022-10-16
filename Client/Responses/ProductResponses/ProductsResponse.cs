using Client.Models;

namespace Client.ProductResponses
{
    public class ProductsResponse
    { 
        public ProductsModel Model { get; set; }
        public StatusResponse StatusResponse { get; set; }
    }
}
using Client.Models;

namespace Client.ProductResponses
{
    public class UpdateProductResponse
    {
        public StatusResponse StatusResponse { get; set; }
        public  UpdateProductModel Model{ get; set; }
    }
}
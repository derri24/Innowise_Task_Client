using System.Collections.Generic;

namespace Client.Models
{
    public class ProductsModel
    {
        public List<ProductModel> Products { get; set; }
        public int FridgeId { get; set; }
        public ProductsModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
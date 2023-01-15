﻿using System.Collections.Generic;

namespace Client.Models
{
    public class CreateProductsModel
    {
        public int FridgeId { get; set; }
        public List<ProductModel> Products { get; set; }

        public CreateProductsModel()
        {
            Products = new List<ProductModel>();
        }
    }
}
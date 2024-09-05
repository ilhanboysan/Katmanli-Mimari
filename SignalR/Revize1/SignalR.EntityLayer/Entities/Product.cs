﻿namespace SignalR.EntityLayer.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice{ get; set; }
        public string ProductImageUrl{ get; set; }
        public bool ProductStatus{ get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public List<Basket> Baskets{ get; set; }
    }
}

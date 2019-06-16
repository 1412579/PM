using System;
using System.Collections.Generic;

namespace PM.Models
{
    [Serializable]
    public class ProductView
    {
        public Products Product { get; set; }
        public ProductCategory Category{ get; set; }
        public ProductUnit Unit { get; set; }
        public int InStock { get; set; }
    }

    [Serializable]
    public class ImportView
    {
        public Products Product { get; set; }
        public ProductImport Import { get; set; }
    }

    [Serializable]
    public class CoreBrain
    {
        public long ProductId { get; set; }
        public int Quantity { get; set; }
    }

    [Serializable]
    public class ProductCart
    {
        public ProductView Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }

    [Serializable]
    public class SalesOrder
    {
        public List<ProductCart> Products { get; set; }
        public Contacts Contact { get; set; }
        public decimal Total { get; set; }
    }

}

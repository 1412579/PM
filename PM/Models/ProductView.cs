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
    }
}

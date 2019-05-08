using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? UnitPrice { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountAmount { get; set; }
    }
}

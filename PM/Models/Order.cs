using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public string Note { get; set; }
        public int? OrderStatusId { get; set; }
        public int? PaymentStatusId { get; set; }
        public int? PaymentMethod { get; set; }
        public decimal? CurrentIncome { get; set; }
        public decimal? CurrentBalance { get; set; }
        public decimal? OrderDiscount { get; set; }
        public decimal? OrderTotal { get; set; }
        public string CustomerIp { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
        public string ShippingName { get; set; }
        public int? ShippingGender { get; set; }
        public int? IdentityType { get; set; }
        public string IdentityNumber { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingEmail { get; set; }
    }
}

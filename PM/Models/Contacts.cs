using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Contacts
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public byte? Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Address { get; set; }
    }
}

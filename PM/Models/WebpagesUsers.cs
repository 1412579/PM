using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class WebpagesUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? IsLock { get; set; }
        public int? LoginFail { get; set; }
    }
}

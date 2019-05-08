using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class UserDevices
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public string Token { get; set; }
    }
}

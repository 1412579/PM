using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Citys
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int? Position { get; set; }
        public int? Type { get; set; }
        public bool? IsDeparture { get; set; }
    }
}

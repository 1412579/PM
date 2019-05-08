using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class WebLinks
    {
        public int LinkId { get; set; }
        public string LinkName { get; set; }
        public string Url { get; set; }
        public int? Position { get; set; }
    }
}

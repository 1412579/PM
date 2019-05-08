using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class NewsTags
    {
        public long TagId { get; set; }
        public long NewsId { get; set; }
        public string TagName { get; set; }
        public string NewsTitle { get; set; }
        public long Id { get; set; }
    }
}

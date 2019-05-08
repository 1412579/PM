using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class StaticPage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hotline { get; set; }
        public string Logo { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public string Copyright { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyWord { get; set; }
        public string MetaDescription { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Content4 { get; set; }
        public string Content5 { get; set; }
        public int? OnlineCounter { get; set; }
        public long? ViewCounter { get; set; }
    }
}

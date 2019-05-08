using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ProductPicture
    {
        public int PictureId { get; set; }
        public string PictureName { get; set; }
        public int? ProductId { get; set; }
        public string Bimage { get; set; }
        public string Mimage { get; set; }
        public string Simage { get; set; }
        public int? Position { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UserId { get; set; }
    }
}

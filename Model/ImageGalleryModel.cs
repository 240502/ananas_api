using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ImageGalleryModel
    {
        public int id { get; set; }
        public string img_src { get; set; }
        public int product_id { get; set; }
        public bool feature { get; set; }
    }
}

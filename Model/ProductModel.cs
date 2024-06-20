using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductModel
    {
        public int id { get; set; }
        public string pro_name { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int status_id { get; set; }
        public int cate_id { get; set; }
        public int style_id { get; set; }
        public int collection_id { get; set; }
        public int material_id { get; set; }
        public int color_id { get; set; }
        public string gender { get; set; }
        public string out_sole { get; set; }

        public ImageGalleryModel imageGallery{get;set;}
        public ProductPriceModel priceModel { get;set;}
        public List<ProductDetailModel> productDetails { get; set;}
    }
}

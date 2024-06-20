using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductDetailModel
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public int product_id { get; set; }
        public int size { get; set; }
        public int status { get; set; }
    }
}

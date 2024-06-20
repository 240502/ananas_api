using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderDetailModel
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int color_id { get; set; }
        public int size_id { get; set; }
        public int style_id { get;set; }

    }
}

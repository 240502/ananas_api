using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ShippingTypeModel
    {
        public int id { get; set; }
        public string shippingType_name { get; set; }
        public DateTime create_at { get; set; }
        public DateTime update_at { get; set;}
        public int price { get;set; }
    }
}

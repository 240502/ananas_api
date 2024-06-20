using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderModel
    {
        public int id { get; set; }
        public string receiving_address { get; set; }
        public string phone_number { get; set; }
        public int money_total { get; set; }
        public DateTime order_date { get; set; }
        public DateTime update_at { get; set; }
        public int status_id { get; set; }
        public int paymentType_id { get; set; }

        public int shippingType_id { get; set; }
        public string email { get; set; }   
        public string full_name { get; set; }

        public List<OrderDetailModel> orderDetails { get; set; }
        public int totalProduct { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaymentTypeModel
    {
        public int id { get; set; }
        public string paymentType_name { get; set; }    
        public string thumbnail { get; set; }
        public DateTime create_at { get; set; } 
        public DateTime update_at { get; set;}
    }
}

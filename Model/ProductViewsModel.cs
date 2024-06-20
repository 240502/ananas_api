using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ProductViewsModel
    {
        public int id { get; set; } 
        public int count { get; set; }
        public int product_id { get; set; }
        public DateTime date_view { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ImportBillDetailModel
    {
        public int id { get; set; }
        public int importbill_id { get; set; }
        public int pro_id { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int color_id { get; set; }
        public int size_id { get; set; }
        public int status { get; set; }

    }
}

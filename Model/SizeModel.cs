﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SizeModel
    {
        public int id { get; set; }
        public string size { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int shoe_size { get; set; }
    }
}

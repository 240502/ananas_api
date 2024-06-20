﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ColorModel
    {
        public int id { get; set; }
        public string color_name { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string color_code { get; set; }
    }
}

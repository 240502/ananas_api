using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NewsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public int user_id { get; set; }
        public string content { get; set; }
        public DateTime public_date { get; set; }
    }
}

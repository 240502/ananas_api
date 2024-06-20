using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UsersModel
    {
        public int id { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
        public bool active { get; set; }
        public string us_name { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public DateTime birthday { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string token {  get; set; }
    }
}

using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class StatusOrderBUS
    {
        StatusOrderDAL statusOrderDAL = new StatusOrderDAL();
        public List<StatusOrderModel> getAll()
        {
            return statusOrderDAL.getList();
        }
    }
}

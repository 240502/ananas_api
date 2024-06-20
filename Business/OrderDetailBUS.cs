using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class OrderDetailBUS
    {
        OrderDetailDAL orderDetailDAL = new OrderDetailDAL();
        public int Create(OrderDetailModel model)
        {
            return orderDetailDAL.Create(model);
        }

        public int Update(OrderDetailModel model)
        {
            return orderDetailDAL.Update(model);
        }

        public int Delete(int id)
        {
            return orderDetailDAL.Delete(id);
        }
    }
}

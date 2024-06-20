using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
using Microsoft.VisualBasic;
namespace Business
{
    public class OrderBUS
    {
        OrderDAL odDAL = new OrderDAL();

        public List<OrderModel> getListOrderWaitConfirmation(int? pageIndex, int? pageSize, int status_id, out int total)
        {
            return odDAL.GetListOrderWaitConfirmation(pageIndex, pageSize,status_id,out total);
        }
        public List<OrderModel> search(int? pageIndex, int? pageSize, string value ,int status_id, out int total)
        {
            return odDAL.search(pageIndex, pageSize, value,status_id, out total);
        }
        public List<OrderStatisticsModel> CountOrderYear()
        {
            return odDAL.CountOrderYear();
        } 
        public Dictionary<string,int> GetTotalOrderToday()
        {
            return odDAL.GetTotalOrderToday();
        }

        public List<Dictionary<string, int>> RevenueStatistics(int? fr_month, int? to_month)
        {
            return odDAL.RevenueStatistics(fr_month, to_month);
        }


        public int Create(OrderModel order)
        {
            return odDAL.Create(order);
        }
        public int Update(OrderModel order)
        {
            return odDAL.Update(order);
        }
        public int Delete(int id) {
            return odDAL.Delete(id);
        }

        public int Cancel (int id)
        {
            return odDAL.Cancel(id);
        }
        public OrderModel getOrderByIdAndPhoneOrEmail(int id , string option)
        {
            return odDAL.GetByIdAndPhoneOrEmail(id, option);
        }
        public OrderModel GetById(int id)
        {
            return odDAL.GetById(id);
        }
    }
}

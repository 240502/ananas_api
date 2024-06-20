using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helper;
using Model;
namespace DataAccessLayer
{
    public class OrderDetailDAL
    {
        DataHelper helper = new DataHelper();
        public int Create(OrderDetailModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateOrderDetail","@orderId","@product_id","@quantity","@price","@size_id","@color_id","@style_id",
                                                    model.order_id,model.product_id,model.quantity,model.price,model.size_id,model.color_id,model.style_id);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(OrderDetailModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_UpdateOrderDetail", "@order_id", "@product_id", "@quantity", "@price", "@size_id", "@color_id", "@style_id", "@id",
                                                    model.order_id, model.product_id, model.quantity, model.price, model.size_id, model.color_id, model.style_id,model.id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int id)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_DeleteOrderDetail", "@id",id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

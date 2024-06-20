using DataAccessLayer.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductViewsDAL
    {
        DataHelper helper = new DataHelper();
        public int Create(ProductViewsModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateProductView","@product_id","@count", "@date_view", model.product_id,model.count,model.date_view);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetTotalView()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_TotalViewProduct");
                if (tb != null)
                {
                    int total = int.Parse(tb.Rows[0]["total"].ToString());
                    return total;
                }
                else return 0;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

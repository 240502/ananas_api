using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using System.Data;
namespace DataAccessLayer
{
    public class ProductPriceDAL
    {
        DataHelper helper = new DataHelper();
        public int Create(ProductPriceModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateProductPrice", "@productId", "@price", "@start_date","@end_date", model.product_id, model.price, model.start_date, model.end_date);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductPriceModel getPriceByProId(int proId)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetPriceByProId", "@proId",proId);
                if (tb != null)
                {
                    ProductPriceModel price = new ProductPriceModel();
                    price.id = int.Parse(tb.Rows[0]["id"].ToString());
                    price.product_id = int.Parse(tb.Rows[0]["product_id"].ToString());
                    price.start_date = DateTime.Parse(tb.Rows[0]["start_date"].ToString());
                    price.end_date = DateTime.Parse(tb.Rows[0]["end_date"].ToString());
                    price.created_at = DateTime.Parse(tb.Rows[0]["create_at"].ToString());
                    price.updated_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["create_at"].ToString()) : DateTime.MinValue;
                    price.price = int.Parse(tb.Rows[0]["price"].ToString());

                    return price;
                }
                else return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

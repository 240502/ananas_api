using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using System.Data;
using System.ComponentModel;
namespace DataAccessLayer
{
    public class ProductDetailDAL
    {
        DataHelper helper = new DataHelper();

        public int Create(ProductDetailModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateProductDetail","@quantity","@pro_id","@size",model.quantity,model.product_id,model.size);
                return result;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductDetailModel>getByProId(int proId)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetProductDetailByProId","@proId",proId);
                if (tb != null)
                {
                    List<ProductDetailModel> list = new List<ProductDetailModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductDetailModel detail = new ProductDetailModel();
                        detail.id = int.Parse(tb.Rows[i]["id"].ToString());
                        detail.quantity = int.Parse(tb.Rows[i]["quantity"].ToString());
                        detail.product_id = int.Parse(tb.Rows[i]["pro_id"].ToString());
                        detail.size = int.Parse(tb.Rows[i]["size"].ToString());
                        list.Add(detail);
                    }
                   
                    return list;
                }
                else return null;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDetailModel getByProIdAndSize(int proId,int size) {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetQuantityProductByProIdAndSize","@proId","@size",proId,size);
                if (tb != null)
                {
                    ProductDetailModel detail = new ProductDetailModel();
                    detail.id = int.Parse(tb.Rows[0]["id"].ToString());
                    detail.quantity = int.Parse(tb.Rows[0]["quantity"].ToString());
                    detail.product_id = int.Parse(tb.Rows[0]["pro_id"].ToString());
                    detail.size = int.Parse(tb.Rows[0]["size"].ToString());
                    return detail;
                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}

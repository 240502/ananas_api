using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using System.Data;
using Microsoft.VisualBasic;
namespace DataAccessLayer
{
    public class ProductStatusDAL
    {
        DataHelper helper = new DataHelper();
        public ProductStatusModel getById(int id) 
        {
            try
            {

                DataTable tb = helper.ExcuteReader("Pro_GetProductStatusById", "@statusId", id);
                if (tb != null)
                {
                    ProductStatusModel model = new ProductStatusModel();
                    model.id = int.Parse(tb.Rows[0]["id"].ToString());
                    model.status_name = tb.Rows[0]["status_name"].ToString();
                    model.created_at = DateTime.Parse(tb.Rows[0]["create_at"].ToString());
                    model.updated_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    return model;
                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ProductStatusModel> getAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllProductStatus");
                if (tb != null)
                {
                    List<ProductStatusModel> list = new List<ProductStatusModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductStatusModel model = new ProductStatusModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.status_name = tb.Rows[i]["status_name"].ToString();
                        model.created_at = DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                        model.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        list.Add(model);
                    }
                    return list;
                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

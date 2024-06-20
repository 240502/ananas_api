using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helper;
using Model;
namespace DataAccessLayer
{
    public class ShippingTypeDAL
    {
        DataHelper helper = new DataHelper();

        public ShippingTypeModel getById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetShippingTypeById","@id",id);
                if (tb != null)
                {
                    ShippingTypeModel model = new ShippingTypeModel();
                    model.id = int.Parse(tb.Rows[0]["id"].ToString());
                    model.shippingType_name = tb.Rows[0]["shippingType_name"].ToString();
                    model.create_at = tb.Rows[0]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["create_at"].ToString()) : DateTime.MinValue;
                    model.update_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    model.price = int.Parse(tb.Rows[0]["price"].ToString());
                    return model;
                }
                else return null;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public List<ShippingTypeModel> getList()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllShippingType");
                if (tb != null)
                {
                    List<ShippingTypeModel> list = new List<ShippingTypeModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ShippingTypeModel model = new ShippingTypeModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.shippingType_name = tb.Rows[i]["shippingType_name"].ToString();
                        model.create_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        model.update_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        model.price = int.Parse(tb.Rows[i]["price"].ToString());
                        list.Add(model);
                    }
                    return list;
                }
                else return null;

            }catch (Exception ex)
            {
                return null;
            }
        }
    }
}

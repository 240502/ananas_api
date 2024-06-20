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
    public class PaymentTypeDAL
    {
        DataHelper helper = new DataHelper();
        public List<PaymentTypeModel> getList()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllPaymentType");
                if (tb != null)
                {
                    List<PaymentTypeModel> list = new List<PaymentTypeModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        PaymentTypeModel model = new PaymentTypeModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.create_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        model.update_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        model.thumbnail = tb.Rows[i]["thumbnail"].ToString();
                        model.paymentType_name = tb.Rows[i]["paymentType_name"].ToString();
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

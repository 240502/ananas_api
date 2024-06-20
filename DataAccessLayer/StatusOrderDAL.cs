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
    public class StatusOrderDAL
    {
        DataHelper helper = new DataHelper();
        public List<StatusOrderModel> getList()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllStatusOrder");
                if (tb != null)
                {
                    List<StatusOrderModel> list = new List<StatusOrderModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        StatusOrderModel model = new StatusOrderModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.status_name = tb.Rows[i]["status_name"].ToString();
                        list.Add(model);

                    }
                    return list;
                }
                else return null;
            }
            catch(Exception ex) {
                throw ex;
            }
        }
    }
}

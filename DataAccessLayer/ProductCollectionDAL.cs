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
    public class ProductCollectionDAL
    {
        DataHelper helper = new DataHelper();
        List<ProductCollectionModel> proCollects;

        public List<ProductCollectionModel> getAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllCollection");
                if (tb != null)
                {
                    proCollects = new List<ProductCollectionModel>(); 
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductCollectionModel model = new ProductCollectionModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.collection_name = tb.Rows[i]["collection_name"].ToString();
                        model.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        model.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        proCollects.Add(model);
                    }
                    return proCollects;
                }
                else return null;
                
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

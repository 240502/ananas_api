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
    public class MaterialDAL
    {
        DataHelper helper = new DataHelper();
        List<MaterialModel> materials;
        public List<MaterialModel> GetAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllMaterial");
                if (tb != null)
                {
                    materials = new List<MaterialModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        MaterialModel material = new MaterialModel();
                        material.id = int.Parse(tb.Rows[i]["id"].ToString());
                        material.material_name = tb.Rows[i]["material_name"].ToString();
                        material.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        material.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;

                        materials.Add(material);
                    }
                    return materials;
                }
                else return null;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

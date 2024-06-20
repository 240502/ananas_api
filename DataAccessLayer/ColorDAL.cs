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
    public class ColorDAL
    {
        List<ColorModel> colors;
        DataHelper helper = new DataHelper();

        public ColorModel getById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetColorById", "@id", id);
                if (tb != null)
                {
                    ColorModel color = new ColorModel();
                    color.id = int.Parse(tb.Rows[0]["id"].ToString());
                    color.color_code = tb.Rows[0]["color_code"].ToString();
                    color.color_name = tb.Rows[0]["color_name"].ToString();
                    color.updated_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    color.created_at = tb.Rows[0]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["create_at"].ToString()) : DateTime.MinValue;
                    return color;
                }
                else return null;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ColorModel> GetAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllColor");
                if(tb != null)
                {
                    colors = new List<ColorModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ColorModel color = new ColorModel();
                        color.id = int.Parse(tb.Rows[i]["id"].ToString());
                        color.color_code = tb.Rows[i]["color_code"].ToString();
                        color.color_name = tb.Rows[i]["color_name"].ToString();
                        color.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()):DateTime.MinValue;
                        color.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        colors.Add(color);
                    }
                    return colors;
                }
                return null;

            }catch(Exception ex) {
                throw ex;
            }
        }
    }
}

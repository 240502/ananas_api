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

    public class StyleDAL
    {
        DataHelper helper = new DataHelper();
        public StyleModel getById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetStyleById", "@id", id);
                if (tb != null)
                {
                    StyleModel model = new StyleModel();
                    model.id = int.Parse(tb.Rows[0]["id"].ToString());
                    model.name_style = tb.Rows[0]["name_style"].ToString();
                    model.created_at = tb.Rows[0]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["create_at"].ToString()) : DateTime.MinValue;
                    model.updated_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    return model;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<StyleModel> GetAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllStyle");
                if (tb != null)
                { 
                    List<StyleModel> list = new List<StyleModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        StyleModel model = new StyleModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.name_style = tb.Rows[i]["name_style"].ToString();
                        model.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        model.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        list.Add(model);
                    }
                    return list;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<StyleModel> getShowMenu()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetStyleShowMenu");
                if (tb != null)
                {
                    List<StyleModel> list = new List<StyleModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        StyleModel model = new StyleModel();
                        model.id = int.Parse(tb.Rows[i]["id"].ToString());
                        model.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        model.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        model.name_style = tb.Rows[i]["name_style"].ToString();

                        list.Add(model);
                    }
                    return list;
                }
                else return null;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

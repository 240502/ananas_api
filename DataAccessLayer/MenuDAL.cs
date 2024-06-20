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
    public class MenuDAL
    {
        DataHelper helper = new DataHelper();
        List<MenuModel> menus;
        public List<MenuModel> GetAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllMenu");
                if (tb != null)
                {
                    menus = new List<MenuModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        MenuModel menu = new MenuModel();
                        menu.id = int.Parse(tb.Rows[i]["id"].ToString());
                        menu.menu_name = tb.Rows[i]["menu_name"].ToString();
                        menu.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        menu.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        menu.url = tb.Rows[i]["url"].ToString();

                        menus.Add(menu);
                    }
                    return menus;
                }
                else return null;
            }catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

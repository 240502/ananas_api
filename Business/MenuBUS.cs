using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace Business
{
    public class MenuBUS
    {
        List<MenuModel> menus;
        MenuDAL menuDAL = new MenuDAL();
        public List<MenuModel> getAll()
        {
            return menuDAL.GetAll();
        }
    }
}

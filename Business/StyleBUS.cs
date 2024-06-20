using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
namespace Business
{
    public class StyleBUS
    {
        StyleDAL styleDAL = new StyleDAL();
        public List<StyleModel> getShowMenu()
        {
            return styleDAL.getShowMenu();
        }
        public StyleModel getById(int id)
        {
            return styleDAL.getById(id);
        } 
        public List<StyleModel> getAll() {
            return styleDAL.GetAll();
                }
    }
}

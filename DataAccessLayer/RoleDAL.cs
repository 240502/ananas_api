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
    public class RoleDAL
    {
        DataHelper helper = new DataHelper();
        public RoleModel getById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetRoleById", "@id", id);
                if (tb != null)
                {
                    RoleModel role = new RoleModel();
                    role.id = int.Parse(tb.Rows[0]["id"].ToString());
                    role.role_name = tb.Rows[0]["role_name"].ToString();
                    return role;
                }
                else return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoleBUS
    {
        RoleDAL roleDAL = new RoleDAL();
        public RoleModel getById(int id)
        {
            return roleDAL.getById(id);
        }
    }
}

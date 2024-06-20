using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MaterialBUS
    {
        MaterialDAL materialDAL = new MaterialDAL();
        public List<MaterialModel> getAll()
        {
            return materialDAL.GetAll();
        }
    }
}

using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ShippingTypeBUS
    {
        ShippingTypeDAL typeDAL = new ShippingTypeDAL();
        public List<ShippingTypeModel> getList()
        {
            return typeDAL.getList();
        }
        public ShippingTypeModel getById(int id)
        {
            return typeDAL.getById(id);
        }
    }
}

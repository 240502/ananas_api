using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class PaymentTypeBUS
    {
        PaymentTypeDAL typeDAL = new PaymentTypeDAL();
        public List<PaymentTypeModel> getList()
        {
            return typeDAL.getList();
        }
    }
}

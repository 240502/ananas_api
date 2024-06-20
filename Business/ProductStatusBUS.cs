using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using Model;
namespace Business
{
    public  class ProductStatusBUS
    {
        ProductStatusDAL productStatusDAL = new ProductStatusDAL();
        public ProductStatusModel getById(int id)
        {
            return productStatusDAL.getById(id);
        }

        public List<ProductStatusModel>getAll()
        {
            return productStatusDAL.getAll();
        }
    }
}

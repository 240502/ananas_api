using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductCollectionBUS
    {
        ProductCollectionDAL collectionDAL = new ProductCollectionDAL();
        public List<ProductCollectionModel> getAll()
        {
            return collectionDAL.getAll();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace Business
{
    public class ProductPriceBUS
    {
        ProductPriceDAL priceDAL = new ProductPriceDAL();
        public ProductPriceModel getByProId(int proId)
        {
            return priceDAL.getPriceByProId(proId);
        }
        public int Create(ProductPriceModel model)
        {
            return priceDAL.Create(model);
        }
    }
}

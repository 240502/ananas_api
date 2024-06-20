using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductViewsBUS
    {
        ProductViewsDAL productViewsDAL = new ProductViewsDAL();
        public int Create(ProductViewsModel model)
        {
            return productViewsDAL.Create(model);
        }    
        public int GetTotalView()
        {
            return productViewsDAL.GetTotalView();
        }
    }
}

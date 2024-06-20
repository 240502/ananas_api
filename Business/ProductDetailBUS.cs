using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Business;
using DataAccessLayer;
namespace Business
{
    public class ProductDetailBUS
    {
        ProductDetailDAL detailDAL = new ProductDetailDAL();
        public List<ProductDetailModel> getByProId(int proId)
        {
            return detailDAL.getByProId(proId);
        }
        public ProductDetailModel getByProIdAndSize(int proId, int size)
        {
            return detailDAL.getByProIdAndSize(proId, size);
        }
        public int Create(ProductDetailModel model)
        {
            return detailDAL.Create(model);
        }
    }
}

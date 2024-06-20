using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;
namespace Business
{
    public class ProductCategoryBUS
    {
        ProductCategoryDAL cateDAL = new ProductCategoryDAL();
        public int Create(ProductCategoryModel model)
        {
            return cateDAL.Create(model);
        }

        public int Delete (int id)
        {
            return cateDAL.Delete(id);

        }
        public int Update(ProductCategoryModel model)
        {
            return cateDAL.Update(model);
        }
        public List<ProductCategoryModel> getAll()
        {
            return cateDAL.getAll();
        }
        public ProductCategoryModel getById(int id)
        {
            return cateDAL.getById(id);
        }
        public List<ProductCategoryModel> getList(int pageIndex,int pageSize,out int total)
        {
            return cateDAL.getList(pageIndex,pageSize,out total);
        }
        public List<ProductCategoryModel> search(int pageIndex, int pageSize,string value, out int total)
        {
            return cateDAL.search(pageIndex, pageSize, value,out total);
        }
    }
}

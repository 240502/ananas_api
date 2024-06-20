using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using DataAccessLayer;
namespace Businesss
{
    public class ProductBUS
    {
        ProductDAL proDAL = new ProductDAL();

        public int Create(ProductModel product)
        {
            return proDAL.Create(product);
        }
        public int Update(ProductModel product)
        {
            return proDAL.Update(product);
        }
        public int Delete(int id)
        {
            return proDAL.Delete(id);

        }
        public List<ProductStatistics> GetTop5ProductBestSale(int month, int year)
        {
            return proDAL.GetTop5ProductBestSale(month,year);
        }

        public List<ProductStatistics> GetTop5ProductBestView(int month, int year)
        {
            return proDAL.GetTop5ProductBestView(month, year);
        }
        public ProductModel GetById(int id)
        {
            return proDAL.GetById(id);
        }
        public List<ProductModel> GetByCateId(int id)
        {
            return proDAL.GetByCateId(id);
        }
        public List<ProductModel> Search(int? pageIndex, int? pageSize, string value, out int total)
        {
            return proDAL.Search(pageIndex,pageSize,value,out total);
        }
        public List<ProductModel> GetList(int? pageIndex, int? pageSize, string gender, int cate ,int startPrice,int endPrice,out int total)
        {
            return proDAL.GetList(pageIndex,pageSize,gender,cate ,startPrice,endPrice, out total);
        }
        public List<ProductModel> getRelatedProduct(int? cateId,int? collectionId, int? styleId, string? gender,int id)
        {
            return proDAL.getRelatedProduct(cateId,collectionId,styleId,gender,id);
        }
    }
}

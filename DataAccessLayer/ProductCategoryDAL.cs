using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using System.Data;

namespace DataAccessLayer
{
    public class ProductCategoryDAL
    {
        DataHelper helper = new DataHelper();
        List<ProductCategoryModel> productCategories;

        public int Create(ProductCategoryModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateCate","@cateName",model.cate_name);
                    return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        public int Update(ProductCategoryModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_UpdateCate", "@cateName", "@create_at", "@id", model.cate_name, model.created_at, model.id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Delete(int id)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_DeleteCate", "@id",id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductCategoryModel getById(int id)
        {
            try {

                DataTable tb = helper.ExcuteReader("Pro_GetCateById", "@id", id);
                if (tb != null)
                {
                    ProductCategoryModel proCate = new ProductCategoryModel();
                    proCate.id = int.Parse(tb.Rows[0]["id"].ToString());
                    proCate.cate_name = tb.Rows[0]["cate_name"].ToString();
                    proCate.created_at = tb.Rows[0]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["create_at"].ToString()) : DateTime.MinValue;
                    proCate.updated_at = tb.Rows[0]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[0]["update_at"].ToString()) : DateTime.MinValue;
                    return proCate;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductCategoryModel> getList(int pageIndex,int pageSize, out int total)
        {
            total = 0;
            
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetListCate","@pageIndex","@pageSize",pageIndex,pageSize);
                if (tb != null)
                {
                    productCategories = new List<ProductCategoryModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductCategoryModel proCate = new ProductCategoryModel();
                        proCate.id = int.Parse(tb.Rows[i]["id"].ToString());
                        proCate.cate_name = tb.Rows[i]["cate_name"].ToString();
                        proCate.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        proCate.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        productCategories.Add(proCate);
                    }
                    return productCategories;
                }
                else return null;
            }
            catch(Exception ex) {
                return null;
            }
        }

        public List<ProductCategoryModel> search(int pageIndex, int pageSize,string value, out int total)
        {
            total = 0;

            try
            {
                DataTable tb = helper.ExcuteReader("Pro_SearchCate", "@pageIndex", "@pageSize","@value", pageIndex, pageSize,value);
                if (tb != null)
                {
                    productCategories = new List<ProductCategoryModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductCategoryModel proCate = new ProductCategoryModel();
                        proCate.id = int.Parse(tb.Rows[i]["id"].ToString());
                        proCate.cate_name = tb.Rows[i]["cate_name"].ToString();
                        proCate.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        proCate.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        productCategories.Add(proCate);
                    }
                    return productCategories;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProductCategoryModel> getAll()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetAllCategory");
                if (tb != null)
                {
                    productCategories = new List<ProductCategoryModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductCategoryModel proCate = new ProductCategoryModel();
                        proCate.id = int.Parse(tb.Rows[i]["id"].ToString());
                        proCate.cate_name = tb.Rows[i]["cate_name"].ToString();
                        proCate.created_at = tb.Rows[i]["create_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["create_at"].ToString()) : DateTime.MinValue;
                        proCate.updated_at = tb.Rows[i]["update_at"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["update_at"].ToString()) : DateTime.MinValue;
                        productCategories.Add(proCate);
                    }
                    return productCategories;

                }   else return null;
            }catch(Exception ex) 
             
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer.Helper;
using System.Data;
using Microsoft.VisualBasic;
using System.Reflection;
using Newtonsoft.Json.Linq;
namespace DataAccessLayer
{

    public class ProductDAL
    {
        DataHelper helper = new DataHelper();
        List<ProductModel> product_list;
        public int Create(ProductModel product)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateProduct",
                                                    "@pro_name","@status_id", "@cate_id",
                                                    "@style_id", "@collection_id", "@material_id",
                                                    "@gender", "@out_sole","@color", "@productPrice", 
                                                    "@imageGallery", "@productDetail",
                                                    product.pro_name, 
                                                    product.status_id == 0 ? null : product.status_id, product.cate_id == 0 ? null : product.cate_id,
                                                    product.style_id == 0 ? null : product.style_id, product.collection_id == 0 ? null : product.collection_id, product.material_id == 0 ? null : product.material_id,
                                                    product.gender, product.out_sole,product.color_id == 0 ? null : product.color_id,
                                                    product.priceModel != null ? MessageConvert.SerializeObject(product.priceModel) : null,
                                                    product.imageGallery != null ? MessageConvert.SerializeObject(product.imageGallery) : null,
                                                    product.productDetails != null ? MessageConvert.SerializeObject(product.productDetails) : null


                                                    );
              
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Update(ProductModel product)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_UpdateProduct",
                                                    "@pro_name", "@create_at"
                                                    , "@status_id", "@cate_id", "@style_id", 
                                                    "@collection_id", "@material_id", "@gender",
                                                    "@out_sole", "@id", "@color", 
                                                    "@productPrice", "@imageGallery", "@productDetail",
                                                    product.pro_name, product.created_at,
                                                     product.status_id == 0 ? null : product.status_id, product.cate_id == 0 ? null : product.cate_id,
                                                    product.style_id == 0 ? null : product.style_id, product.collection_id == 0 ? null : product.collection_id, product.material_id == 0 ? null : product.material_id,
                                                    product.gender, product.out_sole, product.id,product.color_id == 0 ? null : product.color_id,
                                                    product.priceModel != null ? MessageConvert.SerializeObject(product.priceModel) : null,
                                                    product.imageGallery != null ? MessageConvert.SerializeObject(product.imageGallery) : null,
                                                    product.productDetails != null ? MessageConvert.SerializeObject(product.productDetails) : null
                                                    );
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
                int result = helper.ExcuteNonQuery("Pro_DeleteProduct",
                                                     "@id", id
                                                    );
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ProductModel> GetByCateId(int cateId)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetProductByCateId", "@cateId", cateId);
                if (tb != null)
                {
                    List<ProductModel> list = new List<ProductModel>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                            ProductModel product = new ProductModel();
                            product.priceModel = new ProductPriceModel();
                            product.imageGallery = new ImageGalleryModel();
                            product.productDetails = new List<ProductDetailModel>();
                            product.id = int.Parse(tb.Rows[i]["id"].ToString());
                            product.pro_name = tb.Rows[i]["pro_name"].ToString();
                            product.created_at = tb.Rows[i]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                            product.updated_at = tb.Rows[i]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["update_at"].ToString());
                            product.status_id = tb.Rows[i]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["status_id"].ToString());
                            product.cate_id = tb.Rows[i]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["cate_id"].ToString());
                            product.style_id = tb.Rows[i]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["style_id"].ToString());
                            product.collection_id = tb.Rows[i]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["collection_id"].ToString());
                            product.material_id = tb.Rows[i]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["material_id"].ToString());
                            product.gender = tb.Rows[i]["gender"] == DBNull.Value ? "" : tb.Rows[i]["gender"].ToString();
                            product.out_sole = tb.Rows[i]["out_sole"] == DBNull.Value ? "" : tb.Rows[i]["out_sole"].ToString();
                            product.color_id = tb.Rows[i]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["color_id"].ToString());

                            product.priceModel.id = int.Parse(tb.Rows[i]["price_id"].ToString());
                            product.priceModel.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                            product.priceModel.price = int.Parse(tb.Rows[i]["price"].ToString());
                            product.priceModel.start_date = tb.Rows[i]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["start_date"].ToString());
                            product.priceModel.end_date = tb.Rows[i]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["end_date"].ToString());
                            product.priceModel.created_at = tb.Rows[i]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_create_at"].ToString());
                            product.priceModel.updated_at = tb.Rows[i]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_update_at"].ToString());

                            product.imageGallery.id = int.Parse(tb.Rows[i]["image_id"].ToString());
                            product.imageGallery.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                            product.imageGallery.img_src = tb.Rows[i]["img_src"].ToString();
                            product.imageGallery.feature = tb.Rows[i]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[i]["feature"].ToString()) : false;
                      
                        list.Add(product);
                    
                    }
                  


                   
                    return list;
                }
                else return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public ProductModel GetById(int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetProById", "@id", id);
                if (tb != null)
                {
                    ProductModel product = new ProductModel();
                    product.priceModel = new ProductPriceModel();
                    product.imageGallery = new ImageGalleryModel();
                    product.productDetails = new List<ProductDetailModel>();
                    product.id = int.Parse(tb.Rows[0]["id"].ToString());
                    product.pro_name = tb.Rows[0]["pro_name"].ToString();
                    product.created_at = tb.Rows[0]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[0]["create_at"].ToString());
                    product.updated_at = tb.Rows[0]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[0]["update_at"].ToString());
                    product.status_id = tb.Rows[0]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[0]["status_id"].ToString());
                    product.cate_id = tb.Rows[0]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[0]["cate_id"].ToString());
                    product.style_id = tb.Rows[0]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[0]["style_id"].ToString());
                    product.collection_id = tb.Rows[0]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[0]["collection_id"].ToString());
                    product.material_id = tb.Rows[0]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[0]["material_id"].ToString());
                    product.gender = tb.Rows[0]["gender"] == DBNull.Value ? "" : tb.Rows[0]["gender"].ToString();
                    product.out_sole = tb.Rows[0]["out_sole"] == DBNull.Value ? "" : tb.Rows[0]["out_sole"].ToString();
                    product.color_id = tb.Rows[0]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[0]["color_id"].ToString());

                    product.priceModel.id = int.Parse(tb.Rows[0]["price_id"].ToString());
                    product.priceModel.product_id = int.Parse(tb.Rows[0]["id"].ToString());
                    product.priceModel.price = int.Parse(tb.Rows[0]["price"].ToString());
                    product.priceModel.start_date = tb.Rows[0]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[0]["start_date"].ToString());
                    product.priceModel.end_date = tb.Rows[0]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[0]["end_date"].ToString());
                    product.priceModel.created_at = tb.Rows[0]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[0]["price_create_at"].ToString());
                    product.priceModel.updated_at = tb.Rows[0]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[0]["price_update_at"].ToString());

                    product.imageGallery.id = int.Parse(tb.Rows[0]["image_id"].ToString());
                    product.imageGallery.product_id = int.Parse(tb.Rows[0]["id"].ToString());
                    product.imageGallery.img_src = tb.Rows[0]["img_src"].ToString();
                    product.imageGallery.feature = tb.Rows[0]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()) : false;


                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductDetailModel model = new ProductDetailModel();
                        model.id = int.Parse(tb.Rows[i]["productDetail_id"].ToString());
                        model.product_id = int.Parse(tb.Rows[0]["id"].ToString());
                        model.quantity = int.Parse(tb.Rows[i]["quantity"].ToString());
                        model.size = int.Parse(tb.Rows[i]["size"].ToString());
                        product.productDetails.Add(model);
                    }
                    return product;
                }
                else return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProductStatistics> GetTop5ProductBestSale(int month, int year)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetTop5ProductBestSale", "@month","@year", month,year);
                if (tb != null)
                {
                    List<ProductStatistics> list = new List<ProductStatistics>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductStatistics product = new ProductStatistics();
                        product.priceModel = new ProductPriceModel();
                        product.imageGallery = new ImageGalleryModel();
                        product.id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.pro_name = tb.Rows[i]["pro_name"].ToString();
                        product.created_at = tb.Rows[i]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                        product.updated_at = tb.Rows[i]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["update_at"].ToString());
                        product.status_id = tb.Rows[i]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["status_id"].ToString());
                        product.cate_id = tb.Rows[i]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["cate_id"].ToString());
                        product.style_id = tb.Rows[i]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["style_id"].ToString());
                        product.collection_id = tb.Rows[i]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["collection_id"].ToString());
                        product.material_id = tb.Rows[i]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["material_id"].ToString());
                        product.gender = tb.Rows[i]["gender"] == DBNull.Value ? "" : tb.Rows[0]["gender"].ToString();
                        product.out_sole = tb.Rows[i]["out_sole"] == DBNull.Value ? "" : tb.Rows[i]["out_sole"].ToString();
                        product.color_id = tb.Rows[i]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["color_id"].ToString());

                        product.priceModel.id = int.Parse(tb.Rows[i]["price_id"].ToString());
                        product.priceModel.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.priceModel.price = int.Parse(tb.Rows[i]["price"].ToString());
                        product.priceModel.start_date = tb.Rows[i]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["start_date"].ToString());
                        product.priceModel.end_date = tb.Rows[i]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["end_date"].ToString());
                        product.priceModel.created_at = tb.Rows[i]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_create_at"].ToString());
                        product.priceModel.updated_at = tb.Rows[i]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_update_at"].ToString());



                        product.imageGallery.id = int.Parse(tb.Rows[i]["image_id"].ToString());
                        product.imageGallery.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.imageGallery.img_src = tb.Rows[i]["img_src"].ToString();
                        product.imageGallery.feature = tb.Rows[i]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()) : false;
                        product.amountOfSale = tb.Rows[i]["amountOfSale"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["amountOfSale"].ToString());
                        list.Add(product);
                    }
                    return list;
                }
                else return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<ProductStatistics> GetTop5ProductBestView(int month, int year)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetTop5ProductBestView", "@month", "@year", month, year);
                if (tb != null)
                {
                    List<ProductStatistics> list = new List<ProductStatistics>();
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductStatistics product = new ProductStatistics();
                        product.priceModel = new ProductPriceModel();
                        product.imageGallery = new ImageGalleryModel();
                        product.id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.pro_name = tb.Rows[i]["pro_name"].ToString();
                        product.created_at = tb.Rows[i]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                        product.updated_at = tb.Rows[i]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["update_at"].ToString());
                        product.status_id = tb.Rows[i]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["status_id"].ToString());
                        product.cate_id = tb.Rows[i]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["cate_id"].ToString());
                        product.style_id = tb.Rows[i]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["style_id"].ToString());
                        product.collection_id = tb.Rows[i]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["collection_id"].ToString());
                        product.material_id = tb.Rows[i]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["material_id"].ToString());
                        product.gender = tb.Rows[i]["gender"] == DBNull.Value ? "" : tb.Rows[0]["gender"].ToString();
                        product.out_sole = tb.Rows[i]["out_sole"] == DBNull.Value ? "" : tb.Rows[i]["out_sole"].ToString();
                        product.color_id = tb.Rows[i]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["color_id"].ToString());

                        product.priceModel.id = int.Parse(tb.Rows[i]["price_id"].ToString());
                        product.priceModel.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.priceModel.price = int.Parse(tb.Rows[i]["price"].ToString());
                        product.priceModel.start_date = tb.Rows[i]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["start_date"].ToString());
                        product.priceModel.end_date = tb.Rows[i]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["end_date"].ToString());
                        product.priceModel.created_at = tb.Rows[i]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_create_at"].ToString());
                        product.priceModel.updated_at = tb.Rows[i]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_update_at"].ToString());



                        product.imageGallery.id = int.Parse(tb.Rows[i]["image_id"].ToString());
                        product.imageGallery.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.imageGallery.img_src = tb.Rows[i]["img_src"].ToString();
                        product.imageGallery.feature = tb.Rows[i]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()) : false;
                        product.amount_view = tb.Rows[i]["amount_view"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["amount_view"].ToString());
                        list.Add(product);
                    }
                    return list;
                }
                else return null;

            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }

        public List<ProductModel> getRelatedProduct(int? cateId, int? collectionId, int? styleId, string? gender,int id)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_RelatedProduct","@cateId","@collectionId","@styleId","@gender","@id",cateId,collectionId,styleId,gender,id);
                if (tb != null)
                {
                    product_list = new List<ProductModel>();

                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductModel product = new ProductModel();
                        product.priceModel = new ProductPriceModel();
                        product.imageGallery = new ImageGalleryModel();
                        product.id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.pro_name = tb.Rows[i]["pro_name"].ToString();
                        product.created_at = tb.Rows[i]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                        product.updated_at = tb.Rows[i]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["update_at"].ToString());
                        product.status_id = tb.Rows[i]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["status_id"].ToString());
                        product.cate_id = tb.Rows[i]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["cate_id"].ToString());
                        product.style_id = tb.Rows[i]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["style_id"].ToString());
                        product.collection_id = tb.Rows[i]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["collection_id"].ToString());
                        product.material_id = tb.Rows[i]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["material_id"].ToString());
                        product.gender = tb.Rows[i]["gender"] == DBNull.Value ? "" : tb.Rows[i]["gender"].ToString();
                        product.out_sole = tb.Rows[i]["out_sole"] == DBNull.Value ? "" : tb.Rows[i]["out_sole"].ToString();
                        product.color_id = tb.Rows[i]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["color_id"].ToString());

                        product.priceModel.id = int.Parse(tb.Rows[i]["price_id"].ToString());
                        product.priceModel.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.priceModel.price = int.Parse(tb.Rows[i]["price"].ToString());
                        product.priceModel.start_date = tb.Rows[i]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["start_date"].ToString());
                        product.priceModel.end_date = tb.Rows[i]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["end_date"].ToString());
                        product.priceModel.created_at = tb.Rows[i]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_create_at"].ToString());
                        product.priceModel.updated_at = tb.Rows[i]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_update_at"].ToString());



                        product.imageGallery.id = int.Parse(tb.Rows[i]["image_id"].ToString());
                        product.imageGallery.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.imageGallery.img_src = tb.Rows[i]["img_src"].ToString();
                        product.imageGallery.feature = tb.Rows[i]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()) : false;
                        product_list.Add(product);

                    }
                    return product_list;
                }
                else return null;
            }catch(Exception ex)
            {
                return null;
            }

        }
      
        public List<ProductModel> GetList(int ? pageIndex, int? pageSize, string gender,int cate,int startPrice,int endPrice,out int total)
        {
            total = 0;
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetListProduct","@pageIndex","@pageSize","@gender","@cate","@startPrice","@endPrice",pageIndex,pageSize,gender,cate, startPrice,endPrice);

                if(tb != null)
                {
                    product_list = new List<ProductModel>();

                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                                ProductModel product = new ProductModel();
                                product.priceModel = new ProductPriceModel();
                                product.imageGallery = new ImageGalleryModel();
                                product.id = int.Parse(tb.Rows[i]["id"].ToString());
                                product.pro_name = tb.Rows[i]["pro_name"].ToString();
                                product.created_at = tb.Rows[i]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                                product.updated_at = tb.Rows[i]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["update_at"].ToString());
                                product.status_id = tb.Rows[i]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["status_id"].ToString());
                                product.cate_id = tb.Rows[i]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["cate_id"].ToString());
                                product.style_id = tb.Rows[i]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["style_id"].ToString());
                                product.collection_id = tb.Rows[i]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["collection_id"].ToString());
                                product.material_id = tb.Rows[i]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["material_id"].ToString());
                                product.gender = tb.Rows[i]["gender"] == DBNull.Value ? "" : tb.Rows[0]["gender"].ToString();
                                product.out_sole = tb.Rows[i]["out_sole"] == DBNull.Value ? "" : tb.Rows[i]["out_sole"].ToString();
                                product.color_id = tb.Rows[i]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["color_id"].ToString());

                                product.priceModel.id = int.Parse(tb.Rows[i]["price_id"].ToString());
                                product.priceModel.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                                product.priceModel.price = int.Parse(tb.Rows[i]["price"].ToString());
                                product.priceModel.start_date = tb.Rows[i]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["start_date"].ToString());
                                product.priceModel.end_date = tb.Rows[i]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["end_date"].ToString());
                                product.priceModel.created_at = tb.Rows[i]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_create_at"].ToString());
                                product.priceModel.updated_at = tb.Rows[i]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_update_at"].ToString());



                                product.imageGallery.id = int.Parse(tb.Rows[i]["image_id"].ToString());
                                product.imageGallery.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                                product.imageGallery.img_src = tb.Rows[i]["img_src"].ToString();
                                product.imageGallery.feature = tb.Rows[i]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()) : false;
                                product_list.Add(product);
                       

                     

                    }
                    return product_list;
                }
                else return null;


            }

            catch (Exception ex)
            {
                return null;
            }
        }
        public List<ProductModel> Search(int? pageIndex, int? pageSize, string value, out int total)
        {
            total = 0;
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_SearchProduct","@pageIndex","@pageSize","@value",pageIndex,pageSize,value);
                if (tb != null)
                {
                    product_list = new List<ProductModel>();
                    total = int.Parse(tb.Rows[0]["RecordCount"].ToString());
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        ProductModel product = new ProductModel();
                        product.priceModel = new ProductPriceModel();
                        product.imageGallery = new ImageGalleryModel();
                        product.id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.pro_name = tb.Rows[i]["pro_name"].ToString();
                        product.created_at = tb.Rows[i]["create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["create_at"].ToString());
                        product.updated_at = tb.Rows[i]["update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["update_at"].ToString());
                        product.status_id = tb.Rows[i]["status_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["status_id"].ToString());
                        product.cate_id = tb.Rows[i]["cate_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["cate_id"].ToString());
                        product.style_id = tb.Rows[i]["style_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["style_id"].ToString());
                        product.collection_id = tb.Rows[i]["collection_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["collection_id"].ToString());
                        product.material_id = tb.Rows[i]["material_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["material_id"].ToString());
                        product.gender = tb.Rows[i]["gender"] == DBNull.Value ? "" : tb.Rows[0]["gender"].ToString();
                        product.out_sole = tb.Rows[i]["out_sole"] == DBNull.Value ? "" : tb.Rows[i]["out_sole"].ToString();
                        product.color_id = tb.Rows[i]["color_id"] == DBNull.Value ? 0 : int.Parse(tb.Rows[i]["color_id"].ToString());

                        product.priceModel.id = int.Parse(tb.Rows[i]["price_id"].ToString());
                        product.priceModel.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.priceModel.price = int.Parse(tb.Rows[i]["price"].ToString());
                        product.priceModel.start_date = tb.Rows[i]["start_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["start_date"].ToString());
                        product.priceModel.end_date = tb.Rows[i]["end_date"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["end_date"].ToString());
                        product.priceModel.created_at = tb.Rows[i]["price_create_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_create_at"].ToString());
                        product.priceModel.updated_at = tb.Rows[i]["price_update_at"] == DBNull.Value ? DateTime.MinValue : DateTime.Parse(tb.Rows[i]["price_update_at"].ToString());



                        product.imageGallery.id = int.Parse(tb.Rows[i]["image_id"].ToString());
                        product.imageGallery.product_id = int.Parse(tb.Rows[i]["id"].ToString());
                        product.imageGallery.img_src = tb.Rows[i]["img_src"].ToString();
                        product.imageGallery.feature = tb.Rows[i]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()) : false;

                        product_list.Add(product);
                    }
                    return product_list;
                }
                else return null;
    
        }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}

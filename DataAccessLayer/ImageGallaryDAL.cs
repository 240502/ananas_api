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
    public  class ImageGallaryDAL
    {
        DataHelper helper = new DataHelper();
        public ImageGalleryModel getFeatureImgByProductId(int proId)
        {
            try
            {
                DataTable tb = helper.ExcuteReader("Pro_GetFeatureImgByProId", "@proId", proId);
                if (tb != null)
                {
                    ImageGalleryModel model = new ImageGalleryModel();
                    model.id = int.Parse(tb.Rows[0]["id"].ToString());
                    model.img_src = tb.Rows[0]["img_src"] != DBNull.Value ? tb.Rows[0]["img_src"].ToString():"";
                    model.product_id = int.Parse(tb.Rows[0]["product_id"].ToString());
                    model.feature = tb.Rows[0]["feature"] != DBNull.Value ? bool.Parse(tb.Rows[0]["feature"].ToString()):false;
                    return model;
                }
                else return null;
            }catch(Exception ex) 
            {
                throw ex;
            }
        }
        public int Create(ImageGalleryModel model)
        {
            try
            {
                int result = helper.ExcuteNonQuery("Pro_CreateImage", "@imgSrc", "@productId", model.img_src, model.product_id);
                return result;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

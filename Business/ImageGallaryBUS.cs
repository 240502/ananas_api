using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ImageGallaryBUS
    {
        ImageGallaryDAL imgDAL = new ImageGallaryDAL();
        public ImageGalleryModel getImgFeatureByProId(int proId)
        {
            return imgDAL.getFeatureImgByProductId(proId);
        }
        public int Create(ImageGalleryModel model)
        {   
            return imgDAL.Create(model);
        }
    }
}

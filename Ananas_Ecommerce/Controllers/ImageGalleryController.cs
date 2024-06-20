using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageGalleryController : ControllerBase
    {
        ImageGallaryBUS imgBUS = new ImageGallaryBUS();

        [Route("getImageFeatureByProId")]
        [HttpGet]
        public IActionResult getImageFeatureByProId(int proId)
        {
            try
            {
                ImageGalleryModel model = imgBUS.getImgFeatureByProId(proId);
                return model != null ? Ok(model) : NotFound();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

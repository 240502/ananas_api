using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        ProductDetailBUS productDetailBUS = new ProductDetailBUS(); 
        [Route("getByProId")]
        [HttpGet]
        public IActionResult getByProId(int id)
        {
            try
            {
                List<ProductDetailModel> model = productDetailBUS.getByProId(id);
                return model != null ? Ok(model) : NotFound();

            }catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        [Route("getByProIdAndSize")]
        [HttpGet]
        public IActionResult getByProIdAndSize(int id,int size) {
            try
            {
                ProductDetailModel model = productDetailBUS.getByProIdAndSize(id,size);
                return model != null ? Ok(model) : NotFound();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

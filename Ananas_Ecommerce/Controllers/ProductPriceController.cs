using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Business;
namespace API_Ananas_Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        ProductPriceBUS priceBUS  = new ProductPriceBUS();
        [Route("getPriceByProId")]
        [HttpGet]
        public IActionResult getPriceByProId(int proId)
        {
            try
            {
                ProductPriceModel model = priceBUS.getByProId(proId);
                return model != null ? Ok(model) : NotFound();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

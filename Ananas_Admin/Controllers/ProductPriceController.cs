using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        ProductPriceBUS priceBUS = new ProductPriceBUS();
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] ProductPriceModel price)
        {
            try
            {
                int result = priceBUS.Create(price);
                return result >= 1 ? Ok("Thêm thành công !") : BadRequest("Thêm thất bại !");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

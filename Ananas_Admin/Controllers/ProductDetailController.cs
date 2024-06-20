using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        ProductDetailBUS detailBUS = new ProductDetailBUS();
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] ProductDetailModel model)
        {
            try
            {
                int result = detailBUS.Create(model);
                return result >= 1? Ok("Thêm thành công !"):BadRequest("Thêm thất bại !");
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

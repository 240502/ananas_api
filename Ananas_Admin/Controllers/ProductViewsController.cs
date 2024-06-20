using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductViewsController : ControllerBase
    {
        ProductViewsBUS viewsBUS = new ProductViewsBUS();
        [Route("create")]
        [HttpPost]

        public IActionResult Create([FromBody] ProductViewsModel model)
        {
            try
            {
                int result = viewsBUS.Create(model);
                return result >= 1 ? Ok("Thêm thành công !") : BadRequest("Thêm thất bại !");


            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [Route("getTotalView")]
        [HttpGet]
        public IActionResult GetTotalView()
        {
            try
            {
                int result = viewsBUS.GetTotalView();
                return Ok(result);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

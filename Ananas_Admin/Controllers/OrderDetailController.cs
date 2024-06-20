using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class OrderDetailController : ControllerBase
    {
        OrderDetailBUS detailBUS = new OrderDetailBUS();
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] OrderDetailModel model)
        {
            try
            {
                int result = detailBUS.Create(model);
                return result >= 1 ? Ok("Thêm thành công !") : BadRequest("Thêm thất bại !");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Route("update")]
        [HttpPost]
        public IActionResult Update([FromBody] OrderDetailModel model)
        {
            try
            {
                int result = detailBUS.Update(model);
                return result >= 1 ? Ok("Sửa thành công !") : BadRequest("Sửa thất bại !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Route("delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                int result = detailBUS.Delete(id);
                return result >= 1 ? Ok("Xóa thành công !") : BadRequest("Xóa thất bại !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}

using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API_Ananas_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusOrderController : ControllerBase
    {
        StatusOrderBUS statusOrderBUS = new StatusOrderBUS();
        [Route("getAll")]
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                List<StatusOrderModel> list = statusOrderBUS.getAll();
                return list != null ? Ok(list) : NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
